using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Dhs5.Utility;
using System;

namespace Dhs5.AdvancedUI
{
    public class ScrollList<T> : IScrollList
    {
        private enum SwipeDirection { LEFT = -1, RIGHT = 1, UP = -1, DOWN = 1 }

        readonly private ScrollListComponent scrollListComponent;
        readonly private List<T> list;
        readonly private List<ScrollListSocket> sockets;
        readonly private List<ScrollListSocket> socketsInOrder;
        readonly private DragableUI dragableObject;
        readonly private GameObject prefab;
        
        // Parameters
        readonly private bool isHorizontal;
        readonly private bool useScroll;
        readonly private float scrollSensitivity;
        readonly private float socketWidth;
        readonly private float spaceBetweenSockets;
        
        readonly private bool useAnim;
        readonly private float animLerp;
        readonly private float animDelay;

        public ScrollList(ScrollListComponent _scrollListComponent, List<T> _list, List<ScrollListSocket> _sockets, List<ScrollListSocket> _socketsInOrder,
            DragableUI _dragableObject, GameObject _prefab,
            bool _isHorizontal, bool _useScroll, float _scrollSensitivity, float _socketWidth, float _spaceBetweenSockets,
            bool _useAnim, float _animLerp, float _animDelay)
        {
            scrollListComponent = _scrollListComponent;
            list = _list;
            sockets = _sockets;
            socketsInOrder = _socketsInOrder;
            dragableObject = _dragableObject;
            prefab = _prefab;

            isHorizontal = _isHorizontal;
            useScroll = _useScroll;
            scrollSensitivity = _scrollSensitivity;
            socketWidth = _socketWidth;
            spaceBetweenSockets = _spaceBetweenSockets;
            useAnim = _useAnim;
            animLerp = _animLerp;
            animDelay = _animDelay;

            Enable();

            CreateList();
        }

        private List<ScrollListObject> scrollListObjects = new();

        private int TotalObjectNumber => sockets.Count;
        private int RightSocketsNumber => TotalObjectNumber / 2 + 1;
        private ScrollListSocket MaxSocket => socketsInOrder.Get(-1);
        private int LeftSocketsNumber => RightSocketsNumber - 1;
        private ScrollListSocket MinSocket => socketsInOrder[0];

        public int CurrentSelectionIndex()
        {
            return sockets[0].ScrollListObject.Index;
        }

        public event Action<int, string> OnSelectionChange;

        public void InvokeSelectionChange()
        {
            ScrollListObject currentSelection = sockets[0].ScrollListObject;
            OnSelectionChange?.Invoke(currentSelection.Index, currentSelection.GetName(list[currentSelection.Index]));
        }

        #region List Management

        private void AddToScrollListObjects(object obj, int objectIndex, int socketIndex)
        {
            ScrollListObject scrollListObject = GameObject.Instantiate(prefab, sockets[socketIndex].transform)
                .GetComponent<ScrollListObject>();
            scrollListObject.Set(obj, objectIndex);

            sockets[socketIndex].ScrollListObject = scrollListObject;
            scrollListObjects.Add(scrollListObject);
        }

        public void CreateList()
        {
            // Right sockets
            for (int i = 0; i < RightSocketsNumber; i++)
            {
                AddToScrollListObjects(list.Get(i), list.ValidIndex(i), i * 2);
            }

            // Left sockets
            for (int i = 0; i < LeftSocketsNumber; i++)
            {
                AddToScrollListObjects(list.Get(-i - 1), list.ValidIndex(-i - 1), i * 2 + 1);
            }
        }

        #endregion

        #region Swipe Management

        private bool canMove = true;

        public void Enable()
        {
            if (dragableObject)
            {
                dragableObject.Drag += OnScroll;
                dragableObject.DragDelta += OnEndScroll;
            }
        }
        public void Disable()
        {
            if (dragableObject)
            {
                dragableObject.Drag -= OnScroll;
                dragableObject.DragDelta -= OnEndScroll;
            }
        }

        private void OnScroll(PointerEventData pointerEventData)
        {
            if (!canMove || !useScroll) return;

            MoveScrollListObjects(isHorizontal ? pointerEventData.delta.x : pointerEventData.delta.y);
        }
        private void OnEndScroll(Vector2 delta)
        {
            if (!canMove || !useScroll) return;

            float fDelta = isHorizontal ? delta.x : delta.y;
            float absDelta = Mathf.Abs(fDelta);
            if (absDelta > scrollSensitivity)
            {
                Swipe(fDelta, Mathf.Max(1, Mathf.RoundToInt(absDelta / (socketWidth + spaceBetweenSockets))));
            }
            else
            {
                RepositionAll();
            }
        }

        private void MoveScrollListObjects(float delta)
        {
            foreach (var obj in scrollListObjects)
            {
                obj.Move(delta, isHorizontal); // TranslateX ...
            }
        }

        private void Swipe(float delta, int units) 
        {
            if (isHorizontal)
            {
                Swipe(delta > 0 ? SwipeDirection.LEFT : SwipeDirection.RIGHT, units);
            }
            else
            {
                Swipe(delta > 0 ? SwipeDirection.DOWN : SwipeDirection.UP, units);
            }
        }
        private void Swipe(SwipeDirection direction, int units)
        {
            int extremeObjectIndex;
            ScrollListObject extremeObject;

            for (int u = 0; u < units; u++)
            {
                if (direction == SwipeDirection.RIGHT || direction == SwipeDirection.DOWN)
                {
                    extremeObject = MinSocket.ScrollListObject;
                    for (int i = 0; i < TotalObjectNumber - 1; i++)
                    {
                        socketsInOrder[i].ScrollListObject = socketsInOrder.Get(i + 1).ScrollListObject;
                    }
                    extremeObjectIndex = list.ValidIndex(socketsInOrder[TotalObjectNumber - 1].ScrollListObject.Index + 1);
                    socketsInOrder[TotalObjectNumber - 1].ScrollListObject = extremeObject;
                    socketsInOrder[TotalObjectNumber - 1].ScrollListObject.Set(list[extremeObjectIndex], extremeObjectIndex);
                }
                else
                {
                    extremeObject = MaxSocket.ScrollListObject;
                    for (int i = TotalObjectNumber - 1; i > 0; i--)
                    {
                        socketsInOrder[i].ScrollListObject = socketsInOrder.Get(i - 1).ScrollListObject;
                    }
                    extremeObjectIndex = list.ValidIndex(socketsInOrder[0].ScrollListObject.Index - 1);
                    socketsInOrder[0].ScrollListObject = extremeObject;
                    socketsInOrder[0].ScrollListObject.Set(list[extremeObjectIndex], extremeObjectIndex);
                }
            }

            RepositionAll();

            if (units != 0)
            {
                InvokeSelectionChange();
            }
        }

        public void AutoScroll(int units)
        {
            if (!canMove) return;

            int absUnits = Mathf.Abs(units);
            SwipeDirection direction = (SwipeDirection)(units / absUnits);

            Swipe(direction, absUnits);
        }

        private void RepositionAll()
        {
            if (useAnim)
            {
                scrollListComponent.StartCoroutine(RepositionAllCR(animLerp, animDelay));
                return;
            }
            foreach (var obj in scrollListObjects)
            {
                obj.transform.LocalReset();
            }
        }
        private IEnumerator RepositionAllCR(float lerp, float delay)
        {
            canMove = false;

            socketsInOrder[0].ScrollListObject.transform.LocalReset();
            socketsInOrder[TotalObjectNumber - 1].ScrollListObject.transform.LocalReset();

            float currentLerp = lerp;
            while (currentLerp < 0.99f)
            {
                currentLerp = Mathf.Lerp(currentLerp, 1, lerp);
                foreach (var obj in scrollListObjects)
                {
                    obj.transform.localPosition = Vector3.Lerp(obj.transform.localPosition, Vector3.zero, lerp);
                }
                yield return new WaitForSeconds(delay);
            }
            foreach (var obj in scrollListObjects)
            {
                obj.transform.LocalReset();
            }

            canMove = true;
        }
        #endregion
    }
}

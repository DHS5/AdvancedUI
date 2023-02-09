using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Dhs5.Utility;

namespace Dhs5.AdvancedUI
{
    public interface IScrollList
    {
        public int CurrentSelectionIndex();
        public void Enable();
        public void Disable();
    }

    public class ScrollList<T> : IScrollList
    {
        private enum SwipeDirection { LEFT = -1, RIGHT = 1, UP = -1, DOWN = 1 }

        private List<T> list;
        private List<ScrollListSocket> sockets;
        private List<ScrollListSocket> socketsInOrder;
        private DragableUI dragableObject;
        private GameObject prefab;

        // Parameters
        private bool isHorizontal;
        private float scrollSensitivity;
        private float socketWidth;
        private float spaceBetweenSockets;

        public ScrollList(List<T> _list, List<ScrollListSocket> _sockets, List<ScrollListSocket> _socketsInOrder, 
            DragableUI _dragableObject, GameObject _prefab,
            bool _isHorizontal, float _scrollSensitivity, float _socketWidth, float _spaceBetweenSockets)
        {
            list = _list;
            sockets = _sockets;
            socketsInOrder = _socketsInOrder;
            dragableObject = _dragableObject;
            prefab = _prefab;

            isHorizontal = _isHorizontal;
            scrollSensitivity = _scrollSensitivity;
            socketWidth = _socketWidth;
            spaceBetweenSockets = _spaceBetweenSockets;

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
            MoveScrollListObjects(isHorizontal ? pointerEventData.delta.x : pointerEventData.delta.y);
        }
        private void OnEndScroll(Vector2 delta)
        {
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
                    socketsInOrder[TotalObjectNumber - 1].ScrollListObject = extremeObject;
                }
                else
                {
                    extremeObject = MaxSocket.ScrollListObject;
                    for (int i = TotalObjectNumber - 1; i > 0; i--)
                    {
                        socketsInOrder[i].ScrollListObject = socketsInOrder.Get(i - 1).ScrollListObject;
                    }
                    socketsInOrder[0].ScrollListObject = extremeObject;
                }
            }

            RepositionAll();
        }

        private void RepositionAll()
        {
            foreach (var obj in scrollListObjects)
            {
                obj.transform.LocalReset();
            }
        }
        #endregion
    }
}

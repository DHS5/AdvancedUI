using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using Dhs5.Utility;

namespace Dhs5.AdvancedUI
{
    public class HorizontalScrollList : MonoBehaviour
    {
        [System.Serializable]
        private enum ScrollDirection { Horizontal, Vertical }

        [Header("Parameters")]
        [OnValueChanged(nameof(ChangeDirection))]
        [SerializeField] private ScrollDirection scrollDirection;
        [OnValueChanged(nameof(ResizeSockets))]
        public float socketSize = 100;
        public float scrollSensitivity = 100;
        [OnValueChanged(nameof(SetLayoutSpacing))]
        public float spaceBetweenSockets = 10;

        [Space, Space]
        [Header("UI Components")]
        [SerializeField] private DragableUI dragableObject;
        [SerializeField] private RectTransform socketHorizontalContainer;
        [SerializeField] private RectTransform socketVerticalContainer;
        [SerializeField] private HorizontalLayoutGroup horizontalLayout;
        [SerializeField] private VerticalLayoutGroup verticalLayout;
        [SerializeField] private GameObject scrollListObjectPrefab;

        private RectTransform SocketContainer { get { return scrollDirection == ScrollDirection.Horizontal ? 
                    socketHorizontalContainer : socketVerticalContainer; } }
        private HorizontalOrVerticalLayoutGroup Layout { get { return scrollDirection == ScrollDirection.Horizontal ?
                    horizontalLayout : verticalLayout; } }


        [Space, Space]
        [Header("Sockets")]
        [SerializeField] private ScrollListSocket mainSocket;
        [ShowNativeProperty] public int TotalObjectNumber => sockets.Count;

        [ReadOnly][SerializeField] List<ScrollListSocket> sockets = new();
        [ReadOnly][SerializeField] List<ScrollListSocket> socketsInOrder = new();


        #region ScrollList Management

        private IScrollList scrollList;
        public void CreateList<T>(List<T> list)
        {
            scrollList = new ScrollList<T>(list, sockets, socketsInOrder, dragableObject, scrollListObjectPrefab,
                scrollDirection == ScrollDirection.Horizontal, scrollSensitivity, socketSize, spaceBetweenSockets);
        }

        public int CurrentSelectionIndex 
        { 
            get 
            {
                if (scrollList == null) return 0;
                return scrollList.CurrentSelectionIndex(); 
            } 
        }
        private void OnEnable()
        {
            if (scrollList != null) scrollList.Enable();
        }
        private void OnDisable()
        {
            if (scrollList != null) scrollList.Disable();
        }
        #endregion

        #region Socket Management

        [Button("Add 2 sockets")]
        private void Add()
        {
            AddSocket(true);
            AddSocket(false);
        }
        private void AddSocket(bool first)
        {
            ScrollListSocket socket = Instantiate(mainSocket.gameObject, SocketContainer).GetComponent<ScrollListSocket>();
            socket.name = "socket " + TotalObjectNumber;
            socket.Width = socketSize;
            if (first)
            {
                socket.transform.SetAsFirstSibling();
                socketsInOrder.Insert(0, socket);
            }
            else socketsInOrder.Add(socket);
            sockets.Add(socket);
        }
        [Button("Remove 2 sockets")]
        private void Remove()
        {
            if (TotalObjectNumber < 3) return;
            RemoveSocket();
            RemoveSocket();
        }
        private void RemoveSocket()
        {
            ScrollListSocket socket = sockets[TotalObjectNumber - 1];
            sockets.Remove(socket);
            socketsInOrder.Remove(socket);
            DestroyImmediate(socket.gameObject);
        }
        [Button("Reset sockets")]
        private void ResetSockets()
        {
            if (sockets != null)
            {
                foreach (var socket in sockets)
                    if (socket && socket != mainSocket)
                        DestroyImmediate(socket.gameObject);
            }
            sockets = new();
            socketsInOrder = new();
            sockets.Add(mainSocket);
            socketsInOrder.Add(mainSocket);
        }

        #endregion

        #region Helper Functions
        private void ChangeDirection()
        {
            InverseDimension();
            ChangeSocketsParent();
            ResizeSockets();
            SetLayoutSpacing();
        }
        private void ResizeSockets()
        {
            foreach (var socket in sockets)
            {
                if (scrollDirection == ScrollDirection.Horizontal)
                    socket.Width = socketSize;
                else
                    socket.Height = socketSize;
            }
        }
        private void SetLayoutSpacing()
        {
            Layout.spacing = spaceBetweenSockets;
        }
        private void InverseDimension()
        {
            RectTransform rectTransform = transform as RectTransform;
            Vector2 dimensions = rectTransform.rect.size;
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, dimensions.y);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, dimensions.x);
        }
        private void ChangeSocketsParent()
        {
            foreach (var socket in socketsInOrder)
            {
                socket.transform.SetParent(SocketContainer);
            }
        }
        #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using System;
using TMPro;

namespace Dhs5.AdvancedUI
{
    public class ScrollListComponent : MonoBehaviour
    {
        [System.Serializable]
        private enum ScrollDirection { Horizontal, Vertical }
        
        [System.Serializable]
        private enum ListFormat { Infinite, Simple }

        [Header("Parameters")]
        [OnValueChanged(nameof(SetUp))]
        [SerializeField] private ScrollDirection scrollDirection;
        private bool IsHorizontal => scrollDirection == ScrollDirection.Horizontal;
        private bool IsVertical => scrollDirection == ScrollDirection.Vertical;
        [Space]
        [SerializeField] private ListFormat format;
        private bool IsInfinite => format == ListFormat.Infinite;
        private bool IsSimple => format == ListFormat.Simple;
        [Space]
        [OnValueChanged(nameof(ResizeSockets))]
        public float socketSize = 100;
        [OnValueChanged(nameof(SetLayoutSpacing))]
        public float spaceBetweenSockets = 10;
        [Space]
        public bool useScroll = true;
        [ShowIf(nameof(useScroll))][SerializeField] private float scrollSensitivity = 100;
        [Space]
        [OnValueChanged(nameof(SetDisplay))][SerializeField] private bool useDisplay = true;
        [OnValueChanged(nameof(SetDisplay))][ShowIf(nameof(useDisplay))][SerializeField] private float displayHeight = 80;
        [Space]
        [OnValueChanged(nameof(SetButtons))][SerializeField] private bool useButtons = false;
        [OnValueChanged(nameof(SetButtons))][ShowIf(nameof(useButtons))][SerializeField] private float buttonsHeight = 80;
        [Space]
        [SerializeField] private bool useAnim = false;
        [ShowIf(nameof(useAnim))][SerializeField] private float animLerp = 0.5f;
        [ShowIf(nameof(useAnim))][SerializeField] private float animDelay = 0.02f;

        [Space, Space]
        #region UI Components
        [Header("UI Components")]
        [SerializeField] private DragableUI dragableObject;

        // Infinite
        [ShowIf(EConditionOperator.And, nameof(IsHorizontal), nameof(IsInfinite))][SerializeField] 
        private RectTransform socketHorizontalContainer;
        [ShowIf(EConditionOperator.And, nameof(IsHorizontal), nameof(IsInfinite))][SerializeField] 
        private HorizontalLayoutGroup horizontalLayout;
        [ShowIf(EConditionOperator.And, nameof(IsVertical), nameof(IsInfinite))][SerializeField] 
        private RectTransform socketVerticalContainer;
        [ShowIf(EConditionOperator.And, nameof(IsVertical), nameof(IsInfinite))][SerializeField] 
        private VerticalLayoutGroup verticalLayout;
        
        // Simple
        [ShowIf(EConditionOperator.And, nameof(IsHorizontal), nameof(IsSimple))][SerializeField] 
        private RectTransform socketHorizontalSimpleContainer;
        [ShowIf(EConditionOperator.And, nameof(IsHorizontal), nameof(IsSimple))][SerializeField] 
        private HorizontalLayoutGroup horizontalSimpleLayout;
        [ShowIf(EConditionOperator.And, nameof(IsVertical), nameof(IsSimple))][SerializeField] 
        private RectTransform socketVerticalSimpleContainer;
        [ShowIf(EConditionOperator.And, nameof(IsVertical), nameof(IsSimple))][SerializeField] 
        private VerticalLayoutGroup verticalSimpleLayout;
        [ShowIf(EConditionOperator.And, nameof(IsHorizontal), nameof(IsSimple))][SerializeField] 
        private HorizontalLayoutGroup objectHorizontalLayout;
        [ShowIf(EConditionOperator.And, nameof(IsVertical), nameof(IsSimple))][SerializeField] 
        private VerticalLayoutGroup objectVerticalLayout;

        [SerializeField] private GameObject scrollListObjectPrefab;
        [Space]
        [ShowIf(nameof(useDisplay))][SerializeField] private RectTransform displayContainer;
        [ShowIf(nameof(useDisplay))][SerializeField] private TextMeshProUGUI displayText;
        [Space]
        [ShowIf(nameof(useButtons))][SerializeField] private RectTransform buttonsContainer;
        [ShowIf(nameof(useButtons))][SerializeField] private AdvancedButton lessButton;
        [ShowIf(nameof(useButtons))][SerializeField] private AdvancedButton plusButton;
        #endregion

        private RectTransform SocketContainer { get { return IsHorizontal ? socketHorizontalContainer : socketVerticalContainer; } }
        private HorizontalOrVerticalLayoutGroup Layout { get { return IsHorizontal ? horizontalLayout : verticalLayout; } }
        private HorizontalOrVerticalLayoutGroup SimpleLayout 
        { get { return IsHorizontal ? horizontalSimpleLayout : verticalSimpleLayout; } }
        private HorizontalOrVerticalLayoutGroup ObjectLayout 
        { get { return IsHorizontal ? objectHorizontalLayout : objectVerticalLayout; } }


        [Space, Space]
        [Header("Sockets")]
        [SerializeField] private ScrollListSocket mainSocket;
        [ShowNativeProperty] public int TotalObjectNumber => sockets.Count;

        [ReadOnly][SerializeField] List<ScrollListSocket> sockets = new();
        [ReadOnly][SerializeField] List<ScrollListSocket> socketsInOrder = new();


        private void Awake()
        {
            SetUp();
        }


        #region ScrollList Management

        private IScrollList scrollList;
        public void CreateList<T>(List<T> list)
        {
            if (IsInfinite) CreateInfiniteList(list);
            else if (IsSimple) CreateSimpleList(list);
        }
        private void CreateInfiniteList<T>(List<T> list)
        {
            scrollList = new ScrollList<T>(this, list, sockets, socketsInOrder, dragableObject, scrollListObjectPrefab,
                IsHorizontal, useScroll, scrollSensitivity, socketSize, spaceBetweenSockets, useAnim, animLerp, animDelay);

            scrollList.OnSelectionChange += SelectionChange;
            scrollList.InvokeSelectionChange();
        }
        private void CreateSimpleList<T>(List<T> list)
        {
            CreateSocketsForSimpleList(list.Count);

            scrollList = new ScrollList<T>(this, list, sockets, socketsInOrder, dragableObject, scrollListObjectPrefab,
                IsHorizontal, useScroll, scrollSensitivity, socketSize, spaceBetweenSockets, useAnim, animLerp, animDelay);

            scrollList.OnSelectionChange += SelectionChange;
            scrollList.InvokeSelectionChange();
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
            if (scrollList != null)
            {
                scrollList.Enable();
                scrollList.OnSelectionChange += SelectionChange;
            }
            if (useButtons) EnableButtons();
        }
        private void OnDisable()
        {
            if (scrollList != null)
            {
                scrollList.Disable();
                scrollList.OnSelectionChange -= SelectionChange;
            }
            if (useButtons) DisableButtons();
        }

        private void SelectionChange(int index, string display)
        {
            SetDisplayText(display);
        }
        #endregion

        #region Socket Management

        [Button("Add 2 sockets")]
        private void Add()
        {
            AddSocket(true, SocketContainer);
            AddSocket(false, SocketContainer);
        }
        private void AddSocket(bool first, RectTransform container)
        {
            ScrollListSocket socket = Instantiate(mainSocket.gameObject, container).GetComponent<ScrollListSocket>();
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

        private void CreateSocketsForSimpleList(int listSize)
        {
            RectTransform container = IsHorizontal ? socketHorizontalSimpleContainer : socketVerticalSimpleContainer;
            ResetSockets();
            mainSocket.transform.SetParent(container, false);
            mainSocket.Index = 0;
            ObjectLayout.transform.SetParent(mainSocket.transform, false);
            for (int i = 1; i < listSize; i++)
            {
                AddSocket(false, container);
                sockets[i].Index = i;
            }
        }
        #endregion

        #region Buttons & Display Management
        private void EnableButtons()
        {
            if (lessButton) lessButton.OnClick += Less;
            if (plusButton) plusButton.OnClick += Plus;
        }
        private void DisableButtons()
        {
            if (lessButton) lessButton.OnClick -= Less;
            if (plusButton) plusButton.OnClick -= Plus;
        }

        private void Less()
        {
            if (scrollList != null)
                scrollList.AutoScroll(-1);
        }
        private void Plus()
        {
            if (scrollList != null)
                scrollList.AutoScroll(1);
        }

        private void SetDisplayText(string text)
        {
            if (displayText)
                displayText.text = text;
        }
        #endregion

        #region Helper Functions
        private void SetUp()
        {
            SetActiveObjects();

            InverseDimension();
            ChangeSocketsParent();
            ResizeSockets();
            SetLayoutSpacing();
        }
        private void SetActiveObjects()
        {
            socketHorizontalContainer.gameObject.SetActive(IsHorizontal && IsInfinite);
            socketVerticalContainer.gameObject.SetActive(IsVertical && IsInfinite);
            socketHorizontalSimpleContainer.gameObject.SetActive(IsHorizontal && IsSimple);
            socketVerticalSimpleContainer.gameObject.SetActive(IsVertical && IsSimple);
        }
        private void ResizeSockets()
        {
            foreach (var socket in sockets)
            {
                if (IsHorizontal)
                    socket.Width = socketSize;
                else
                    socket.Height = socketSize;
            }
            RepositionLayouts();
        }
        private void SetLayoutSpacing()
        {
            Layout.spacing = spaceBetweenSockets;
            SimpleLayout.spacing = spaceBetweenSockets;
            ObjectLayout.spacing = spaceBetweenSockets;
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

        private void SetDisplay()
        {
            if (displayContainer)
            {
                displayContainer.gameObject.SetActive(useDisplay);
                displayContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, displayHeight);
            }
        }
        private void SetButtons()
        {
            if (buttonsContainer)
            {
                buttonsContainer.gameObject.SetActive(useButtons);
                buttonsContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonsHeight);
            }
        }
        private void RepositionLayouts()
        {
            if (IsHorizontal && socketHorizontalSimpleContainer)
            {
                socketHorizontalSimpleContainer.anchoredPosition = new Vector2(socketSize / 2, 0);
            }
            if (IsVertical && socketVerticalSimpleContainer)
            {
                socketVerticalSimpleContainer.anchoredPosition = new Vector2(0, -socketSize / 2);
            }
        }
        #endregion
    }

    public interface IScrollList
    {
        public int CurrentSelectionIndex();
        public void Enable();
        public void Disable();
        public void AutoScroll(int units);

        public event Action<int, string> OnSelectionChange;
        public void InvokeSelectionChange();
    }
}

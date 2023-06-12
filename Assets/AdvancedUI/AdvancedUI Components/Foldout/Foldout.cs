using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

namespace Dhs5.AdvancedUI
{
    public class Foldout : AdvancedComponent
    {
        [Header("Button")]
        [SerializeField] private StylePicker buttonStylePicker;
        [SerializeField] private ButtonContent buttonContent;
        public ButtonContent ButtonContent { get { return buttonContent; } set { buttonContent = value; } }

        [Header("Background")]
        [SerializeField] private StylePicker backgroundStylePicker;

        [SerializeField] private bool open;
        public bool IsOpen { get => open; set { open = value; SetFoldoutState(value); } }
        public override bool Interactable { get => button.Interactable; set => button.Interactable = value; }

        [Header("Events")]
        [SerializeField] private UnityEvent onClick;
        [SerializeField] private UnityEvent onOpen;
        [SerializeField] private UnityEvent onClose;

        public event Action OnClick { add { button.OnClick += value; } remove { button.OnClick -= value; } }
        public event Action OnOpen;
        public event Action OnClose;

        [Header("UI Components")]
        [SerializeField] private AdvancedButton button;
        [Space]
        [SerializeField] private AdvancedImage background;
        [SerializeField] private Image backgroundMask;


        #region Events

        protected override void LinkEvents()
        {
            button.OnClick += Click;
        }
        protected override void UnlinkEvents()
        {
            button.OnClick -= Click;
        }

        private void Click() 
        { 
            onClick?.Invoke();
            ChangeFoldoutState();
        }
        private void Open()
        {
            OnOpen?.Invoke();
            onOpen?.Invoke();
        }
        private void Close()
        {
            OnClose?.Invoke();
            onClose?.Invoke();
        }


        private void ChangeFoldoutState() 
        { 
            IsOpen = !IsOpen;
            SetFoldoutState(IsOpen);
        }
        private void SetFoldoutState(bool state) 
        { 
            background.gameObject.SetActive(state);

            if (state) Open();
            else Close();
        }

        #endregion

        #region Configs

        protected override void SetUpConfig()
        {
            if (styleSheetContainer == null) return;

            buttonStylePicker.SetUp(styleSheetContainer, StyleSheetType.BUTTON, "Button Style");
            backgroundStylePicker.SetUp(styleSheetContainer, StyleSheetType.BACKGROUND_IMAGE, "Background Style");

            if (button)
            {
                button.Style = buttonStylePicker;
                button.Content = buttonContent;
            }
            if (background)
            {
                background.gameObject.SetActive(IsOpen);
                background.Style = backgroundStylePicker;
            }
            if (backgroundMask)
            {
                backgroundMask.SetUpMask(backgroundStylePicker.StyleSheet as ImageStyleSheet);
            }
        }

        protected override void SetUpGraphics() { }

        #endregion
    }
}

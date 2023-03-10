using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System;

namespace Dhs5.AdvancedUI
{
    #region Popup Content

    [System.Serializable]
    public struct PopupContent
    {
        // ### Constructor ###
        public PopupContent(string text, int _fontSize = 25, int width = 200, string confirmation = "Yes", string cancel = "No", int _buttonsHeight = 50)
        {
            popupText = text;
            fontSize = _fontSize;
            popupWidth = width;
            confirmationText = confirmation;
            cancelText = cancel;
            buttonsHeight = _buttonsHeight;
        }


        // ### Properties ###
        [TextArea] public string popupText;
        [SerializeField] private int fontSize; public int FontSize { get { return fontSize > 0 ? fontSize : 25; } }
        [SerializeField] private int popupWidth; public int PopupWidth { get { return popupWidth > 0 ? popupWidth : 200; } }
        [Space]
        [SerializeField] private string confirmationText; public string ConfirmationText { get { return !string.IsNullOrWhiteSpace(confirmationText) ? confirmationText : "Yes"; } }
        [SerializeField] private string cancelText; public string CancelText { get { return !string.IsNullOrWhiteSpace(cancelText) ? cancelText : "No"; } }
        [SerializeField] private int buttonsHeight; public int ButtonsHeight { get { return buttonsHeight > 0 ? buttonsHeight : 50; } }
    }

    #endregion

    public class AdvancedPopup : AdvancedComponent
    {
        [Header("Popup Type")]
        [SerializeField] private PopupType popupType;
        public PopupType Type { get { return popupType; } set { popupType = value; SetUpConfig(); } }

        [Header("Content")]
        [SerializeField] private PopupContent popupContent;
        public PopupContent Content { get { return popupContent; } set { popupContent = value; SetUpConfig(); } }

        public override bool Interactable { get => gameObject.activeSelf; set => gameObject.SetActive(value); }


        [Header("Events")]
        [SerializeField] private UnityEvent onConfirm;
        [SerializeField] private UnityEvent onCancel;

        public event Action OnConfirm { add { confirmButton.OnClick += value; } remove { confirmButton.OnClick -= value; } }
        public event Action OnCancel { add { cancelButton.OnClick += value; } remove { cancelButton.OnClick -= value; } }


        [Header("Custom Style Sheet")]
        [SerializeField] private PopupStyleSheet customStyleSheet;


        [Header("Style Sheet Container")]
        [SerializeField] private StyleSheetContainer styleSheetContainer;
        private PopupStyleSheet CurrentStyleSheet { get { return popupType == PopupType.CUSTOM ? customStyleSheet : 
                    styleSheetContainer ? styleSheetContainer.projectStyleSheet.popupStyleSheets.GetStyleSheet(popupType) : null; } }

        [Header("UI Components")]
        [SerializeField] private Image popupImage;
        [SerializeField] private Image filterImage;
        [Space]
        [SerializeField] private TextMeshProUGUI popupText;
        [Space]
        [SerializeField] private GameObject buttonsContainer;
        [SerializeField] private AdvancedButton confirmButton;
        [SerializeField] private AdvancedButton cancelButton;
        [SerializeField] private AdvancedButton quitButton;

        #region Events
        // ### Events ###

        protected override void LinkEvents()
        {
            if (onConfirm.GetPersistentEventCount() > 0)
                confirmButton.OnClick += Confirm;
            cancelButton.OnClick += Cancel;
            quitButton.OnClick += Cancel;
        }
        protected override void UnlinkEvents()
        {
            if (onConfirm.GetPersistentEventCount() > 0)
                confirmButton.OnClick -= Confirm;
            cancelButton.OnClick -= Cancel;
            quitButton.OnClick -= Cancel;
        }

        private void Confirm()
        {
            onConfirm?.Invoke();
        }
        private void Cancel()
        {
            onCancel?.Invoke();
            ClosePopup();
        }

        private void ClosePopup() { gameObject.SetActive(false); }

        #endregion

        #region Configs
        // ### Configs ###

        protected override void SetUpConfig()
        {
            if (CurrentStyleSheet == null) return;

            // Background
            if (popupImage != null)
            {
                popupImage.sprite = CurrentStyleSheet.popupStyleSheet.baseSprite;
                popupImage.color = CurrentStyleSheet.popupStyleSheet.baseColor;
                popupImage.material = CurrentStyleSheet.popupStyleSheet.baseMaterial;
                popupImage.type = CurrentStyleSheet.popupStyleSheet.imageType;
                popupImage.pixelsPerUnitMultiplier = CurrentStyleSheet.popupStyleSheet.pixelsPerUnit;
            }

            // Filter
            if (filterImage)
            {
                filterImage.enabled = CurrentStyleSheet.filterActive;
                filterImage.color = CurrentStyleSheet.filterColor;
            }

            // Text
            if (popupText != null)
            {
                popupText.enabled = CurrentStyleSheet.textActive;
                popupText.text = popupContent.popupText;
                popupText.fontSize = popupContent.FontSize;
                popupText.font = CurrentStyleSheet.textStyleSheet.font;
                popupText.fontStyle = CurrentStyleSheet.textStyleSheet.fontStyle;
                popupText.alignment = CurrentStyleSheet.textStyleSheet.alignment;
            }

            // Buttons
            if (buttonsContainer)
            {
                buttonsContainer.SetActive(CurrentStyleSheet.confirmButtonActive && CurrentStyleSheet.cancelButtonActive);
                (buttonsContainer.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Content.ButtonsHeight);
            }
            if (confirmButton)
            {
                confirmButton.gameObject.SetActive(CurrentStyleSheet.confirmButtonActive);
                confirmButton.Type = CurrentStyleSheet.confirmButtonType;
                confirmButton.Content = new ButtonContent(Content.ConfirmationText);
            }
            if (cancelButton)
            {
                cancelButton.gameObject.SetActive(CurrentStyleSheet.cancelButtonActive);
                cancelButton.Type = CurrentStyleSheet.cancelButtonType;
                cancelButton.Content = new ButtonContent(Content.CancelText);
            }
            if (quitButton)
            {
                quitButton.gameObject.SetActive(CurrentStyleSheet.quitButtonActive);
                quitButton.Type = CurrentStyleSheet.quitButtonType;
            }

            if (popupImage)
            {
                (transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Content.PopupWidth);
                LayoutRebuilder.ForceRebuildLayoutImmediate(popupImage.rectTransform);
            }
        }
        #endregion
    }
}

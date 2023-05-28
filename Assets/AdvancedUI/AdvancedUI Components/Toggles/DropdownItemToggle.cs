using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System;

namespace Dhs5.AdvancedUI
{
    public class DropdownItemToggle : AdvancedComponent
    {
        [Header("Toggle Type")]
        [SerializeField] private StylePicker toggleStylePicker;
        public StylePicker Style { get => toggleStylePicker; set { toggleStylePicker.ForceSet(value); SetUpConfig(); } }

        [Header("Toggle Content")]
        [SerializeField] private bool isOn = true;
        [SerializeField] private bool overrideText = false;
        [SerializeField] private string text;

        public override bool Interactable { get => toggle.interactable; set => toggle.interactable = value; }


        [Header("Custom Style Sheet")]
        [SerializeField] private bool custom;
        [SerializeField] private DropdownItemToggleStyleSheet customStyleSheet;

        private DropdownItemToggleStyleSheet CurrentStyleSheet 
        { get { return custom ? customStyleSheet : styleSheetContainer ? toggleStylePicker.StyleSheet as DropdownItemToggleStyleSheet : null; } }


        [Header("UI Components")]
        [SerializeField] private OpenToggle toggle;
        [SerializeField] private Image toggleBackground;
        [Space]
        [SerializeField] private Image checkmarkImage;
        [Space]
        [SerializeField] private TextMeshProUGUI toggleText;


        protected override void Awake()
        {
            toggle.GetGraphics(toggleBackground, CurrentStyleSheet.BackgroundStyleSheet,
                checkmarkImage, CurrentStyleSheet.CheckmarkStyleSheet,
                toggleText, CurrentStyleSheet.TextStyleSheet);

            base.Awake();
        }

        #region Public Accessors & Methods

        public bool State { get { return toggle.isOn; } set { toggle.isOn = value; } }
        public string Text { get { return overrideText ? text : toggleText.text; } set { if (overrideText) toggleText.text = value; } }

        public void ActuState()
        {
            if (checkmarkImage) checkmarkImage.enabled = State;

            toggle.ForceInstantTransition();
        }

        #endregion

        #region Events

        public event Action<bool> OnValueChanged { add { toggle.OnValueChanged += value; } remove { toggle.OnValueChanged -= value; } }

        protected override void LinkEvents()
        {
            OnValueChanged += ValueChanged;
        }
        protected override void UnlinkEvents()
        {
            OnValueChanged -= ValueChanged;
        }

        private void ValueChanged(bool state)
        {
            isOn = state;
            ActuState();
        }

        #endregion

        #region Configs

        protected override void SetUpConfig()
        {
            State = isOn;

            if (styleSheetContainer == null) return;

            customStyleSheet.SetUp(styleSheetContainer);
            toggleStylePicker.SetUp(styleSheetContainer, StyleSheetType.DROPDOWN_ITEM_TOGGLE, "Toggle Type");

            if (CurrentStyleSheet == null) return;

            // Background
            if (toggleBackground != null)
            {
                toggleBackground.enabled = CurrentStyleSheet.backgroundActive;
                toggleBackground.SetUpImage(CurrentStyleSheet.BackgroundStyleSheet);
            }

            // Checkmark Icon
            if (checkmarkImage != null)
            {
                checkmarkImage.SetUpImage(CurrentStyleSheet.CheckmarkStyleSheet);
            }

            // Text
            if (toggleText != null)
            {
                toggleText.text = Text;
                toggleText.SetUpText(CurrentStyleSheet.TextStyleSheet);
            }

            ActuState();
        }

        private void OnTransformParentChanged()
        {
            if (checkmarkImage)
                checkmarkImage.rectTransform.SetSizeWithCurrentAnchors
                (RectTransform.Axis.Horizontal, (toggle.transform as RectTransform).rect.height);
        }

        #endregion
    }
}

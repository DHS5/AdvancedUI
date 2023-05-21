using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Dhs5.AdvancedUI
{
    public class AdvancedText : AdvancedComponent
    {
        [Header("Text Type")]
        public StylePicker stylePicker;

        [Header("Custom Style Sheet")]
        [SerializeField] private bool custom;
        [SerializeField] private TextStyleSheet customStyleSheet;

        [Header("UI Components")]
        [SerializeField] private TextMeshProUGUI text;

        public override bool Interactable { get => true; set => SetUpConfig(); }

        protected override void LinkEvents() { }
        protected override void UnlinkEvents() { }

        protected override void SetUpConfig()
        {
            if (styleSheetContainer == null) return;

            stylePicker.SetUp(styleSheetContainer, StyleSheetType.TEXT);
            TextStyleSheet textStyleSheet = custom ? customStyleSheet : stylePicker.StyleSheet as TextStyleSheet;

            if (text && textStyleSheet != null)
                text.SetUpText(textStyleSheet);
        }
    }
}

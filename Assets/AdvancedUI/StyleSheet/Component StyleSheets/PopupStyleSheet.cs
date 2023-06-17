using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class PopupStyleSheet : BaseStyleSheet
    {
        public StylePicker popupStylePicker;
        [Space]
        public bool filterActive = true;
        public Color filterColor;
        [Space]
        public bool textActive = true;
        public StylePicker textStylePicker;
        [Space]
        public bool confirmButtonActive = false;
        [SerializeField] private StylePicker confirmationButtonStylePicker;
        public bool cancelButtonActive = false;
        [SerializeField] private StylePicker cancelButtonStylePicker;
        public bool quitButtonActive = true;
        [SerializeField] private StylePicker quitButtonStylePicker;

        public ImageStyleSheet PopupBackgroundStyleSheet => popupStylePicker.StyleSheet as ImageStyleSheet;
        public TextStyleSheet TextStyleSheet => textStylePicker.StyleSheet as TextStyleSheet;
        public StylePicker ConfirmationButtonStyle => confirmationButtonStylePicker;
        public StylePicker CancelButtonStyle => cancelButtonStylePicker;
        public StylePicker QuitButtonStyle => quitButtonStylePicker;

        public override void SetUp(StyleSheetContainer _container)
        {
            base.SetUp(_container);

            popupStylePicker?.SetUp(container, StyleSheetType.BACKGROUND_IMAGE, "Popup");

            textStylePicker?.SetUp(container, StyleSheetType.TEXT, "Text Type");

            confirmationButtonStylePicker?.SetUp(container, StyleSheetType.BUTTON, "Confirmation Button");
            cancelButtonStylePicker?.SetUp(container, StyleSheetType.BUTTON, "Cancel Button");
            quitButtonStylePicker?.SetUp(container, StyleSheetType.BUTTON, "Quit Button");
        }

        public override List<StyleSheetPlaceholder> GetDependencies()
        {
            return new List<StyleSheetPlaceholder>()
            {
                ConfirmationButtonStyle.Placeholder,
                CancelButtonStyle.Placeholder,
                QuitButtonStyle.Placeholder,
                popupStylePicker.Placeholder,
                textStylePicker.Placeholder
            };
        }

        protected override void CopyStyleSheet(BaseStyleSheet s)
        {
            if (s is PopupStyleSheet p)
            {
                confirmationButtonStylePicker.ForceSet(p.confirmationButtonStylePicker);
                cancelButtonStylePicker.ForceSet(p.cancelButtonStylePicker);
                quitButtonStylePicker.ForceSet(p.quitButtonStylePicker);
                popupStylePicker.ForceSet(p.popupStylePicker);
                textStylePicker.ForceSet(p.textStylePicker);

                filterActive = p.filterActive;
                filterColor = p.filterColor;
                textActive = p.textActive;
                confirmButtonActive = p.confirmButtonActive;
                cancelButtonActive = p.cancelButtonActive;
                quitButtonActive = p.quitButtonActive;
            }
        }
    }
}

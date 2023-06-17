using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class InputfieldStyleSheet : BaseStyleSheet
    {
        public bool backgroundActive = true;
        public StylePicker backgroundStylePicker;
        [Space, Space]
        public bool hintTextActive = true;
        public StylePicker hintTextStylePicker;
        [Space, Space]
        public StylePicker inputTextStylePicker;
        public Color selectionColor;

        public ImageStyleSheet BackgroundStyleSheet => backgroundStylePicker.StyleSheet as ImageStyleSheet;
        public TextStyleSheet HintTextStyleSheet => hintTextStylePicker.StyleSheet as TextStyleSheet;
        public TextStyleSheet InputTextStyleSheet => inputTextStylePicker.StyleSheet as TextStyleSheet;


        public override void SetUp(StyleSheetContainer _container)
        {
            base.SetUp(_container);

            backgroundStylePicker?.SetUp(container, StyleSheetType.BACKGROUND_IMAGE, "Background");
            hintTextStylePicker?.SetUp(container, StyleSheetType.TEXT, "Hint Text type");
            inputTextStylePicker?.SetUp(container, StyleSheetType.TEXT, "Input Text type");
        }

        public override List<StyleSheetPlaceholder> GetDependencies()
        {
            return new List<StyleSheetPlaceholder>()
            {
                backgroundStylePicker.Placeholder,
                hintTextStylePicker.Placeholder,
                inputTextStylePicker.Placeholder
            };
        }

        protected override void CopyStyleSheet(BaseStyleSheet s)
        {
            if (s is InputfieldStyleSheet i)
            {
                backgroundStylePicker.ForceSet(i.backgroundStylePicker);
                hintTextStylePicker.ForceSet(i.hintTextStylePicker);
                inputTextStylePicker.ForceSet(i.inputTextStylePicker);

                backgroundActive = i.backgroundActive;
                hintTextActive = i.hintTextActive;
                selectionColor = i.selectionColor;
            }
        }
    }
}

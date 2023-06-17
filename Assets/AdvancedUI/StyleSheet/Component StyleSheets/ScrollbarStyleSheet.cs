using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class ScrollbarStyleSheet : BaseStyleSheet
    {
        public bool backgroundActive = true;
        public StylePicker backgroundStylePicker;
        [Space, Space]
        public StylePicker handleStylePicker;


        public ImageStyleSheet BackgroundStyleSheet => backgroundStylePicker.StyleSheet as ImageStyleSheet;
        public ImageStyleSheet HandleStyleSheet => handleStylePicker.StyleSheet as ImageStyleSheet;

        public override void SetUp(StyleSheetContainer _container)
        {
            base.SetUp(_container);

            backgroundStylePicker?.SetUp(container, StyleSheetType.BACKGROUND_IMAGE, "Background");
            handleStylePicker?.SetUp(container, StyleSheetType.ICON_IMAGE, "Handle");
        }

        public override List<StyleSheetPlaceholder> GetDependencies()
        {
            return new List<StyleSheetPlaceholder>()
            {
                backgroundStylePicker.Placeholder,
                handleStylePicker.Placeholder
            };
        }

        protected override void CopyStyleSheet(BaseStyleSheet s)
        {
            if (s is ScrollbarStyleSheet b)
            {
                backgroundActive = b.backgroundActive;

                backgroundStylePicker.ForceSet(b.backgroundStylePicker);
                handleStylePicker.ForceSet(b.handleStylePicker);
            }
        }
    }
}

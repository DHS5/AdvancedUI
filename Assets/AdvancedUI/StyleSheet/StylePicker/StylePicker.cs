using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class StylePicker
    {
        [SerializeField] private StyleSheetContainer container;
        [SerializeField] private StyleSheetType type;
        [SerializeField] private int styleSheetUID;

        public BaseStyleSheet StyleSheet
        {
            get
            {
                return container.projectStyleSheet.GetStyleSheet(styleSheetUID, type);
            }
        }

        public void SetUp(StyleSheetContainer _container, StyleSheetType _type)
        {
            container = _container;
            type = _type;
        }
    }
}

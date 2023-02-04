using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class SwitchToggleStyleSheet
    {
        public ImageStyleSheet backgroundStyleSheet;
        public ImageStyleSheet foregroundStyleSheet;
        [Space, Space]
        public ImageStyleSheet handleStyleSheet;
        [Space, Space]
        public bool leftTextActive;
        public TextStyleSheet leftTextStyleSheet;
        public bool rightTextActive;
        public TextStyleSheet rightTextStyleSheet;
    }
}

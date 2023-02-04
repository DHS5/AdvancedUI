using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class ButtonStyleSheet
    {
        public bool backgroundActive = true;
        public ImageStyleSheet backgroundStyleSheet;
        [Space, Space]
        public bool iconActive = true;
        public float iconScale = 1;
        public ImageStyleSheet iconStyleSheet;
        [Space, Space]
        public bool textActive = false;
        public TextStyleSheet textStyleSheet;
    }
}

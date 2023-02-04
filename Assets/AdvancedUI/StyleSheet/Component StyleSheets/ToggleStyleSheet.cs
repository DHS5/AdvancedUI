using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class ToggleStyleSheet
    {
        public bool backgroundActive = true;
        public ImageStyleSheet backgroundStyleSheet;
        [Space, Space]
        public bool checkmarkActive = true;
        public float checkmarkScale = 1;
        public GraphicStyleSheet checkmarkStyleSheet;
        [Space, Space]
        public bool uncheckmarkActive = true;
        public float uncheckmarkScale = 1;
        public GraphicStyleSheet uncheckmarkStyleSheet;
        [Space, Space]
        public bool textActive = true;
        public TextStyleSheet textStyleSheet;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class SliderStyleSheet
    {
        public bool backgroundActive = true;
        public ImageStyleSheet backgroundStyleSheet;
        [Space, Space]
        public bool fillActive = true;
        public ImageStyleSheet fillStyleSheet;
        [Space, Space]
        public bool handleActive = true;
        public ImageStyleSheet handleStyleSheet;
        [Space, Space]
        public bool textActive = false;
        public TextStyleSheet textStyleSheet;
        [Space, Space]
        public bool isGradient = false;
        public Gradient sliderGradient;
    }
}

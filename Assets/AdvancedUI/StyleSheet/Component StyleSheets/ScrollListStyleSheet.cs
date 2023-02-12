using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class ScrollListStyleSheet
    {
        public bool frameActive = false;
        [ShowIf(nameof(frameActive))][AllowNesting] public ImageStyleSheet frameStyleSheet;
        public ImageStyleSheet frameMaskStyleSheet;
        public ImageStyleSheet backgroundStyleSheet;
        [Space]
        public ImageStyleSheet horizontalMaskStyleSheet;
        public ImageStyleSheet verticalMaskStyleSheet;
        [Space]
        public TextStyleSheet textStyleSheet;
        [Space]
        public AdvancedButtonType leftButtonStyleSheet;
        public AdvancedButtonType rightButtonStyleSheet;
    }
}

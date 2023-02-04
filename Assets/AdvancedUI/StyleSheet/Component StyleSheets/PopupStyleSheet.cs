using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class PopupStyleSheet
    {
        public ImageStyleSheet popupStyleSheet;
        [Space]
        public bool filterActive = true;
        public Color filterColor;
        [Space]
        public bool textActive = true;
        public TextStyleSheet textStyleSheet;
        [Space]
        public bool confirmButtonActive = false;
        public AdvancedButtonType confirmButtonType;
        public bool cancelButtonActive = false;
        public AdvancedButtonType cancelButtonType;
        public bool quitButtonActive = true;
        public AdvancedButtonType quitButtonType;
    }
}

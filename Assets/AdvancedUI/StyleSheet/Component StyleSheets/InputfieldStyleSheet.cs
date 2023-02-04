using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class InputfieldStyleSheet
    {
        public bool backgroundActive = true;
        public ImageStyleSheet backgroundStyleSheet;
        [Space, Space]
        public bool hintTextActive = true;
        public TextStyleSheet hintTextStyleSheet;
        [Space, Space]
        public TextStyleSheet inputTextStyleSheet;
        public Color selectionColor;
    }
}

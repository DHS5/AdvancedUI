using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class DropdownItemToggleStyleSheet
    {
        public bool backgroundActive = true;
        public ImageStyleSheet backgroundStyleSheet;
        [Space, Space]
        public ImageStyleSheet checkmarkStyleSheet;
        [Space, Space]
        public TextStyleSheet textStyleSheet;
    }
}

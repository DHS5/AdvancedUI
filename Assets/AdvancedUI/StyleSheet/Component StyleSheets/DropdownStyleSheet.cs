using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class DropdownStyleSheet
    {
        public bool backgroundActive = true;
        public ImageStyleSheet backgroundStyleSheet;
        [Space, Space]
        public bool titleActive = true;
        public TextStyleSheet titleStyleSheet;
        [Space, Space]
        public bool arrowActive = true;
        public ImageStyleSheet arrowStyleSheet;
        [Space, Space]
        public TextStyleSheet textStyleSheet;
        [Space, Space]
        public AdvancedScrollViewType templateScrollviewType;
        [Space, Space]
        public DropdownItemToggleType itemToggleType;
    }
}

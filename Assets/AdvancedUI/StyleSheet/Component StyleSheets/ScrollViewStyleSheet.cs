using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class ScrollViewStyleSheet
    {
        public bool backgroundActive = true;
        public GraphicStyleSheet backgroundStyleSheet;
        [Space]
        public bool verticalScrollbarActive = true;
        public AdvancedScrollbarType verticalScrollbarType;
        [Space]
        public bool horizontalScrollbarActive = false;
        public AdvancedScrollbarType horizontalScrollbarType;
    }
}

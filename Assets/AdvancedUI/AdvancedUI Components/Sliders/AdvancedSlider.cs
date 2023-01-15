using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;

namespace Dhs5.AdvancedUI
{
    [Serializable]
    public struct SliderContent
    {

        // ### Properties ###
        [SerializeField] private int backgroundHeight; 
        public int BackgroundHeight { get { return backgroundHeight > 0 ? backgroundHeight : 10; } set { backgroundHeight = value; } }
        [SerializeField] private int fillHeight;
        public int FillHeight { get { return fillHeight > 0 ? fillHeight : 10; } set { fillHeight = value; } }
        [SerializeField] private int handleZoneMargin;
        public int HandleZoneMargin { get { return handleZoneMargin > 0 ? handleZoneMargin : 10; } set { handleZoneMargin = value; } }
    }

    public class AdvancedSlider : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private void Test()
        {
            
        }
    }
}

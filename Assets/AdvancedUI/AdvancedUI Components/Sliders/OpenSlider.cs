using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dhs5.AdvancedUI
{
    public class OpenSlider : Slider
    {

        public float FillHeight { set { fillRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value); } }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            handleRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (transform as RectTransform).rect.height);

            base.OnValidate();
        }
#endif
    }
}

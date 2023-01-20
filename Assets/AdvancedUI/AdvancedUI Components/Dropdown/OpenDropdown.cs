using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Dhs5.AdvancedUI
{
    public class OpenDropdown : TMP_Dropdown
    {
        public RectTransform ArrowRect { get; set; }

        protected override void OnRectTransformDimensionsChange()
        {
            base.OnRectTransformDimensionsChange();

            ForceResizeArrow();
        }

        private void ForceResizeArrow()
        {
            if (ArrowRect != null)
            {
                ArrowRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ArrowRect.rect.height);
            }
        }
    }
}

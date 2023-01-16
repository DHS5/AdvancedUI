using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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


        #region Transitions

        private Image backgroundImage;
        private ImageStyleSheet backgroundStyleSheet;
        private Image fillImage;
        private ImageStyleSheet fillStyleSheet;
        private Image handleImage;
        private ImageStyleSheet handleStyleSheet;
        private TextMeshProUGUI sliderText;
        private TextStyleSheet textStyleSheet;

        public void GetGraphics(Image background, ImageStyleSheet _backgroundStyleSheet,
            Image fill, ImageStyleSheet _fillStyleSheet, Image handle, ImageStyleSheet _handleStyleSheet,
            TextMeshProUGUI text, TextStyleSheet _textStyleSheet)
        {
            backgroundImage = background;
            backgroundStyleSheet = _backgroundStyleSheet;
            fillImage = fill;
            fillStyleSheet = _fillStyleSheet;
            handleImage = handle;
            handleStyleSheet = _handleStyleSheet;
            sliderText = text;
            textStyleSheet = _textStyleSheet;

            ForceInstantTransition();
        }

        protected override void DoStateTransition(SelectionState state, bool instant)
        {
            if (backgroundImage && backgroundImage.enabled) backgroundImage.TransitionImage((int)state, instant, backgroundStyleSheet);
            if (fillImage && fillImage.enabled) fillImage.TransitionImage((int)state, instant, fillStyleSheet);
            if (handleImage && handleImage.enabled) handleImage.TransitionImage((int)state, instant, handleStyleSheet);
            if (sliderText && sliderText.enabled) sliderText.TransitionText((int)state, instant, textStyleSheet);
        }

        public void ForceInstantTransition()
        {
            DoStateTransition(SelectionState.Normal, true);
        }

        #endregion
    }
}

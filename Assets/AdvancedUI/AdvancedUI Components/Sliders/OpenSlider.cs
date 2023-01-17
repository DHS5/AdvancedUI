using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

namespace Dhs5.AdvancedUI
{
    public class OpenSlider : Slider
    {
        public float FillHeight { set { fillRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value); } }
        

        protected override void OnRectTransformDimensionsChange()
        {
            ForceResizeHandle();
        }
        public void ForceResizeHandle()
        {
            if (direction == Direction.LeftToRight || direction == Direction.RightToLeft)
                handleRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (transform as RectTransform).rect.height);
            else
                handleRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (transform as RectTransform).rect.width);
        }

        #region Events

        // Events
        public event Action OnSliderDown;
        public event Action OnSliderUp;


        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            OnSliderDown?.Invoke();
        }
        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            OnSliderUp?.Invoke();
        }

        #endregion

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

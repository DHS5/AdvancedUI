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
        [Header("Slider base properties")]
        public Slider.Direction direction;
        public int minValue;
        public int maxValue;
        public bool wholeNumbers;
        [Range(0, 1)] public float normalizedValue;

        [Header("Slider size properties")]
        [SerializeField] private int backgroundHeight; 
        public int BackgroundHeight { get { return backgroundHeight > 0 ? backgroundHeight : 10; } set { backgroundHeight = value; } }
        [SerializeField] private int fillHeight;
        public int FillHeight { get { return fillHeight > 0 ? fillHeight : 10; } set { fillHeight = value; } }
        [SerializeField] private int handleZoneDelta;
        public int HandleZoneDelta { get { return handleZoneDelta > 0 ? handleZoneDelta : 10; } set { handleZoneDelta = value; } }
    }

    public class AdvancedSlider : AdvancedComponent
    {
        [Header("Slider Type")]
        [SerializeField] private AdvancedSliderType sliderType;
        public AdvancedSliderType Type { get { return sliderType; } set { sliderType = value; SetUpConfig(); } }

        [Header("Slider Content")]
        [SerializeField] private SliderContent sliderContent;
        public SliderContent Content { get { return sliderContent; } set { sliderContent = value; } }


        [Header("Custom Style Sheet")]
        [SerializeField] private SliderStyleSheet customStyleSheet;

        [Header("Style Sheet Container")]
        [SerializeField] private StyleSheetContainer styleSheetContainer;
        private SliderStyleSheet CurrentStyleSheet
        { get { return Type == AdvancedSliderType.CUSTOM ? customStyleSheet :
                    styleSheetContainer ? styleSheetContainer.projectStyleSheet.sliderStyleSheets.GetStyleSheet(Type) : null; } }


            [Header("UI Components")]
        [SerializeField] private OpenSlider slider;
        [Space]
        [SerializeField] private Image backgroundImage;
        [Space]
        [SerializeField] private RectTransform handleArea;
        [SerializeField] private Image handle;
        [Space]
        [SerializeField] private RectTransform fillArea;
        [SerializeField] private Image fill;
        [Space]
        [SerializeField] private TextMeshProUGUI sliderText;


        protected override void Awake()
        {
            slider.GetGraphics(backgroundImage, CurrentStyleSheet.backgroundStyleSheet,
                handle, CurrentStyleSheet.handleStyleSheet,
                fill, CurrentStyleSheet.fillStyleSheet,
                sliderText, CurrentStyleSheet.textStyleSheet);

            base.Awake();
        }


        #region Events

        protected override void LinkEvents()
        {
            
        }
        protected override void UnlinkEvents()
        {
            
        }

        #endregion

        #region Configs

        protected override void SetUpConfig()
        {
            if (CurrentStyleSheet == null) return;

            SetSliderInfo();

            // Background
            if (backgroundImage)
            {
                backgroundImage.enabled = CurrentStyleSheet.backgroundActive;
                backgroundImage.SetUpImage(CurrentStyleSheet.backgroundStyleSheet);
                backgroundImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Content.BackgroundHeight);
            }

            // Fill
            if (fill)
            {
                fill.enabled = CurrentStyleSheet.fillActive;
                fill.SetUpImage(CurrentStyleSheet.fillStyleSheet);
            }
            if (fillArea)
            {
                fillArea.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Content.FillHeight);
            }

            // Handle
            if (handle)
            {
                handle.enabled = CurrentStyleSheet.handleActive;
                handle.SetUpImage(CurrentStyleSheet.handleStyleSheet);
                handle.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (transform as RectTransform).rect.height);
            }
            if (handleArea)
            {
                handleArea.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (transform as RectTransform).rect.width - 2 * Content.HandleZoneDelta);
            }
        }

        private void SetSliderInfo()
        {
            if (slider)
            {
                slider.SetDirection(Content.direction, true);
                slider.minValue = Content.minValue;
                slider.maxValue = Content.maxValue;
                slider.wholeNumbers = Content.wholeNumbers;
                slider.normalizedValue = Content.normalizedValue;
                //slider.FillHeight = Content.FillHeight;
            }
        }

        #endregion
    }
}

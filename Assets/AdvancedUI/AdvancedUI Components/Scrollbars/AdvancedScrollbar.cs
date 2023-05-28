using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dhs5.AdvancedUI
{
    public class AdvancedScrollbar : AdvancedComponent
    {
        [Header("Scrollbar Type")]
        [SerializeField] private StylePicker scrollbarStylePicker;
        public StylePicker Style { get => scrollbarStylePicker; set { scrollbarStylePicker.ForceSet(value); SetUpConfig(); } }

        public override bool Interactable { get => scrollbar.interactable; set => scrollbar.interactable = value; }


        [Header("Custom Style Sheet")]
        [SerializeField] private bool custom;
        [SerializeField] private ScrollbarStyleSheet customStyleSheet;

        private ScrollbarStyleSheet CurrentStyleSheet
        { get { return custom ? customStyleSheet : styleSheetContainer ? Style.StyleSheet as ScrollbarStyleSheet : null; } }


        [Header("UI Components")]
        [SerializeField] private OpenScrollbar scrollbar;
        [Space]
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image handle;

        protected override void Awake()
        {
            scrollbar.GetGraphics(backgroundImage, CurrentStyleSheet.BackgroundStyleSheet,
                handle, CurrentStyleSheet.HandleStyleSheet);

            base.Awake();
        }

        #region Events

        protected override void LinkEvents() { }
        protected override void UnlinkEvents() { }

        #endregion

        #region Configs

        protected override void SetUpConfig()
        {
            if (styleSheetContainer == null) return;

            customStyleSheet.SetUp(styleSheetContainer);
            scrollbarStylePicker.SetUp(styleSheetContainer, StyleSheetType.SCROLLBAR, "Scrollbar Type");

            if (CurrentStyleSheet == null) return;

            // Background
            if (backgroundImage)
            {
                backgroundImage.enabled = CurrentStyleSheet.backgroundActive;
                backgroundImage.SetUpImage(CurrentStyleSheet.BackgroundStyleSheet);
            }

            // Handle
            if (handle)
            {
                handle.SetUpImage(CurrentStyleSheet.HandleStyleSheet);
            }
        }

        #endregion
    }
}

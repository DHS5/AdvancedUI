using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dhs5.AdvancedUI
{
    public class AdvancedScrollbar : AdvancedComponent
    {
        [Header("Scrollbar Type")]
        [SerializeField] private AdvancedScrollbarType scrollbarType;
        public AdvancedScrollbarType Type { get { return scrollbarType; } set { scrollbarType = value; SetUpConfig(); } }



        [Header("Custom Style Sheet")]
        [SerializeField] private ScrollbarStyleSheet customStyleSheet;

        [Header("Style Sheet Container")]
        [SerializeField] private StyleSheetContainer styleSheetContainer;
        private ScrollbarStyleSheet CurrentStyleSheet
        { get { return Type == AdvancedScrollbarType.CUSTOM ? customStyleSheet :
                    styleSheetContainer ? styleSheetContainer.projectStyleSheet.scrollbarStyleSheets.GetStyleSheet(Type) : null; } }


        [Header("UI Components")]
        [SerializeField] private OpenScrollbar scrollbar;
        [Space]
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image handle;

        protected override void Awake()
        {
            scrollbar.GetGraphics(backgroundImage, CurrentStyleSheet.backgroundStyleSheet,
                handle, CurrentStyleSheet.handleStyleSheet);

            base.Awake();
        }

        #region Events

        protected override void LinkEvents() { }
        protected override void UnlinkEvents() { }

        #endregion

        #region Configs

        protected override void SetUpConfig()
        {
            // Background
            if (backgroundImage)
            {
                backgroundImage.enabled = CurrentStyleSheet.backgroundActive;
                backgroundImage.SetUpImage(CurrentStyleSheet.backgroundStyleSheet);
            }

            // Handle
            if (handle)
            {
                handle.enabled = CurrentStyleSheet.handleActive;
                handle.SetUpImage(CurrentStyleSheet.handleStyleSheet);
            }
        }

        #endregion
    }
}

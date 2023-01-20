using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Dhs5.AdvancedUI
{
    public class AdvancedDropdown : AdvancedComponent
    {
        [Header("Dropdown Type")]
        [SerializeField] private AdvancedDropdownType dropdownType;
        public AdvancedDropdownType Type { get { return dropdownType; } set { dropdownType = value; SetUpConfig(); } }



        [Header("Custom Style Sheet")]
        [SerializeField] private DropdownStyleSheet customStyleSheet;


        [Header("Style Sheet Container")]
        [SerializeField] private StyleSheetContainer styleSheetContainer;
        private DropdownStyleSheet CurrentStyleSheet { get { return dropdownType == AdvancedDropdownType.CUSTOM ? customStyleSheet : 
                    styleSheetContainer ? styleSheetContainer.projectStyleSheet.dropdownStyleSheets.GetStyleSheet(dropdownType) : null; } }


        [Header("UI Components")]
        [SerializeField] private OpenDropdown dropdown;
        [SerializeField] private Image dropdownBackground;
        [Space]
        [SerializeField] private Image arrowImage;
        [SerializeField] private TextMeshProUGUI dropdownText;
        [Space]
        [SerializeField] private AdvancedScrollView templateScrollView;
        [Space]
        [SerializeField] private RectTransform itemRect;
        [SerializeField] private Image itemBackground;
        [SerializeField] private Image itemCheckmark;
        [SerializeField] private TextMeshProUGUI itemText;


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

            // Arrow
            if (arrowImage)
            {
                if (dropdown) dropdown.ArrowRect = arrowImage.rectTransform;
            }
        }

        #endregion
    }
}

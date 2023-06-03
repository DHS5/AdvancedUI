using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Dhs5.AdvancedUI
{
    public class AdvancedImage : AdvancedComponent
    {
        [Header("Image Type")]
        public StylePicker imageStylePicker;
        public bool selectable;

        [Header("Custom Style Sheet")]
        [SerializeField] private bool custom;
        [SerializeField] private ImageStyleSheet customStyleSheet;

        private ImageStyleSheet CurrentStyleSheet
        { get { return custom ? customStyleSheet : styleSheetContainer ? imageStylePicker.StyleSheet as ImageStyleSheet : null; } }

        [Header("UI Components")]
        [SerializeField] private SelectableGraphic imageGraphic;

        public override bool Interactable { get => imageGraphic.interactable; set { imageGraphic.interactable = value; SetUpConfig(); } }

        public event Action OnMouseEnter { add { imageGraphic.OnMouseEnter += value; } remove { imageGraphic.OnMouseEnter -= value; } }
        public event Action OnMouseExit { add { imageGraphic.OnMouseExit += value; } remove { imageGraphic.OnMouseExit -= value; } }


        protected override void Awake()
        {
            imageGraphic.SetStyleSheet(CurrentStyleSheet);

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
            imageStylePicker.SetUp(styleSheetContainer, StyleSheetType.BACKGROUND_IMAGE);
            
            if (CurrentStyleSheet == null) return;

            if (imageGraphic && imageGraphic.targetGraphic is Image image)
            {
                image.SetUpImage(CurrentStyleSheet);
                imageGraphic.selectable = selectable;
            }
        }
        #endregion
    }
}

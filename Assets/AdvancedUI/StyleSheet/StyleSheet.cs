using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Dhs5.AdvancedUI
{
    /// <summary>
    /// StyleSheet Scriptable Object containing the style options for every AdvancedUI components
    /// </summary>
    [CreateAssetMenu(fileName = "StyleSheet", menuName = "AdvancedUI/StyleSheet/StyleSheet", order = 1)]
    public class StyleSheet : ScriptableObject
    {
        [Header("Buttons")]
        public ButtonStyleSheetList buttonStyleSheets;
        [Space, Space]
        [Header("Toggle")]
        public ToggleStyleSheetList toggleStyleSheets;
        public DropdownItemToggleStyleSheetList dropdownItemToggleStyleSheets;
        public SwitchToggleStyleSheetList switchToggleStyleSheets;
        [Space, Space]
        [Header("Slider")]
        public SliderStyleSheetList sliderStyleSheets;
        [Space, Space]
        [Header("Dropdown")]
        public DropdownStyleSheetList dropdownStyleSheets;
        [Space, Space]
        [Header("InputField")]
        public InputfieldStyleSheetList inputfieldStyleSheets;
        [Space, Space]
        [Header("ScrollBar")]
        public ScrollbarStyleSheetList scrollbarStyleSheets;
        [Space, Space]
        [Header("Popup")]
        public PopupStyleSheetList popupStyleSheets;
        [Space, Space]
        [Header("ScrollView")]
        public ScrollViewStyleSheetList scrollViewStyleSheets;

        // ... ScrollView
    }

    #region Composite Style Sheets

    [System.Serializable]
    public class TransitionStyleSheet
    {
        [Header("Transition Type")]
        public Selectable.Transition transitionType;

        [Header("Sprite Transition")]
        public SpriteState spriteState;

        [Header("Color Transition")]
        public ColorBlock colorBlock;
    }

    [System.Serializable]
    public class ImageStyleSheet
    {
        public Sprite baseSprite;
        public Color baseColor;
        public Material baseMaterial;
        [Space]
        public Image.Type imageType;
        [Range(0, 10)] public float pixelsPerUnit = 1;
        [Space]
        public TransitionStyleSheet transition;
    }

    [System.Serializable]
    public class TextStyleSheet
    {
        public TMP_FontAsset font;
        public FontStyles fontStyle;
        public TextAlignmentOptions alignment;
        [Space]
        public ColorBlock transition;
    }

    [System.Serializable]
    public class GraphicStyleSheet
    {
        public bool isImage;
        public ImageStyleSheet imageStyleSheet;
        public TextStyleSheet textStyleSheet;
    }

    #endregion
}

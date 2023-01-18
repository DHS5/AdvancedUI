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

        // ... ScrollView
    }


    #region Style Sheet Lists
    // ### Style Sheet Lists ###

    #region Buttons
    // # Buttons #
    public enum AdvancedButtonType
    {
        CUSTOM = -1,

        TEXT = 0,
        ONLY_TEXT = 1,
        ONLY_ICON = 2,
        ONLY_BACKGROUND = 3,
        BACK_AND_ICON = 4,

        QUIT = 5,
        BACK = 6,
        INFO = 7,
        QUESTION = 8,
        WARNING = 9,
        IMPORTANT_ANSWER = 10,
    }

    [System.Serializable]
    public class ButtonStyleSheetList
    {
        public ButtonStyleSheet text;
        public ButtonStyleSheet textOnly;
        public ButtonStyleSheet iconOnly;
        public ButtonStyleSheet backgroundOnly;
        public ButtonStyleSheet backAndIcon;
        [Space]
        public ButtonStyleSheet quit;
        public ButtonStyleSheet back;
        public ButtonStyleSheet info;
        public ButtonStyleSheet question;
        public ButtonStyleSheet warning;
        public ButtonStyleSheet importantAnswer;


        public ButtonStyleSheet GetStyleSheet(AdvancedButtonType type)
        {
            return type switch
            {
                AdvancedButtonType.TEXT => text,
                AdvancedButtonType.ONLY_TEXT => textOnly,
                AdvancedButtonType.ONLY_ICON => iconOnly,
                AdvancedButtonType.ONLY_BACKGROUND => backgroundOnly,
                AdvancedButtonType.BACK_AND_ICON => backAndIcon,
                AdvancedButtonType.QUIT => quit,
                AdvancedButtonType.BACK => back,
                AdvancedButtonType.INFO => info,
                AdvancedButtonType.QUESTION => question,
                AdvancedButtonType.WARNING => warning,
                AdvancedButtonType.IMPORTANT_ANSWER => importantAnswer,
                _ => null,
            };
        }
    }
    #endregion

    #region Toggle
    // # Toggle #
    public enum AdvancedToggleType
    {
        CUSTOM = -1,
        BASIC = 0,
        BASIC_W_TEXT = 1,
        ONLY_CHECK = 2,
        ONLY_CHECK_W_TEXT = 3,
        CHECK_TEXTS = 4,
        CHECK_TEXTS_NO_BACK = 5,
        ONLY_CHECK_TEXT = 6,
        FULL_TEXTS = 7,
        FULL_TEXTS_NO_BACK = 8,
        CHECKS_NO_BACK = 9,
        CHECKS_NO_BACK_W_TEXT = 10,
    }

    [System.Serializable]
    public class ToggleStyleSheetList
    {
        public ToggleStyleSheet basic;
        public ToggleStyleSheet basicWithText;
        public ToggleStyleSheet checkOnly;
        public ToggleStyleSheet checkOnlyWithText;
        public ToggleStyleSheet checkTexts;
        public ToggleStyleSheet checkTextsNoBackground;
        public ToggleStyleSheet checkTextOnly;
        public ToggleStyleSheet fullTexts;
        public ToggleStyleSheet fullTextsNoBackground;
        public ToggleStyleSheet checksNoBackground;
        public ToggleStyleSheet checksNoBackgroundWithText;


        public ToggleStyleSheet GetStyleSheet(AdvancedToggleType type)
        {
            return type switch
            {
                AdvancedToggleType.BASIC => basic,
                AdvancedToggleType.BASIC_W_TEXT => basicWithText,
                AdvancedToggleType.ONLY_CHECK => checkOnly,
                AdvancedToggleType.ONLY_CHECK_W_TEXT => checkOnlyWithText,
                AdvancedToggleType.CHECK_TEXTS => checkTexts,
                AdvancedToggleType.CHECK_TEXTS_NO_BACK => checkTextsNoBackground,
                AdvancedToggleType.ONLY_CHECK_TEXT => checkTextOnly,
                AdvancedToggleType.FULL_TEXTS => fullTexts,
                AdvancedToggleType.FULL_TEXTS_NO_BACK => fullTextsNoBackground,
                AdvancedToggleType.CHECKS_NO_BACK => checksNoBackground,
                AdvancedToggleType.CHECKS_NO_BACK_W_TEXT => checksNoBackgroundWithText,
                _ => null,
            };
        }
    }
    #endregion

    #region Slider
    // # Slider #
    public enum AdvancedSliderType
    {
        CUSTOM = -1,
        CLASSIC = 0,
        CLASSIC_W_TEXT = 1,
        NO_FILL = 2,
        NO_FILL_W_TEXT = 3,
        NO_BACK = 4,
        NO_BACK_W_TEXT = 5,
    }

    [System.Serializable]
    public class SliderStyleSheetList
    {
        public SliderStyleSheet classic;
        public SliderStyleSheet classicWithText;
        public SliderStyleSheet noFill;
        public SliderStyleSheet noFillWithText;
        public SliderStyleSheet noBackground;
        public SliderStyleSheet noBackgroundWithText;


        public SliderStyleSheet GetStyleSheet(AdvancedSliderType type)
        {
            return type switch
            {
                AdvancedSliderType.CLASSIC => classic,
                AdvancedSliderType.CLASSIC_W_TEXT => classicWithText,
                AdvancedSliderType.NO_FILL => noFill,
                AdvancedSliderType.NO_FILL_W_TEXT => noFillWithText,
                AdvancedSliderType.NO_BACK => noBackground,
                AdvancedSliderType.NO_BACK_W_TEXT => noBackgroundWithText,
                _ => null,
            };
        }
    }
    #endregion

    #region Dropdown
    // # Dropdown #
    public enum AdvancedDropdownType
    {
        CUSTOM = -1,
        BASE = 0,
    }

    [System.Serializable]
    public class DropdownStyleSheetList
    {
        public DropdownStyleSheet baseT;


        public DropdownStyleSheet GetStyleSheet(AdvancedDropdownType type)
        {
            return type switch
            {
                AdvancedDropdownType.BASE => baseT,
                _ => null,
            };
        }
    }
    #endregion

    #region Inputfield
    // # Inputfield #
    public enum AdvancedInputfieldType
    {
        CUSTOM = -1,
        BASE = 0,
    }

    [System.Serializable]
    public class InputfieldStyleSheetList
    {
        public InputfieldStyleSheet baseT;


        public InputfieldStyleSheet GetStyleSheet(AdvancedInputfieldType type)
        {
            return type switch
            {
                AdvancedInputfieldType.BASE => baseT,
                _ => null,
            };
        }
    }
    #endregion

    #region Scrollbar
    // # Scrollbar #
    public enum AdvancedScrollbarType
    {
        CUSTOM = -1,
        BASIC = 0,
    }

    [System.Serializable]
    public class ScrollbarStyleSheetList
    {
        public ScrollbarStyleSheet basic;


        public ScrollbarStyleSheet GetStyleSheet(AdvancedScrollbarType type)
        {
            return type switch
            {
                AdvancedScrollbarType.BASIC => basic,
                _ => null,
            };
        }
    }
    #endregion

    #region Popup
    // # Popup Buttons #
    public enum PopupType
    {
        CUSTOM = -1,

        INFO = 0,
        QUESTION = 1,
        WARNING = 2,
        CONFIRMATION = 3,
    }

    [System.Serializable]
    public class PopupStyleSheetList
    {
        public PopupStyleSheet info;
        public PopupStyleSheet question;
        public PopupStyleSheet warning;
        public PopupStyleSheet confirmation;


        public PopupStyleSheet GetStyleSheet(PopupType type)
        {
            return type switch
            {
                PopupType.INFO => info,
                PopupType.QUESTION => question,
                PopupType.WARNING => warning,
                PopupType.CONFIRMATION => confirmation,
                _ => null,
            };
        }
    }
    #endregion

    #endregion

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

    #region Components Style Sheets

    [System.Serializable]
    public class ButtonStyleSheet
    {
        public bool backgroundActive = true;
        public ImageStyleSheet backgroundStyleSheet;
        [Space, Space]
        public bool iconActive = true;
        public float iconScale = 1;
        public ImageStyleSheet iconStyleSheet;
        [Space, Space]
        public bool textActive = false;
        public TextStyleSheet textStyleSheet;
    }
    
    [System.Serializable]
    public class ToggleStyleSheet
    {
        public bool backgroundActive = true;
        public ImageStyleSheet backgroundStyleSheet;
        [Space, Space]
        public bool checkmarkActive = true;
        public float checkmarkScale = 1;
        public GraphicStyleSheet checkmarkStyleSheet;
        [Space, Space]
        public bool uncheckmarkActive = true;
        public float uncheckmarkScale = 1;
        public GraphicStyleSheet uncheckmarkStyleSheet;
        [Space, Space]
        public bool textActive = true;
        public TextStyleSheet textStyleSheet;
    }

    [System.Serializable]
    public class SliderStyleSheet
    {
        public bool backgroundActive = true;
        public ImageStyleSheet backgroundStyleSheet;
        [Space, Space]
        public bool fillActive = true;
        public ImageStyleSheet fillStyleSheet;
        [Space, Space]
        public bool handleActive = true;
        public ImageStyleSheet handleStyleSheet;
        [Space, Space]
        public bool textActive = false;
        public TextStyleSheet textStyleSheet;
    }

    [System.Serializable]
    public class DropdownStyleSheet
    {
        public bool backgroundActive = true;
        public ImageStyleSheet backgroundStyleSheet;
        [Space, Space]
        public bool arrowActive = true;
        public ImageStyleSheet arrowStyleSheet;
        [Space, Space]
        public bool textActive = true;
        public TextStyleSheet textStyleSheet;
        [Space, Space]
        public bool itemsBackgroundActive = true;
        public ImageStyleSheet itemsBackgroundStyleSheet;
        [Space, Space]
        public bool itemsArrowActive = true;
        public ImageStyleSheet itemsArrowStyleSheet;
        [Space, Space]
        public bool itemsTextActive = true;
        public TextStyleSheet itemsTextStyleSheet;
    }

    [System.Serializable]
    public class InputfieldStyleSheet
    {
        public bool backgroundActive = true;
        public ImageStyleSheet backgroundStyleSheet;
        [Space, Space]
        public bool hintTextActive = true;
        public TextStyleSheet hintTextStyleSheet;
        [Space, Space]
        public TextStyleSheet textStyleSheet;
    }
    
    [System.Serializable]
    public class ScrollbarStyleSheet
    {
        public bool backgroundActive = true;
        public ImageStyleSheet backgroundStyleSheet;
        [Space, Space]
        public bool handleActive = true;
        public ImageStyleSheet handleStyleSheet;
    }

    [System.Serializable]
    public class PopupStyleSheet
    {
        public ImageStyleSheet popupStyleSheet;
        [Space]
        public bool filterActive = true;
        public Color filterColor;
        [Space]
        public bool textActive = true;
        public TextStyleSheet textStyleSheet;
        [Space]
        public bool confirmButtonActive = false;
        public AdvancedButtonType confirmButtonType;
        public bool cancelButtonActive = false;
        public AdvancedButtonType cancelButtonType;
        public bool quitButtonActive = true;
        public AdvancedButtonType quitButtonType;
    }

    #endregion

    #region Constructed Components Style Sheet

    #endregion
}

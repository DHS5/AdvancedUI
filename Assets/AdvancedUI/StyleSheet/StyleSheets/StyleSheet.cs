using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NaughtyAttributes;
using System.Linq;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public enum StyleSheetType
    {
        TEXT,
        BUTTON,
        TOGGLE,
        DROPDOWN_ITEM_TOGGLE,
        SWITCH_TOGGLE,
        SLIDER,
        DROPDOWN,
        INPUT_FIELD,
        SCROLLBAR,
        POPUP,
        SCROLL_VIEW,
        SCROLL_LIST,
        BACKGROUND_IMAGE,
        ICON_IMAGE,
    }

    /// <summary>
    /// StyleSheet Scriptable Object containing the style options for every AdvancedUI components
    /// </summary>
    [CreateAssetMenu(fileName = "StyleSheet", menuName = "AdvancedUI/StyleSheet/StyleSheet", order = 1)]
    public class StyleSheet : ScriptableObject
    {
        [SerializeField] private StyleSheetContainer container;
        public StyleSheetContainer Container => container;

        [Header("Texts")]
        public TextStyleSheetList textStyleSheets;
        [Space, Space]
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
        [Space, Space]
        [Header("ScrollList")]
        public ScrollListStyleSheetList scrollListStyleSheets;

        [System.Serializable]
        public class Tabz
        {
            public int blabla;
            public List<string> tabs;
        }

        public List<Tabz> tabs = new List<Tabz>();
        [SerializeField] private List<TextStyleSheet> TextStyleSheets;
        [SerializeField] private List<ImageStyleSheet> BackgroundImageStyleSheets;
        [SerializeField] private List<ImageStyleSheet> IconImageStyleSheets;
        private List<ButtonStyleSheet> ButtonStyleSheets;
        private List<ToggleStyleSheet> ToggleStyleSheets;
        private List<DropdownItemToggleStyleSheet> DropdownItemToggleStyleSheets;
        private List<SwitchToggleStyleSheet> SwitchToggleStyleSheets;
        private List<SliderStyleSheet> SliderStyleSheets;
        private List<DropdownStyleSheet> DropdownStyleSheets;
        private List<InputfieldStyleSheet> InputfieldStyleSheets;
        private List<ScrollbarStyleSheet> ScrollbarStyleSheets;
        private List<ScrollViewStyleSheet> ScrollViewStyleSheets;
        private List<ScrollListStyleSheet> ScrollListStyleSheets;
        private List<PopupStyleSheet> PopupStyleSheets;

        #region UID management
        private void OnValidate()
        {
            SetUIDs(TextStyleSheets);
            SetUIDs(BackgroundImageStyleSheets);
            SetUIDs(IconImageStyleSheets);
            SetUIDs(ButtonStyleSheets);
            SetUIDs(ToggleStyleSheets);
            SetUIDs(DropdownItemToggleStyleSheets);
            SetUIDs(SwitchToggleStyleSheets);
            SetUIDs(SliderStyleSheets);
            SetUIDs(DropdownStyleSheets);
            SetUIDs(InputfieldStyleSheets);
            SetUIDs(ScrollbarStyleSheets);
            SetUIDs(ScrollViewStyleSheets);
            SetUIDs(ScrollListStyleSheets);
            SetUIDs(PopupStyleSheets);
        }

        private void SetUIDs<T>(List<T> list) where T : BaseStyleSheet
        {
            if (list == null || list.Count < 1) return;

            List<int> uids = new();
            foreach (T t in list)
            {
                if (uids.Contains(t.UID) || t.UID == 0)
                {
                    t.SetUID(GenerateUID(uids));
                }
                uids.Add(t.UID);
            }
        }
        private int GenerateUID(List<int> uids)
        {
            int uid;
            do
            {
                uid = Random.Range(1, 10000);
            } while(uids.Contains(uid));
            return uid;
        }
        #endregion

        #region Getters
        public BaseStyleSheet GetStyleSheet(int uid, StyleSheetType type)
        {
            return type switch
            {
                StyleSheetType.TEXT => TextStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.BACKGROUND_IMAGE => BackgroundImageStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.ICON_IMAGE => IconImageStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.BUTTON => ButtonStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.TOGGLE => ToggleStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.DROPDOWN_ITEM_TOGGLE => DropdownItemToggleStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.SWITCH_TOGGLE => SwitchToggleStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.SLIDER => SliderStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.DROPDOWN => DropdownStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.INPUT_FIELD => InputfieldStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.SCROLLBAR => ScrollbarStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.SCROLL_VIEW => ScrollViewStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.SCROLL_LIST => ScrollListStyleSheets.Find(s => s.UID == uid),
                StyleSheetType.POPUP => PopupStyleSheets.Find(s => s.UID == uid),
                _ => null
            };
        }

        public List<BaseStyleSheet> GetStyleSheetByType(StyleSheetType type)
        {
            return type switch
            {
                StyleSheetType.TEXT => TextStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.BACKGROUND_IMAGE => BackgroundImageStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.ICON_IMAGE => IconImageStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.BUTTON => ButtonStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.TOGGLE => ToggleStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.DROPDOWN_ITEM_TOGGLE => DropdownItemToggleStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.SWITCH_TOGGLE => SwitchToggleStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.SLIDER => SliderStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.DROPDOWN => DropdownStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.INPUT_FIELD => InputfieldStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.SCROLLBAR => ScrollbarStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.SCROLL_VIEW => ScrollViewStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.SCROLL_LIST => ScrollListStyleSheets.Cast<BaseStyleSheet>().ToList(),
                StyleSheetType.POPUP => PopupStyleSheets.Cast<BaseStyleSheet>().ToList(),
                _ => null
            };
        }

        public List<string> StyleSheetStrings(List<BaseStyleSheet> styleSheets)
        {
            List<string> list = new();
            foreach (var var in styleSheets)
            {
                if (var.UID != 0)
                    list.Add(var.Name);
                else
                    list.Add("No unique ID");
            }
            return list;
        }
        #endregion
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

        [Header("Animation Transition")]
        public AnimationTriggers animationTriggers = new();
    }

    [System.Serializable]
    public class ImageStyleSheet : BaseStyleSheet
    {
        public Sprite baseSprite;
        public Color baseColor = Color.white;
        public Material baseMaterial;
        [Space]
        public Image.Type imageType;
        [Range(0, 10)] public float pixelsPerUnit = 1;
        [Header("Transition")]
        public bool isStatic = true;
        //[HideIf(nameof(isStatic))][AllowNesting]
        public TransitionStyleSheet transition;
    }

    [System.Serializable]
    public struct GradientTransition
    {
        public VertexGradient normalGradient;
        public VertexGradient highlightedGradient;
        public VertexGradient pressedGradient;
        public VertexGradient selectedGradient;
        public VertexGradient disabledGradient;
    }

    [System.Serializable]
    public class TextStyleSheet : BaseStyleSheet
    {
        public TMP_FontAsset font;
        public FontStyles fontStyle;
        public bool overrideAlignment;
        public TextAlignmentOptions alignment;

        [Header("Color")]
        public bool isGradient = false; bool IsNotGradient => !isGradient;
        public bool isStatic = true; bool IsNotStatic => !isStatic;

        [ShowIf(EConditionOperator.And, nameof(IsNotGradient), nameof(isStatic))][AllowNesting] 
        public Color color = Color.black;
        [ShowIf(EConditionOperator.And, nameof(isGradient), nameof(isStatic))][AllowNesting] 
        public VertexGradient colorGradient;

        [ShowIf(EConditionOperator.And, nameof(IsNotGradient), nameof(IsNotStatic))][AllowNesting] 
        public ColorBlock colorTransition;
        [ShowIf(EConditionOperator.And, nameof(isGradient), nameof(IsNotStatic))][AllowNesting]
        public GradientTransition gradientTransition;
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

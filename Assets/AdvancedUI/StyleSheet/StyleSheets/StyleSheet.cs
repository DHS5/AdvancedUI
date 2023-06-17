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

        [SerializeField] private List<TextStyleSheet> TextStyleSheets;
        [SerializeField] private List<ImageStyleSheet> BackgroundImageStyleSheets;
        [SerializeField] private List<ImageStyleSheet> IconImageStyleSheets;
        [SerializeField] private List<ButtonStyleSheet> ButtonStyleSheets;
        [SerializeField] private List<ToggleStyleSheet> ToggleStyleSheets;
        [SerializeField] private List<DropdownItemToggleStyleSheet> DropdownItemToggleStyleSheets;
        [SerializeField] private List<SwitchToggleStyleSheet> SwitchToggleStyleSheets;
        [SerializeField] private List<SliderStyleSheet> SliderStyleSheets;
        [SerializeField] private List<DropdownStyleSheet> DropdownStyleSheets;
        [SerializeField] private List<InputfieldStyleSheet> InputfieldStyleSheets;
        [SerializeField] private List<ScrollbarStyleSheet> ScrollbarStyleSheets;
        [SerializeField] private List<ScrollViewStyleSheet> ScrollViewStyleSheets;
        [SerializeField] private List<ScrollListStyleSheet> ScrollListStyleSheets;
        [SerializeField] private List<PopupStyleSheet> PopupStyleSheets;

        
        #region SetUp Style Sheets
        private void OnValidate()
        {
            SetUp();
        }

        private void SetUp()
        {
            TextStyleSheets.SetUp(container);
            BackgroundImageStyleSheets.SetUp(container);
            IconImageStyleSheets.SetUp(container);
            ButtonStyleSheets.SetUp(container);
            ToggleStyleSheets.SetUp(container);
            DropdownItemToggleStyleSheets.SetUp(container);
            SwitchToggleStyleSheets.SetUp(container);
            SliderStyleSheets.SetUp(container);
            DropdownStyleSheets.SetUp(container);
            InputfieldStyleSheets.SetUp(container);
            ScrollbarStyleSheets.SetUp(container);
            ScrollViewStyleSheets.SetUp(container);
            ScrollListStyleSheets.SetUp(container);
            PopupStyleSheets.SetUp(container);
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
        /// <summary>
        /// Deprecated
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public BaseStyleSheet GetStyleSheet(int uid)
        {
            BaseStyleSheet result;

            result = TextStyleSheets.Find(s => s.UID == uid);
            result ??= BackgroundImageStyleSheets.Find(s => s.UID == uid);
            result ??= IconImageStyleSheets.Find(s => s.UID == uid);
            result ??= ButtonStyleSheets.Find(s => s.UID == uid);
            result ??= ToggleStyleSheets.Find(s => s.UID == uid);
            result ??= DropdownItemToggleStyleSheets.Find(s => s.UID == uid);
            result ??= SwitchToggleStyleSheets.Find(s => s.UID == uid);
            result ??= SliderStyleSheets.Find(s => s.UID == uid);
            result ??= DropdownStyleSheets.Find(s => s.UID == uid);
            result ??= InputfieldStyleSheets.Find(s => s.UID == uid);
            result ??= ScrollbarStyleSheets.Find(s => s.UID == uid);
            result ??= ScrollViewStyleSheets.Find(s => s.UID == uid);
            result ??= ScrollListStyleSheets.Find(s => s.UID == uid);
            result ??= PopupStyleSheets.Find(s => s.UID == uid);

            return result;
        }

        #endregion

        #region Setters
        public void SetStyleSheet(StyleSheetType type, BaseStyleSheet newStyleSheet)
        {
            switch(type)
            {
                case StyleSheetType.TEXT:
                    SetStyleSheet(TextStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.BACKGROUND_IMAGE:
                    SetStyleSheet(BackgroundImageStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.ICON_IMAGE:
                    SetStyleSheet(IconImageStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.BUTTON:
                    SetStyleSheet(ButtonStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.TOGGLE:
                    SetStyleSheet(ToggleStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.DROPDOWN_ITEM_TOGGLE:
                    SetStyleSheet(DropdownItemToggleStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.SWITCH_TOGGLE:
                    SetStyleSheet(SwitchToggleStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.SLIDER:
                    SetStyleSheet(SliderStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.DROPDOWN:
                    SetStyleSheet(DropdownStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.INPUT_FIELD:
                    SetStyleSheet(InputfieldStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.SCROLLBAR:
                    SetStyleSheet(ScrollbarStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.SCROLL_VIEW:
                    SetStyleSheet(ScrollViewStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.SCROLL_LIST:
                    SetStyleSheet(ScrollListStyleSheets, newStyleSheet);
                    break;
                case StyleSheetType.POPUP:
                    SetStyleSheet(PopupStyleSheets, newStyleSheet);
                    break;
            };
        }
        private void SetStyleSheet<T>(List<T> list, BaseStyleSheet newStyleSheet) where T : BaseStyleSheet
        {
            int index = list.FindIndex(s => s.UID == newStyleSheet.UID);
            if (index == -1)
            {
                Debug.LogError("Index = -1 " + (list.Count > 0 ? ("elem 0 " + list[0].UID + " " + list[0].Name) : "count : " + list.Count));
                return;
            }

            list[index].Copy(newStyleSheet);
        }
        #endregion

        #region List template management
        public void ApplyTemplate()
        {
            if (container == null) return;
            TextStyleSheets = ApplyTemplate(TextStyleSheets, container.Texts);
            BackgroundImageStyleSheets = ApplyTemplate(BackgroundImageStyleSheets, container.Backgrounds);
            IconImageStyleSheets = ApplyTemplate(IconImageStyleSheets, container.Icons);
            ButtonStyleSheets = ApplyTemplate(ButtonStyleSheets, container.Buttons);
            ToggleStyleSheets = ApplyTemplate(ToggleStyleSheets, container.Toggles);
            DropdownItemToggleStyleSheets = ApplyTemplate(DropdownItemToggleStyleSheets, container.DropdownItems);
            SwitchToggleStyleSheets = ApplyTemplate(SwitchToggleStyleSheets, container.Switchs);
            SliderStyleSheets = ApplyTemplate(SliderStyleSheets, container.Sliders);
            DropdownStyleSheets = ApplyTemplate(DropdownStyleSheets, container.Dropdowns);
            InputfieldStyleSheets = ApplyTemplate(InputfieldStyleSheets, container.InputFields);
            ScrollbarStyleSheets = ApplyTemplate(ScrollbarStyleSheets, container.Scrollbars);
            ScrollViewStyleSheets = ApplyTemplate(ScrollViewStyleSheets, container.ScrollViews);
            ScrollListStyleSheets = ApplyTemplate(ScrollListStyleSheets, container.ScrollLists);
            PopupStyleSheets = ApplyTemplate(PopupStyleSheets, container.Popups);

            SetUp();
        }
        private List<T> ApplyTemplate<T>(List<T> list, List<StyleSheetPlaceholder> placeholders) where T : BaseStyleSheet, new()
        {
            T temp;
            Dictionary<int, int> indexes = new();

            List<T> newList = new();
            for (int i = 0; i < placeholders.Count; i++)
            {
                temp = new();
                temp.SetInfos(placeholders[i].UID, placeholders[i].Name);
                newList.Add(temp);
                indexes[placeholders[i].UID] = i;
            }

            foreach (var var in list)
            {
                if (indexes.ContainsKey(var.UID))
                {
                    newList[indexes[var.UID]] = var;
                }
            }

            return newList;
        }
        #endregion
    }

    #region Base Style Sheets

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
        public float ratio = 1;
        [Header("Transition")]
        public bool isStatic = true;
        public TransitionStyleSheet transition;

        public override List<StyleSheetPlaceholder> GetDependencies()
        {
            return null;
        }
        protected override void CopyStyleSheet(BaseStyleSheet s)
        {
            ImageStyleSheet i = (ImageStyleSheet)s;
            if (i == null) return;

            baseSprite = i.baseSprite;
            baseColor = i.baseColor;
            baseMaterial = i.baseMaterial;
            imageType = i.imageType;
            pixelsPerUnit = i.pixelsPerUnit;
            ratio = i.ratio;
            isStatic = i.isStatic;
            transition = i.transition;
        }
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

        public override List<StyleSheetPlaceholder> GetDependencies()
        {
            return null;
        }
        protected override void CopyStyleSheet(BaseStyleSheet s)
        {
            TextStyleSheet t = (TextStyleSheet)s;
            if (t == null) return;

            font = t.font;
            fontStyle = t.fontStyle;
            overrideAlignment = t.overrideAlignment;
            alignment = t.alignment;
            isGradient = t.isGradient;
            isStatic = t.isStatic;
            color = t.color;
            colorGradient = t.colorGradient;
            colorTransition = t.colorTransition;
            gradientTransition = t.gradientTransition;
        }
    }
    #endregion

    #region Override Sheets
    [System.Serializable]
    public class ImageOverrideSheet
    {
        public bool overrideSprite;
        public Sprite sprite;

        public bool overrideColor;
        public Color color = Color.white;

        public bool overrideMaterial;
        public Material material;

        public bool overrideImageType;
        public Image.Type imageType;
        [Range(0, 10)] public float pixelsPerUnit = 1;

        public bool overrideScale;
        public float scale = 1;
        public bool overrideRatio;
        public float ratio = 1;

        public bool overrideTransition;
        public bool isStatic = true;
        public TransitionStyleSheet transition;
    }

    [System.Serializable]
    public class TextOverrideSheet
    {
        public bool overrideFont;
        public TMP_FontAsset font;
        public FontStyles fontStyle;

        public bool overrideAlignment;
        public TextAlignmentOptions alignment;

        public bool overrideColor;
        public bool isGradient = false;
        public bool isStatic = true;

        public Color color = Color.black;
        public VertexGradient colorGradient;

        public ColorBlock colorTransition;
        public GradientTransition gradientTransition;
    }
    #endregion
}

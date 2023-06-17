using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

namespace Dhs5.AdvancedUI
{
    /// <summary>
    /// StyleSheet Scriptable Object containing the style options for every AdvancedUI components
    /// </summary>
    [CreateAssetMenu(fileName = "StyleSheet Container", menuName = "AdvancedUI/StyleSheet/Container", order = 0)]
    public class StyleSheetContainer : ScriptableObject
    {
        public StyleSheet projectStyleSheet;

        [Space(25), Header("Template")]
        [SerializeField] private List<StyleSheetPlaceholder> textSS;
        [SerializeField] private List<StyleSheetPlaceholder> backgroundSS;
        [SerializeField] private List<StyleSheetPlaceholder> iconSS;
        [SerializeField] private List<StyleSheetPlaceholder> buttonSS;
        [SerializeField] private List<StyleSheetPlaceholder> toggleSS;
        [SerializeField] private List<StyleSheetPlaceholder> dropdownItemToggleSS;
        [SerializeField] private List<StyleSheetPlaceholder> switchToggleSS;
        [SerializeField] private List<StyleSheetPlaceholder> sliderSS;
        [SerializeField] private List<StyleSheetPlaceholder> dropdownSS;
        [SerializeField] private List<StyleSheetPlaceholder> inputfieldSS;
        [SerializeField] private List<StyleSheetPlaceholder> scrollbarSS;
        [SerializeField] private List<StyleSheetPlaceholder> scrollviewSS;
        [SerializeField] private List<StyleSheetPlaceholder> scrolllistSS;
        [SerializeField] private List<StyleSheetPlaceholder> popupSS;
        
        public List<List<StyleSheetPlaceholder>> MainList
        {
            get
            {
                List<List<StyleSheetPlaceholder>> list = new();
                list.Add(Texts);
                list.Add(Backgrounds);
                list.Add(Icons);
                list.Add(Buttons);
                list.Add(Toggles);
                list.Add(DropdownItems);
                list.Add(Switchs);
                list.Add(Sliders);
                list.Add(Dropdowns);
                list.Add(InputFields);
                list.Add(Scrollbars);
                list.Add(ScrollViews);
                list.Add(ScrollLists);
                list.Add(Popups);

                return list;
            }
        }
        public List<StyleSheetPlaceholder> CompleteList
        {
            get
            {
                List<StyleSheetPlaceholder> list = new();
                list.AddRange(Texts);
                list.AddRange(Backgrounds);
                list.AddRange(Icons);
                list.AddRange(Buttons);
                list.AddRange(Toggles);
                list.AddRange(DropdownItems);
                list.AddRange(Switchs);
                list.AddRange(Sliders);
                list.AddRange(Dropdowns);
                list.AddRange(InputFields);
                list.AddRange(Scrollbars);
                list.AddRange(ScrollViews);
                list.AddRange(ScrollLists);
                list.AddRange(Popups);

                return list;
            }
        }
        public List<string> ListNames
        {
            get
            {
                List<string> list = new();
                list.Add("Texts");
                list.Add("Backgrounds");
                list.Add("Icons");
                list.Add("Buttons");
                list.Add("Toggles");
                list.Add("DropdownItems");
                list.Add("Switchs");
                list.Add("Sliders");
                list.Add("Dropdowns");
                list.Add("InputFields");
                list.Add("Scrollbars");
                list.Add("ScrollViews");
                list.Add("ScrollLists");
                list.Add("Popups");

                return list;
            }
        }

        public List<StyleSheetPlaceholder> Texts => textSS;
        public List<StyleSheetPlaceholder> Backgrounds => backgroundSS;
        public List<StyleSheetPlaceholder> Icons => iconSS;
        public List<StyleSheetPlaceholder> Buttons => buttonSS;
        public List<StyleSheetPlaceholder> Toggles => toggleSS;
        public List<StyleSheetPlaceholder> DropdownItems => dropdownItemToggleSS;
        public List<StyleSheetPlaceholder> Switchs => switchToggleSS;
        public List<StyleSheetPlaceholder> Sliders => sliderSS;
        public List<StyleSheetPlaceholder> Dropdowns => dropdownSS;
        public List<StyleSheetPlaceholder> InputFields => inputfieldSS;
        public List<StyleSheetPlaceholder> Scrollbars => scrollbarSS;
        public List<StyleSheetPlaceholder> ScrollViews => scrollviewSS;
        public List<StyleSheetPlaceholder> ScrollLists => scrolllistSS;
        public List<StyleSheetPlaceholder> Popups => popupSS;

        #region UID management
        private void OnValidate()
        {
            SetUIDs(Texts, StyleSheetType.TEXT);
            SetUIDs(Backgrounds, StyleSheetType.BACKGROUND_IMAGE);
            SetUIDs(Icons, StyleSheetType.ICON_IMAGE);
            SetUIDs(Buttons, StyleSheetType.BUTTON);
            SetUIDs(Toggles, StyleSheetType.TOGGLE);
            SetUIDs(DropdownItems, StyleSheetType.DROPDOWN_ITEM_TOGGLE);
            SetUIDs(Switchs, StyleSheetType.SWITCH_TOGGLE);
            SetUIDs(Sliders, StyleSheetType.SLIDER);
            SetUIDs(Dropdowns, StyleSheetType.DROPDOWN);
            SetUIDs(InputFields, StyleSheetType.INPUT_FIELD);
            SetUIDs(Scrollbars, StyleSheetType.SCROLLBAR);
            SetUIDs(ScrollViews, StyleSheetType.SCROLL_VIEW);
            SetUIDs(ScrollLists, StyleSheetType.SCROLL_LIST);
            SetUIDs(Popups, StyleSheetType.POPUP);
        }

        private void SetUIDs(List<StyleSheetPlaceholder> list, StyleSheetType type)
        {
            if (list == null || list.Count < 1) return;

            List<int> uids = new();
            foreach (var t in list)
            {
                t.type = type;
                if (uids.Contains(t.UID) || t.UID == 0)
                {
                    t.UID = GenerateUID(uids);
                }
                uids.Add(t.UID);
            }
        }
        /// <summary>
        /// Deprecated
        /// </summary>
        private void SetUIDs()
        {
            List<StyleSheetPlaceholder> list = CompleteList;
            if (list == null || list.Count < 1) return;

            List<int> uids = new();
            foreach (var t in list)
            {
                if (uids.Contains(t.UID) || t.UID == 0)
                {
                    t.UID = GenerateUID(uids);
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
            } while (uids.Contains(uid));
            return uid;
        }
        #endregion

        #region Getters

        public List<StyleSheetPlaceholder> GetStyleSheetByType(StyleSheetType type)
        {
            return type switch
            {
                StyleSheetType.TEXT => Texts,
                StyleSheetType.BACKGROUND_IMAGE => Backgrounds,
                StyleSheetType.ICON_IMAGE => Icons,
                StyleSheetType.BUTTON => Buttons,
                StyleSheetType.TOGGLE => Toggles,
                StyleSheetType.DROPDOWN_ITEM_TOGGLE => DropdownItems,
                StyleSheetType.SWITCH_TOGGLE => Switchs,
                StyleSheetType.SLIDER => Sliders,
                StyleSheetType.DROPDOWN => Dropdowns,
                StyleSheetType.INPUT_FIELD => InputFields,
                StyleSheetType.SCROLLBAR => Scrollbars,
                StyleSheetType.SCROLL_VIEW => ScrollViews,
                StyleSheetType.SCROLL_LIST => ScrollLists,
                StyleSheetType.POPUP => Popups,
                _ => null
            };
        }

        public List<string> StyleSheetNames(List<StyleSheetPlaceholder> styleSheets)
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

        public StyleSheetPlaceholder GetPlaceholder(StyleSheetType type, int UID)
        {
            return GetStyleSheetByType(type).Find(x => x.UID == UID);
        }

        #endregion

        #region Project Style Sheet change
        public List<AdvancedComponent> AdvancedComponents { get; private set; }
        public void RegisterAdvancedComponent(AdvancedComponent component)
        {
            if (AdvancedComponents == null) AdvancedComponents = new();

            if (!AdvancedComponents.Contains(component))
            {
                AdvancedComponents.Add(component);
            }
        }
        public void UnregisterAdvancedComponent(AdvancedComponent component)
        {
            if (AdvancedComponents == null)
            {
                AdvancedComponents = new();
                return;
            }

            AdvancedComponents.Remove(component);
        }
        public void ChangeStyleSheet(StyleSheet newProjectStyleSheet)
        {
            if (projectStyleSheet == newProjectStyleSheet || newProjectStyleSheet == null || newProjectStyleSheet.Container != this) return;

            projectStyleSheet = newProjectStyleSheet;

            foreach (var component in AdvancedComponents)
            {
                component.UpdateStyleSheet();
            }
        }
        #endregion
    }

    [System.Serializable]
    public class StyleSheetPlaceholder
    {
        [ReadOnly, AllowNesting] public int UID;

        [SerializeField] private string name;
        public string Name => name;

        public StyleSheetType type;
    }
}

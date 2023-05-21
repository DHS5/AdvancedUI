using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        [SerializeField] private List<BaseStyleSheet> Texts;
        [SerializeField] private List<BaseStyleSheet> Backgrounds;
        [SerializeField] private List<BaseStyleSheet> Icons;

        public List<KeyValuePair<string, List<BaseStyleSheet>>> StyleSheetLists()
        {
            List<KeyValuePair<string, List<BaseStyleSheet>>> list = new();

            list.Add(new(nameof(Texts), Texts));
            list.Add(new(nameof(Backgrounds), Backgrounds));
            list.Add(new(nameof(Icons), Icons));

            return list;
        }
    }
}

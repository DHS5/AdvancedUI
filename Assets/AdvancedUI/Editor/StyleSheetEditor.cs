using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

namespace Dhs5.AdvancedUI
{
    [CustomEditor(typeof(StyleSheet))]
    [CanEditMultipleObjects]
    public class StyleSheetEditor : Editor
    {
        StyleSheet styleSheet;
        StyleSheetContainer container;
        List<KeyValuePair<string, List<BaseStyleSheet>>> ssList;

        bool[] showFoldouts;

        KeyValuePair<string, List<BaseStyleSheet>> pair;

        private void OnEnable()
        {
            styleSheet = (StyleSheet)serializedObject.targetObject;
            container = styleSheet.Container;
            ssList = container.StyleSheetLists();

            // CREATE THE ADEQUATE STYLE SHEET

            showFoldouts = new bool[ssList.Count];
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();

            base.OnInspectorGUI();

            if (container == null) return;
            
            EditorGUILayout.Space(15);
            EditorGUILayout.BeginVertical();

            for (int i = 0; i < ssList.Count; i++)
            {
                pair = ssList[i];

                showFoldouts[i] = EditorGUILayout.Foldout(showFoldouts[i], pair.Key, true);
                if (showFoldouts[i])
                {
                    foreach (var var in pair.Value)
                    {
                        
                    }
                }
            }
            
            EditorGUILayout.EndVertical();

            UnityEditor.EditorUtility.SetDirty(target);
        }
    }
}

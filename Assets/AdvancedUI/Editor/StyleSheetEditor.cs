using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
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
        List<ReorderableList> reorderableLists;

        ReorderableList list;

        private void CreateReorderableList(string listPropertyName, KeyValuePair<string, List<BaseStyleSheet>> pair)
        {
            SerializedProperty textList = serializedObject.FindProperty(listPropertyName);
            list = new ReorderableList(serializedObject, textList, false, true, false, false)
            {
                drawHeaderCallback = rect =>
                {
                    EditorGUI.LabelField(rect, pair.Key);
                },

                drawElementCallback = (rect, index, active, focused) =>
                {
                    var element = textList.GetArrayElementAtIndex(index);

                    EditorGUI.indentLevel++;
                    EditorGUI.PropertyField(rect, element, new GUIContent(pair.Value[index].Name), true);
                    EditorGUI.indentLevel--;
                },

                elementHeightCallback = index =>
                {
                    var element = textList.GetArrayElementAtIndex(index);

                    return EditorGUI.GetPropertyHeight(element);
                }
            };
        }

        private void OnEnable()
        {
            styleSheet = (StyleSheet)serializedObject.targetObject;
            container = styleSheet.Container;
            ssList = container.StyleSheetLists();

            CreateReorderableList("TextStyleSheets", ssList[0]);

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
            
            list.DoLayoutList();
            
            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
            UnityEditor.EditorUtility.SetDirty(target);
        }
    }
}

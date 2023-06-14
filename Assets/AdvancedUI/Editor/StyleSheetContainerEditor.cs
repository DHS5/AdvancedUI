using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [CustomEditor(typeof(StyleSheetContainer))]
    public class StyleSheetContainerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space(20);

            if (GUI.Button(EditorGUILayout.GetControlRect(), "Import"))
            {
                StyleSheetImporter importer = EditorWindow.GetWindow(typeof(StyleSheetImporter)) as StyleSheetImporter;
                importer.importIn = target as StyleSheetContainer;
            }

            GUILayout.EndHorizontal();
        }
    }
}

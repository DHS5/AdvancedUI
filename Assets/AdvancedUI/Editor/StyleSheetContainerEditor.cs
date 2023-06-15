using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [CustomEditor(typeof(StyleSheetContainer))]
    public class StyleSheetContainerEditor : Editor
    {
        StyleSheetContainer container;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (container.projectStyleSheet != null && container != container.projectStyleSheet.Container)
            {
                container.projectStyleSheet = null;
            }

            EditorGUILayout.Space(20);

            if (GUI.Button(EditorGUILayout.GetControlRect(false), "Import from other Template"))
            {
                StyleSheetImporter importer = EditorWindow.GetWindow(typeof(StyleSheetImporter)) as StyleSheetImporter;
                importer.SetUp(target as StyleSheetContainer);
            }
        }

        private void OnEnable()
        {
            container = (StyleSheetContainer)target;
        }
    }
}

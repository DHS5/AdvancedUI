using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    public class StyleSheetImporter : EditorWindow
    {
        public StyleSheetContainer importIn;
        [SerializeField] private StyleSheetContainer importFrom;

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();

            EditorGUILayout.LabelField("Style Sheet Importer", EditorStyles.boldLabel);
            EditorGUILayout.Space(10);

            EditorGUILayout.LabelField("Import IN : ");
            EditorGUILayout.ObjectField(importIn, typeof(StyleSheetContainer), false);// as StyleSheetContainer;
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Import FROM : ");
            importFrom = EditorGUILayout.ObjectField(importFrom, typeof(StyleSheetContainer), false) as StyleSheetContainer;
            if (importFrom == importIn) importFrom = null;

            if (importIn != null && importFrom != null)
            {
                
            }

            EditorGUILayout.EndVertical();
        }

        ReorderableList list;
        private void CreateList(string listName, List<StyleSheetPlaceholder> placeholderList, List<StyleSheetPlaceholder> listToImportTo)
        {
            PlaceholderImporter importer;

            if (EditorGUILayout.Foldout(true, listName))
            {
                foreach (var p in placeholderList)
                {
                    importer = new PlaceholderImporter(p, listToImportTo);
                    //EditorGUILayout.PropertyField(importer.)
                }
            }
        }

        [System.Serializable]
        private class PlaceholderImporter
        {
            public PlaceholderImporter(StyleSheetPlaceholder _placeholderToImport, List<StyleSheetPlaceholder> _listToImportIn)
            {
                placeholderToImport = _placeholderToImport;
                listToImportIn = _listToImportIn;

                name = placeholderToImport.Name;
                UID = placeholderToImport.UID;
            }

            [SerializeField] private string name;
            [SerializeField] private int UID;

            private StyleSheetPlaceholder placeholderToImport;
            private List<StyleSheetPlaceholder> listToImportIn;

            public void Import()
            {
                if (placeholderToImport == null || listToImportIn == null) return;

                listToImportIn.Add(placeholderToImport);
            }
        }
    }
}

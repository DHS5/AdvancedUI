using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dhs5.AdvancedUI
{
    public class StyleSheetImporter : EditorWindow
    {
        private bool templateImporter;

        // Template
        [SerializeField] private StyleSheetContainer importIn;
        [SerializeField] private StyleSheetContainer importFrom;
        [SerializeField] private bool importInProjectStyleSheet;

        // Style Sheet
        [SerializeField] private StyleSheet ssImportIn;
        [SerializeField] private StyleSheet ssImportFrom;
        [SerializeField] private bool updateDependencies;

        Vector2 scrollViewPos = Vector2.zero;

        List<List<StyleSheetPlaceholder>> listFrom;
        List<List<StyleSheetPlaceholder>> listIn;
        List<string> names;

        private void OnGUI()
        {
            scrollViewPos = EditorGUILayout.BeginScrollView(scrollViewPos);
            EditorGUILayout.BeginVertical();

            if (templateImporter)
            {
                EditorGUILayout.LabelField("Style Sheet Template Importer", EditorStyles.boldLabel);
                EditorGUILayout.Space(10);

                EditorGUILayout.LabelField("Import IN : ");
                EditorGUILayout.ObjectField(importIn, typeof(StyleSheetContainer), false);
                importInProjectStyleSheet = EditorGUILayout.ToggleLeft("Import in Project Style Sheet", importInProjectStyleSheet);
                EditorGUILayout.Space(5);
                EditorGUILayout.LabelField("Import FROM : ");
                importFrom = EditorGUILayout.ObjectField(importFrom, typeof(StyleSheetContainer), false) as StyleSheetContainer;
                if (importFrom == importIn) importFrom = null;

                if (importIn != null && importFrom != null)
                {
                    listFrom ??= importFrom.MainList;

                    for (int i = 0; i < listFrom.Count; i++)
                    {
                        CreateTemplateList(i, names[i], listFrom[i], listIn[i]);
                    }
                }
            }
            else
            {
                EditorGUILayout.LabelField("Style Sheet Importer", EditorStyles.boldLabel);
                EditorGUILayout.Space(10);

                EditorGUILayout.LabelField("Template : ");
                EditorGUILayout.ObjectField(importIn, typeof(StyleSheetContainer), false);
                EditorGUILayout.Space(10);

                EditorGUILayout.LabelField("Import IN : ");
                EditorGUILayout.ObjectField(ssImportIn, typeof(StyleSheet), false);
                updateDependencies = EditorGUILayout.ToggleLeft("Update the dependencies too", updateDependencies);
                EditorGUILayout.Space(5);

                EditorGUILayout.LabelField("Import FROM : ");
                ssImportFrom = EditorGUILayout.ObjectField(ssImportFrom, typeof(StyleSheet), false) as StyleSheet;
                if (ssImportFrom == ssImportIn || (ssImportFrom != null && ssImportFrom.Container != importIn)) ssImportFrom = null;

                if (ssImportIn != null && ssImportFrom != null)
                {
                    for (int i = 0; i < listIn.Count; i++)
                    {
                        CreateStyleSheetList(i, names[i], listIn[i]);
                    }
                }
            }

            EditorGUILayout.EndVertical();
            EditorGUILayout.EndScrollView();
        }

        public void SetUp(StyleSheetContainer _importIn)
        {
            templateImporter = true;
            importIn = _importIn;
            listIn = importIn.MainList;
            foldoutsOpen = new bool[listIn.Count];
            names = importIn.ListNames;
        }
        public void SetUp(StyleSheet _importIn)
        {
            templateImporter = false;
            ssImportIn = _importIn;
            importIn = ssImportIn.Container;
            listIn = importIn.MainList;
            foldoutsOpen = new bool[listIn.Count];
            names = importIn.ListNames;
        }

        bool[] foldoutsOpen;
        private void CreateTemplateList(int index, string listName, List<StyleSheetPlaceholder> placeholderList, List<StyleSheetPlaceholder> listToImportIn)
        {
            foldoutsOpen[index] = EditorGUILayout.Foldout(foldoutsOpen[index], listName);
            if (foldoutsOpen[index])
            {
                foreach (var p in placeholderList)
                {
                    if (listToImportIn.Find(x => x.UID == p.UID) == null)
                    {
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.LabelField(p.Name);
                        if (GUI.Button(EditorGUILayout.GetControlRect(false), "Import"))
                        {
                            Import(p, listToImportIn);
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                }
            }
        }
        private void CreateStyleSheetList(int index, string listName, List<StyleSheetPlaceholder> placeholderList)
        {
            foldoutsOpen[index] = EditorGUILayout.Foldout(foldoutsOpen[index], listName);
            if (foldoutsOpen[index])
            {
                foreach (var p in placeholderList)
                {
                    BaseStyleSheet styleSheetFrom = ssImportFrom.GetStyleSheet(p.UID, p.type);
                    BaseStyleSheet styleSheetIn = ssImportIn.GetStyleSheet(p.UID, p.type);

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(p.Name);

                    EditorGUI.BeginDisabledGroup(styleSheetFrom == styleSheetIn);
                    if (GUI.Button(EditorGUILayout.GetControlRect(false), "Import"))
                    {
                        ssImportIn.SetStyleSheet(p.type, styleSheetFrom);

                        if (updateDependencies)
                        {
                            UpdateDependencies(styleSheetFrom.GetDependencies());
                        }
                    }
                    EditorGUI.EndDisabledGroup();

                    EditorGUILayout.EndHorizontal();
                }
            }
        }

        private void Import(StyleSheetPlaceholder placeholderToImport, List<StyleSheetPlaceholder> listToImportIn)
        {
            if (placeholderToImport == null || listToImportIn == null) return;

            listToImportIn.Add(placeholderToImport);

            if (importInProjectStyleSheet && importIn.projectStyleSheet != null && importFrom.projectStyleSheet != null)
            {
                importIn.projectStyleSheet.ApplyTemplate();

                BaseStyleSheet styleSheet = importFrom.projectStyleSheet.GetStyleSheet(placeholderToImport.UID, placeholderToImport.type);

                importIn.projectStyleSheet.SetStyleSheet(placeholderToImport.type, styleSheet);

                List<StyleSheetPlaceholder> dependencies = styleSheet.GetDependencies();
                if (dependencies != null && dependencies.Count > 0)
                {
                    foreach (StyleSheetPlaceholder dependency in dependencies)
                    {
                        listToImportIn = importIn.GetStyleSheetByType(dependency.type);

                        if (listToImportIn.Find(x => x.UID == dependency.UID) == null)
                        {
                            Import(dependency, listToImportIn);
                        }
                    }
                }
            }
        }

        private void UpdateDependencies(List<StyleSheetPlaceholder> dependencies)
        {
            if (dependencies == null || dependencies.Count == 0) return;

            BaseStyleSheet styleSheetFrom;
            BaseStyleSheet styleSheetIn;

            foreach (StyleSheetPlaceholder dependency in dependencies)
            {
                styleSheetFrom = ssImportFrom.GetStyleSheet(dependency.UID, dependency.type);
                styleSheetIn = ssImportIn.GetStyleSheet(dependency.UID, dependency.type);

                ssImportIn.SetStyleSheet(dependency.type, styleSheetFrom);

                UpdateDependencies(styleSheetFrom.GetDependencies());
            }
        }
    }
}

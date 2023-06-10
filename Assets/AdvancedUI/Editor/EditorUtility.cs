using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Dhs5.Utility.SaveSystem;

namespace Dhs5.AdvancedUI
{
    public static class EditorUtility
    {
        private static Object SSContainer
        {
            get 
            {
                Object container = AssetDatabase.LoadAssetAtPath("Assets/AdvancedUI/StyleSheet/StyleSheet Container.asset",
                typeof(StyleSheetContainer));
                if (container == null)
                {
                    container = ScriptableObject.CreateInstance<StyleSheetContainer>();
                    AssetDatabase.CreateAsset(container, "Assets/AdvancedUI/StyleSheet/StyleSheet Container.asset");
                }
                return container;
            }
        }

        [MenuItem("Window/Advanced UI/Style Sheet Container", priority = 0)]
        private static void GetStyleSheetContainer()
        {
            Selection.activeObject = SSContainer;
        }
        
        [MenuItem("Window/Advanced UI/Current Style Sheet %&S", priority = 1)]
        private static void GetCurrentStyleSheet()
        {
            StyleSheetContainer container = SSContainer as StyleSheetContainer;
            if (container.projectStyleSheet != null)
                Selection.activeObject = container.projectStyleSheet;
        }

        [MenuItem("Window/Advanced UI/UI Sprite", priority = 0)]
        private static void CreateUISprite()
        {
            Sprite original = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            if (original != null)
            {
                Debug.Log("not null");
                Texture2D copy = original.texture;
                Debug.Log(AssetDatabase.GetAssetPath(740));

                SaveSystem.SaveTexture2D(copy, "UISprite");
                Debug.Log(Application.persistentDataPath);
                //Sprite copy = Sprite.Create(original.texture, original.rect, original.pivot);
                //AssetDatabase.CreateAsset(copy, "Assets/AdvancedUI/UISpriteCopy.asset");
            }
            else
            {
                Debug.Log("null");
            }
        }
    }
}

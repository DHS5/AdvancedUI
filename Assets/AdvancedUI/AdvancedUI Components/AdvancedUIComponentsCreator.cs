using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Dhs5.AdvancedUI
{
    public static class AdvancedUIComponentsCreator
    {
        private static void CreateAdvancedUIObject(string path)
        {
            GameObject go = (GameObject)AssetDatabase.LoadAssetAtPath(path, typeof(GameObject));
            GameObject obj = PrefabUtility.InstantiatePrefab(go, Selection.activeTransform) as GameObject;
            Selection.activeGameObject = obj;
        }

        #region Buttons

        // ### Buttons ###

        [MenuItem("GameObject/UI/AdvancedUI/Buttons/Button")]
        public static void CreateSimpleButton()
        {
            CreateAdvancedUIObject("Assets/AdvancedUI/AdvancedUI Prefabs/AdvancedButton.prefab");
        }
        
        [MenuItem("GameObject/UI/AdvancedUI/Buttons/PopUp Button")]
        public static void CreatePopupButton()
        {
            CreateAdvancedUIObject("Assets/AdvancedUI/AdvancedUI Prefabs/PopUp Button.prefab");
        }

        #endregion

        #region Toggles

        // ### Toggles ###

        [MenuItem("GameObject/UI/AdvancedUI/Toggles/Toggle")]
        public static void CreateSimpleToggle()
        {
            CreateAdvancedUIObject("Assets/AdvancedUI/AdvancedUI Prefabs/AdvancedToggle.prefab");
        }

        #endregion

        #region Sliders

        // ### Sliders ###

        [MenuItem("GameObject/UI/AdvancedUI/Sliders/Slider")]
        public static void CreateSimpleSlider()
        {
            CreateAdvancedUIObject("Assets/AdvancedUI/AdvancedUI Prefabs/AdvancedSlider.prefab");
        }

        #endregion

        #region Popup

        // ### Popup ###

        [MenuItem("GameObject/UI/AdvancedUI/PopUps/PopUp")]
        public static void CreateSimplePopup()
        {
            CreateAdvancedUIObject("Assets/AdvancedUI/AdvancedUI Prefabs/PopUp.prefab");
        }

        #endregion
    }
}

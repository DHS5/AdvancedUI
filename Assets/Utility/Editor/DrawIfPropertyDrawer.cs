using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Dhs5.Utility.EditorTools
{
    [CustomPropertyDrawer(typeof(DrawIfAttribute))]
    public class DrawIfPropertyDrawer : PropertyDrawer
    {
        DrawIfAttribute drawIfAttribute;
        bool condition;

        float propertyHeight;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            drawIfAttribute = attribute as DrawIfAttribute;
            SerializedProperty boolProperty = property.serializedObject.FindProperty(drawIfAttribute.PropertyName);

            propertyHeight = base.GetPropertyHeight(property, label);

            if (boolProperty != null && boolProperty.type == "bool")
            {
                condition = boolProperty.boolValue;

                EditorGUI.BeginProperty(position, label, property);

                if (condition)
                {
                    EditorGUI.PropertyField(position, property, label, true);
                }
                else
                {
                    if (drawIfAttribute.HidingType == HidingType.READ_ONLY)
                    {
                        GUI.enabled = false;
                        EditorGUI.PropertyField(position, property, label, true);
                        GUI.enabled = true;
                    }
                    else
                    {
                        propertyHeight = 0f;
                    }
                }

                EditorGUI.EndProperty();
            }
            else
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return propertyHeight;
        }
    }
}

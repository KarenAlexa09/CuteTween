using UnityEditor;
using UnityEngine;

namespace KarenAlexa09.CuteTween.Editor
{
    [CustomPropertyDrawer(typeof(CuteAnimationBase), true)]
    public class CuteAnimationDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property == null)
            {
                EditorGUI.LabelField(position, "No Animation Assigned");
                return;
            }

            EditorGUI.BeginProperty(position, label, property);

            SerializedObject serializedObject = property.serializedObject;
            serializedObject.Update();

            SerializedProperty iterator = property.Copy();

            bool enterChildren = true;
            bool hasNext = iterator.NextVisible(enterChildren); 

            Rect foldoutRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label, true);

            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;

                float y = position.y + EditorGUIUtility.singleLineHeight + 2f;
                float fieldHeight = EditorGUIUtility.singleLineHeight;
                float spacing = 2f;

                while (hasNext)
                {
                    if (iterator.depth == property.depth + 1)
                    {
                        Rect fieldRect = new Rect(position.x, y, position.width, fieldHeight);
                        EditorGUI.PropertyField(fieldRect, iterator, true);
                        y += fieldHeight + spacing;
                    }

                    if (!iterator.NextVisible(false)) break;
                }

                EditorGUI.indentLevel--;
            }

            serializedObject.ApplyModifiedProperties();
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property == null)
                return EditorGUIUtility.singleLineHeight;

            if (!property.isExpanded)
                return EditorGUIUtility.singleLineHeight;

            SerializedProperty iterator = property.Copy();

            int fieldCount = 0;
            float totalHeight = EditorGUIUtility.singleLineHeight + 2f;
            float fieldHeight = EditorGUIUtility.singleLineHeight;
            float spacing = 2f;

            bool hasProperties = iterator.NextVisible(true);
            if (hasProperties)
            {
                do
                {
                    if (iterator.depth == property.depth + 1)
                    {
                        fieldCount++;
                        totalHeight += fieldHeight + spacing;
                    }
                } while (iterator.NextVisible(false));
            }

            return totalHeight;
        }
    }
}

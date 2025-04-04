using UnityEditor;
using UnityEngine;

namespace KarenAlexa09.CuteTween.Editor
{
    [CustomPropertyDrawer(typeof(CuteTween))]
    public class CuteTweenDrawer : PropertyDrawer
    {
        private static readonly Color PINK_BG_COLOR = new Color(0.95f, 0.6f, 0.8f, 0.3f);
        private static readonly Color PINK_HEADER_COLOR = new Color(0.65f, 0.53f, 1, 0.3f);

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            Rect dropdownRect = new Rect(
                position.x,
                position.y,
                position.width,
                EditorGUIUtility.singleLineHeight + 4
            );

            bool isExpanded = property.isExpanded;
            DrawDropdownHeader(dropdownRect, ref isExpanded, label);
            property.isExpanded = isExpanded;

            if (isExpanded)
            {
                Rect contentRect = new Rect(
                    position.x + 4,
                    dropdownRect.y + dropdownRect.height + 2,
                    position.width - 8,
                    GetPropertyHeight(property, label) - dropdownRect.height
                );

                EditorGUI.DrawRect(
                    new Rect(contentRect.x - 2, contentRect.y - 2, contentRect.width + 4, contentRect.height + 4),
                    PINK_BG_COLOR
                );

                float yOffset = contentRect.y;

                SerializedProperty selectedAnimationProp = property.FindPropertyRelative("selectedAnimation");
                DrawAnimationSelector(contentRect, selectedAnimationProp, ref yOffset);

                SerializedProperty animationProp = property.FindPropertyRelative("animation");

                AnimationType selectedType = (AnimationType)selectedAnimationProp.enumValueIndex;
                if (animationProp.managedReferenceValue == null ||
                    ((CuteAnimationBase)animationProp.managedReferenceValue).GetType() != AnimationFactory.GetAnimationType(selectedType))
                {
                    animationProp.managedReferenceValue = AnimationFactory.CreateAnimation(selectedType);
                    property.serializedObject.ApplyModifiedProperties();
                }

                Rect animRect = new Rect(
                    contentRect.x,
                    yOffset,
                    contentRect.width,
                    EditorGUI.GetPropertyHeight(animationProp, label, true)
                );

                EditorGUI.PropertyField(animRect, animationProp, new GUIContent("Animation Settings"), true);
            }

            EditorGUI.EndProperty();
        }

        private void DrawDropdownHeader(Rect rect, ref bool isExpanded, GUIContent label)
        {
            EditorGUI.DrawRect(rect, PINK_HEADER_COLOR);

            Rect foldoutRect = new Rect(
                rect.x + 2,
                rect.y + 2,
                rect.width - 4,
                EditorGUIUtility.singleLineHeight
            );

            isExpanded = EditorGUI.Foldout(foldoutRect, isExpanded, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = EditorGUIUtility.singleLineHeight + 6;

            if (property.isExpanded)
            {
                height += 4;
                SerializedProperty animationProp = property.FindPropertyRelative("animation");
                height += EditorGUIUtility.singleLineHeight + 2; 
                height += EditorGUI.GetPropertyHeight(animationProp, new GUIContent("Animation Settings"), true);
            }

            return height;
        }

        private void DrawAnimationSelector(Rect position, SerializedProperty prop, ref float yOffset)
        {
            Rect rect = new Rect(position.x, yOffset, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(rect, prop);
            yOffset += EditorGUIUtility.singleLineHeight + 2;
        }
    }
}

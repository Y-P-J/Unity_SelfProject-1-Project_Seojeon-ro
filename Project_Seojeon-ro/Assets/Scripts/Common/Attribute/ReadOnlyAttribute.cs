using UnityEditor;
using UnityEngine;

// ReadOnlyAttribute라는 사용자 정의 속성(Attribute)을 정의합니다.
public class ReadOnlyAttribute : PropertyAttribute { }

#if UNITY_EDITOR
// ReadOnlyAttribute에 대한 사용자 정의 속성(Property) 드로어를 정의합니다.
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    // GetPropertyHeight 메서드를 재정의하여 속성 필드의 높이를 결정합니다.
    public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label)
    {
        // EditorGUI.GetPropertyHeight 메서드에 계산을 위임합니다.
        return EditorGUI.GetPropertyHeight(_property, _label, true);
    }

    // OnGUI 메서드를 재정의하여 속성 필드를 그립니다.
    public override void OnGUI(Rect _pos, SerializedProperty _property, GUIContent _label)
    {
        // 속성 필드를 읽기 전용으로 만들기 위해 GUI를 비활성화합니다.
        GUI.enabled = false;

        // EditorGUI.PropertyField를 사용하여 속성 필드를 그립니다.
        EditorGUI.PropertyField(_pos, _property, _label, true);

        // GUI를 다시 활성화합니다.
        GUI.enabled = true;
    }
}
#endif

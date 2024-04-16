using UnityEditor;
using UnityEngine;

// ReadOnlyAttribute��� ����� ���� �Ӽ�(Attribute)�� �����մϴ�.
public class ReadOnlyAttribute : PropertyAttribute { }

#if UNITY_EDITOR
// ReadOnlyAttribute�� ���� ����� ���� �Ӽ�(Property) ��ξ �����մϴ�.
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    // GetPropertyHeight �޼��带 �������Ͽ� �Ӽ� �ʵ��� ���̸� �����մϴ�.
    public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label)
    {
        // EditorGUI.GetPropertyHeight �޼��忡 ����� �����մϴ�.
        return EditorGUI.GetPropertyHeight(_property, _label, true);
    }

    // OnGUI �޼��带 �������Ͽ� �Ӽ� �ʵ带 �׸��ϴ�.
    public override void OnGUI(Rect _pos, SerializedProperty _property, GUIContent _label)
    {
        // �Ӽ� �ʵ带 �б� �������� ����� ���� GUI�� ��Ȱ��ȭ�մϴ�.
        GUI.enabled = false;

        // EditorGUI.PropertyField�� ����Ͽ� �Ӽ� �ʵ带 �׸��ϴ�.
        EditorGUI.PropertyField(_pos, _property, _label, true);

        // GUI�� �ٽ� Ȱ��ȭ�մϴ�.
        GUI.enabled = true;
    }
}
#endif

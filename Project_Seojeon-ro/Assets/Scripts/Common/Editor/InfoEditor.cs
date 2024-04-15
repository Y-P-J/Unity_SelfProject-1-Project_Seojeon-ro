using UnityEditor;
using UnityEngine;

//�ߺ��Ǵ� Number�� ���� ScriptableObject�� �˻��ϴ� �����͵�

[CustomEditor(typeof(CharacterInfo))]
public class CharacterInfoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (target is CharacterInfo characterInfo)
        {
            CharacterInfo[] allCharacterInfos = Resources.FindObjectsOfTypeAll<CharacterInfo>();

            foreach (CharacterInfo info in allCharacterInfos)
            {
                if (info != characterInfo && info.Number == characterInfo.Number)
                {
                    EditorGUILayout.HelpBox("������ Number�� ����� CharacterInfo������ �ֽ��ϴ�!", MessageType.Warning);
                    break;
                }
            }
        }
    }
}

[CustomEditor(typeof(WeaponInfo))]
public class WeaponInfoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (target is WeaponInfo weaponInfo)
        {
            WeaponInfo[] allWeaponInfos = Resources.FindObjectsOfTypeAll<WeaponInfo>();

            foreach (WeaponInfo info in allWeaponInfos)
            {
                if (info != weaponInfo && info.Number == weaponInfo.Number)
                {
                    EditorGUILayout.HelpBox("������ Number�� ����� WeaponInfo������ �ֽ��ϴ�!", MessageType.Warning);
                    break;
                }
            }
        }
    }
}

[CustomEditor(typeof(WearInfo))]
public class WearInfoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (target is WearInfo wearInfo)
        {
            WearInfo[] allWearInfos = Resources.FindObjectsOfTypeAll<WearInfo>();

            foreach (WearInfo info in allWearInfos)
            {
                if (info != wearInfo && info.Number == wearInfo.Number)
                {
                    EditorGUILayout.HelpBox("������ Number�� ����� WearInfo������ �ֽ��ϴ�!", MessageType.Warning);
                    break;
                }
            }
        }
    }
}


[CustomEditor(typeof(GameInitInfo))]
public class GameInitInfoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (target is GameInitInfo gameInitInfo)
        {
            GameInitInfo[] allGameInitInfos = Resources.FindObjectsOfTypeAll<GameInitInfo>();

            foreach (GameInitInfo info in allGameInitInfos)
            {
                if (info != gameInitInfo && info.Number == gameInitInfo.Number)
                {
                    EditorGUILayout.HelpBox("������ Number�� ����� GameInitInfo������ �ֽ��ϴ�!", MessageType.Warning);
                    break;
                }
            }
        }
    }
}
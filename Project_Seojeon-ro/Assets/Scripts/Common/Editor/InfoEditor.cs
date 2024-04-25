using UnityEditor;
using UnityEngine;

//����Ƽ �����Ϳ��� �ߺ��Ǵ� Number�� ���� ScriptableObject�� �˻��ϴ� �����͵�

[CustomEditor(typeof(CharacterInfo))]
public class CharacterInfoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (Application.isPlaying)
            return;

        base.OnInspectorGUI();

        if (target is CharacterInfo _characterInfo)
        {
            CharacterInfo[] _allCharacterInfos = Resources.FindObjectsOfTypeAll<CharacterInfo>();

            foreach (CharacterInfo _info in _allCharacterInfos)
            {
                if (_info != _characterInfo && _info.Number == _characterInfo.Number)
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
        if (Application.isPlaying)
            return;

        base.OnInspectorGUI();

        if (target is WeaponInfo _weaponInfo)
        {
            WeaponInfo[] _allWeaponInfos = Resources.FindObjectsOfTypeAll<WeaponInfo>();

            foreach (WeaponInfo _info in _allWeaponInfos)
            {
                if (_info != _weaponInfo && _info.Number == _weaponInfo.Number && _info.WeaponType == _weaponInfo.WeaponType)
                {
                    EditorGUILayout.HelpBox("������ Number�� Ÿ���� ����� WeaponInfo������ �ֽ��ϴ�!", MessageType.Warning);
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
        if (Application.isPlaying)
            return;

        base.OnInspectorGUI();

        if (target is WearInfo _wearInfo)
        {
            WearInfo[] _allWearInfos = Resources.FindObjectsOfTypeAll<WearInfo>();

            foreach (WearInfo _info in _allWearInfos)
            {
                if (_info != _wearInfo && _info.Number == _wearInfo.Number && _info.WearType == _wearInfo.WearType)
                {
                    EditorGUILayout.HelpBox("������ Number�� Ÿ���� ����� WearInfo������ �ֽ��ϴ�!", MessageType.Warning);
                    break;
                }
            }
        }
    }
}

[CustomEditor(typeof(SkillInfo))]
public class SkillInfoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (Application.isPlaying)
            return;

        base.OnInspectorGUI();

        if (target is SkillInfo _skillInfo)
        {
            SkillInfo[] _allSkillInfos = Resources.FindObjectsOfTypeAll<SkillInfo>();

            foreach (SkillInfo _info in _allSkillInfos)
            {
                if (_info != _skillInfo && _info.Number == _skillInfo.Number)
                {
                    EditorGUILayout.HelpBox("������ Number�� ����� SkillInfo������ �ֽ��ϴ�!", MessageType.Warning);
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
        if (Application.isPlaying)
            return;

        base.OnInspectorGUI();

        if (target is GameInitInfo _gameInitInfo)
        {
            GameInitInfo[] _allGameInitInfos = Resources.FindObjectsOfTypeAll<GameInitInfo>();

            foreach (GameInitInfo _info in _allGameInitInfos)
            {
                if (_info != _gameInitInfo && _info.Number == _gameInitInfo.Number)
                {
                    EditorGUILayout.HelpBox("������ Number�� ����� GameInitInfo������ �ֽ��ϴ�!", MessageType.Warning);
                    break;
                }
            }
        }
    }
}

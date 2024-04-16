using UnityEditor;
using UnityEngine;

//유니티 에디터에서 중복되는 Number를 가진 ScriptableObject를 검사하는 에디터들

#if UNITY_EDITOR
[CustomEditor(typeof(CharacterInfo))]
public class CharacterInfoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (target is CharacterInfo _characterInfo)
        {
            CharacterInfo[] _allCharacterInfos = Resources.FindObjectsOfTypeAll<CharacterInfo>();

            foreach (CharacterInfo _info in _allCharacterInfos)
            {
                if (_info != _characterInfo && _info.Number == _characterInfo.Number)
                {
                    EditorGUILayout.HelpBox("동일한 Number를 사용한 CharacterInfo에셋이 있습니다!", MessageType.Warning);
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

        if (target is WeaponInfo _weaponInfo)
        {
            WeaponInfo[] _allWeaponInfos = Resources.FindObjectsOfTypeAll<WeaponInfo>();

            foreach (WeaponInfo _info in _allWeaponInfos)
            {
                if (_info != _weaponInfo && _info.Number == _weaponInfo.Number)
                {
                    EditorGUILayout.HelpBox("동일한 Number를 사용한 WeaponInfo에셋이 있습니다!", MessageType.Warning);
                    Debug.LogError("동일한 Number를 사용한 WeaponInfo에셋이 있습니다!");
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

        if (target is WearInfo _wearInfo)
        {
            WearInfo[] _allWearInfos = Resources.FindObjectsOfTypeAll<WearInfo>();

            foreach (WearInfo _info in _allWearInfos)
            {
                if (_info != _wearInfo && _info.Number == _wearInfo.Number)
                {
                    EditorGUILayout.HelpBox("동일한 Number를 사용한 WearInfo에셋이 있습니다!", MessageType.Warning);
                    Debug.LogError("동일한 Number를 사용한 WearInfo에셋이 있습니다!");
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
        base.OnInspectorGUI();

        if (target is SkillInfo _skillInfo)
        {
            SkillInfo[] _allSkillInfos = Resources.FindObjectsOfTypeAll<SkillInfo>();

            foreach (SkillInfo _info in _allSkillInfos)
            {
                if (_info != _skillInfo && _info.Number == _skillInfo.Number)
                {
                    EditorGUILayout.HelpBox("동일한 Number를 사용한 SkillInfo에셋이 있습니다!", MessageType.Warning);
                    Debug.LogError("동일한 Number를 사용한 SkillInfo에셋이 있습니다!");
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

        if (target is GameInitInfo _gameInitInfo)
        {
            GameInitInfo[] _allGameInitInfos = Resources.FindObjectsOfTypeAll<GameInitInfo>();

            foreach (GameInitInfo _info in _allGameInitInfos)
            {
                if (_info != _gameInitInfo && _info.Number == _gameInitInfo.Number)
                {
                    EditorGUILayout.HelpBox("동일한 Number를 사용한 GameInitInfo에셋이 있습니다!", MessageType.Warning);
                    Debug.LogError("동일한 Number를 사용한 GameInitInfo에셋이 있습니다!");
                    break;
                }
            }
        }
    }
}
#endif

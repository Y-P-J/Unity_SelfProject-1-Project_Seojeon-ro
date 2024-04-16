using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

//캐릭터와 장비의 정보를 담는 ScriptableObject를 로드하고 관리하는 클래스
public class EntityManager : Singleton<EntityManager>
{
    [Tooltip("캐릭터 정보 딕셔너리")]
    [SerializeField, ReadOnly] protected SerializedDictionary<string, CharacterInfo> characterDict;
    [Tooltip("무기 정보 딕셔너리")]
    [SerializeField, ReadOnly] protected SerializedDictionary<string, WeaponInfo> weaponDict;
    [Tooltip("방어구 정보 딕셔너리")]
    [SerializeField, ReadOnly] protected SerializedDictionary<string, WearInfo> wearDict;
    [Tooltip("스킬 정보 딕셔너리")]
    [SerializeField, ReadOnly] protected SerializedDictionary<string, SkillInfo> skillDict;

    [Tooltip("게임 시작 정보 딕셔너리")]
    [SerializeField, ReadOnly] protected SerializedDictionary<string, GameInitInfo> gameInitDict;

    new void Awake()
    {
        base.Awake();

        characterDict = new SerializedDictionary<string, CharacterInfo>();
        weaponDict = new SerializedDictionary<string, WeaponInfo>();
        wearDict = new SerializedDictionary<string, WearInfo>();
        skillDict = new SerializedDictionary<string, SkillInfo>();

        gameInitDict = new SerializedDictionary<string, GameInitInfo>();

        LoadCharacterData();
        LoadWeaponData();
        LoadWearData();
        LoadSkillData();

        LoadGameInitInfoData();
    }

    /// <summary>
    /// 캐릭터 정보를 로드하는 함수
    /// </summary>
    void LoadCharacterData()
    {
        CharacterInfo[] _characterInfo = Resources.LoadAll<CharacterInfo>("Scriptable/Character/");

        if (_characterInfo.Length > 0)
        {
            foreach (CharacterInfo _chara in _characterInfo)
            {
                if (characterDict.ContainsKey(_chara.ID))
                {
                    LogHandler.WriteLog(_chara.CharacterName + "의 ID가 중복됩니다.", this.GetType().Name, LogType.Error, true);
                }
                else
                {
                    characterDict.Add(_chara.ID, _chara);
                }
            }
        }
        else
        {
            LogHandler.WriteLog("characterInfo가 null입니다. 로드할 수 없습니다.", this.GetType().Name, LogType.Error, true);
        }
    }

    /// <summary>
    /// 무기 정보를 로드하는 함수
    /// </summary>
    void LoadWeaponData()
    {
        WeaponInfo[] _weaponInfo = Resources.LoadAll<WeaponInfo>("Scriptable/Equip/Weapon/");

        if (_weaponInfo.Length > 0)
        {
            foreach (WeaponInfo _weapon in _weaponInfo)
            {
                if (weaponDict.ContainsKey(_weapon.ID))
                {
                    LogHandler.WriteLog(_weapon.EquipName + "의 ID가 중복됩니다.", this.GetType().Name, LogType.Error, true);
                }
                else
                {
                    weaponDict.Add(_weapon.ID, _weapon);
                }
            }
        }
        else
        {
            LogHandler.WriteLog("weaponInfo가 null입니다. 로드할 수 없습니다.", this.GetType().Name, LogType.Error, true);
        }
    }

    /// <summary>
    /// 방어구 정보를 로드하는 함수
    /// </summary>
    void LoadWearData()
    {
        WearInfo[] _wearInfo = Resources.LoadAll<WearInfo>("Scriptable/Equip/Wear/");

        if (_wearInfo.Length > 0)
        {
            foreach (WearInfo _wear in _wearInfo)
            {
                if (wearDict.ContainsKey(_wear.ID))
                {
                    LogHandler.WriteLog(_wear.EquipName + "의 ID가 중복됩니다.", this.GetType().Name, LogType.Error, true);
                }
                else
                {
                    wearDict.Add(_wear.ID, _wear);
                }
            }
        }
        else
        {
            LogHandler.WriteLog("wearList가 null입니다. 로드할 수 없습니다.", this.GetType().Name, LogType.Error, true);
        }
    }

    /// <summary>
    /// 스킬 정보를 로드하는 함수
    /// </summary>
    void LoadSkillData()
    {
        SkillInfo[] _skillInfo = Resources.LoadAll<SkillInfo>("Scriptable/Skill/");

        if (_skillInfo.Length > 0)
        {
            foreach (SkillInfo _skill in _skillInfo)
            {
                if (skillDict.ContainsKey(_skill.ID))
                {
                    LogHandler.WriteLog(_skill.SkillName + "의 ID가 중복됩니다.", this.GetType().Name, LogType.Error, true);
                }
                else
                {
                    skillDict.Add(_skill.ID, _skill);
                }
            }
        }
        else
        {
            LogHandler.WriteLog("skillList가 null입니다. 로드할 수 없습니다.", this.GetType().Name, LogType.Error, true);
        }
    }

    /// <summary>
    /// 게임 시작 정보를 로드하는 함수
    /// </summary>
    void LoadGameInitInfoData()
    {
        GameInitInfo[] _gameInitInfo = Resources.LoadAll<GameInitInfo>("Scriptable/GameInitInfo/");

        if (_gameInitInfo.Length > 0)
        {
            foreach (GameInitInfo _gameInit in _gameInitInfo)
            {
                if (gameInitDict.ContainsKey(_gameInit.ID))
                {
                    LogHandler.WriteLog(_gameInit.GameInitInfoName + "의 ID가 중복됩니다.", this.GetType().Name, LogType.Error, true);
                }
                else
                {
                    gameInitDict.Add(_gameInit.ID, _gameInit);
                }
            }
        }
        else
        {
            LogHandler.WriteLog("gameInitInfo가 null입니다. 로드할 수 없습니다.", this.GetType().Name, LogType.Error, true);
        }
    }

    /// <summary>
    /// ID를 사용하여 ScriptableObject 기반 엔티티를 복사하는 함수
    /// </summary>
    public T CopyEntityByID<T>(string _id) where T : ScriptableObject
    {
        if (typeof(T) == typeof(CharacterInfo))
        {
            if (characterDict.ContainsKey(_id))
            {
                T _copyEntity = Instantiate(characterDict[_id]) as T;
                return _copyEntity;
            }
        }
        else if (typeof(T) == typeof(WeaponInfo))
        {
            if (weaponDict.ContainsKey(_id))
            {
                T _copyEntity = Instantiate(weaponDict[_id]) as T;
                return _copyEntity;
            }
        }
        else if (typeof(T) == typeof(WearInfo))
        {
            if (wearDict.ContainsKey(_id))
            {
                T _copyEntity = Instantiate(wearDict[_id]) as T;
                return _copyEntity;
            }
        }
        else if (typeof(T) == typeof(SkillInfo))
        {
            if (skillDict.ContainsKey(_id))
            {
                T _copyEntity = Instantiate(skillDict[_id]) as T;
                return _copyEntity;
            }
        }
        else if (typeof(T) == typeof(GameInitInfo))
        {
            if (gameInitDict.ContainsKey(_id))
            {
                T _copyEntity = Instantiate(gameInitDict[_id]) as T;
                return _copyEntity;
            }
        }

        LogHandler.WriteLog("ID가 " + _id + "인 " + typeof(T).ToString() + "를 찾을 수 없습니다. 또는, " +
            typeof(T).ToString() + "형태는 검색이 불가능합니다.", this.GetType().Name, LogType.Error, true);

        return null;
    }
}
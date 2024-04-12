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
    [Tooltip("캐릭터 정보 리스트")]
    [SerializeField, ReadOnly] protected List<CharacterInfo> characterList;
    [Tooltip("무기 정보 리스트")]
    [SerializeField, ReadOnly] protected List<WeaponInfo> weaponList;
    [Tooltip("방어구 정보 리스트")]
    [SerializeField, ReadOnly] protected List<WearInfo> wearList;

    [Tooltip("게임 시작 정보 리스트")]
    [SerializeField, ReadOnly] protected List<GameInitInfo> gameInitList;

    new void Awake()
    {
        base.Awake();

        characterList = new List<CharacterInfo>();
        weaponList = new List<WeaponInfo>();
        wearList = new List<WearInfo>();
        gameInitList = new List<GameInitInfo>();

        LoadCharacterData();
        LoadWeaponData();
        LoadWearData();
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
            characterList.AddRange(_characterInfo);

            characterList = characterList.OrderBy(_ch => _ch.ID).ToList(); // ID를 기준으로 정렬

            for (int i = 0; i < characterList.Count - 1; i++)
            {
                if (characterList[i].ID == characterList[i + 1].ID)
                    LogHandler.WriteLog(characterList[i].CharacterName + "와 " + characterList[i + 1].CharacterName + "의 ID가 중복됩니다.", this.GetType().Name, LogType.Error, true);
            }
        }
        else
            LogHandler.WriteLog("characterInfo가 null입니다. 로드할 수 없습니다.", this.GetType().Name, LogType.Error, true);
    }

    /// <summary>
    /// 무기 정보를 로드하는 함수
    /// </summary>
    void LoadWeaponData()
    {
        EquipInfo[] _weaponInfo = Resources.LoadAll<WeaponInfo>("Scriptable/Equip/Weapon/");

        if (_weaponInfo.Length > 0)
        {
            weaponList.AddRange(_weaponInfo);

            weaponList = weaponList.OrderBy(_eq => _eq.ID).ToList(); // ID를 기준으로 정렬

            for (int i = 0; i < weaponList.Count - 1; i++)
            {
                if (weaponList[i].ID == weaponList[i + 1].ID)
                    LogHandler.WriteLog(weaponList[i].EquipName + "와 " + weaponList[i + 1].EquipName + "의 ID가 중복됩니다.", this.GetType().Name, LogType.Error, true);
            }
        }
        else
            LogHandler.WriteLog("weaponInfo가 null입니다. 로드할 수 없습니다.", this.GetType().Name, LogType.Error, true);
    }

    /// <summary>
    /// 방어구 정보를 로드하는 함수
    /// </summary>
    void LoadWearData()
    {
        EquipInfo[] _wearInfo = Resources.LoadAll<WearInfo>("Scriptable/Equip/Wear/");

        if (_wearInfo.Length > 0)
        {
            wearList.AddRange(_wearInfo);

            wearList = wearList.OrderBy(_eq => _eq.ID).ToList(); // ID를 기준으로 정렬

            for (int i = 0; i < wearList.Count - 1; i++)
            {
                if (wearList[i].ID == wearList[i + 1].ID)
                    LogHandler.WriteLog(wearList[i].EquipName + "와 " + wearList[i + 1].EquipName + "의 ID가 중복됩니다.", this.GetType().Name, LogType.Error, true);
            }
        }
        else
            LogHandler.WriteLog("wearList가 null입니다. 로드할 수 없습니다.", this.GetType().Name, LogType.Error, true);
    }

    /// <summary>
    /// 게임 시작 정보를 로드하는 함수
    /// </summary>
    void LoadGameInitInfoData()
    {
        GameInitInfo[] _gameInitInfo = Resources.LoadAll<GameInitInfo>("Scriptable/GameInitInfo/");

        if (_gameInitInfo.Length > 0)
        {
            gameInitList.AddRange(_gameInitInfo);

            gameInitList = gameInitList.OrderBy(_gi => _gi.ID).ToList(); // ID를 기준으로 정렬

            for (int i = 0; i < gameInitList.Count - 1; i++)
            {
                if (gameInitList[i].ID == gameInitList[i + 1].ID)
                    LogHandler.WriteLog(gameInitList[i].GameInitInfoName + "와 " + gameInitList[i + 1].GameInitInfoName + "의 ID가 중복됩니다.", this.GetType().Name, LogType.Error, true);
            }
        }
        else
            LogHandler.WriteLog("gameInitInfo가 null입니다. 로드할 수 없습니다.", this.GetType().Name, LogType.Error, true);
    }

    /// <summary>
    /// ID를 사용하여 ScriptableObject 기반 엔티티를 복사하는 함수
    /// </summary>
    public T CopyEntityByID<T>(string _id) where T : ScriptableObject
    {
        if (typeof(T) == typeof(CharacterInfo))
        {
            foreach (CharacterInfo _ch in characterList)
            {
                if (_ch.ID == _id)
                {
                    T _copyEntity = Instantiate(_ch) as T;
                    return _copyEntity;
                }
            }
        }
        else if (typeof(T) == typeof(WeaponInfo))
        {
            foreach (WeaponInfo _wp in weaponList)
            {
                if (_wp.ID == _id)
                {
                    T _copyEntity = Instantiate(_wp) as T;
                    return _copyEntity;
                }
            }
        }
        else if (typeof(T) == typeof(WearInfo))
        {
            foreach (WearInfo _we in wearList)
            {
                if (_we.ID == _id)
                {
                    T _copyEntity = Instantiate(_we) as T;
                    return _copyEntity;
                }
            }
        }
        else if (typeof(T) == typeof(GameInitInfo))
        {
            foreach (GameInitInfo _gi in gameInitList)
            {
                if (_gi.ID == _id)
                {
                    T _copyEntity = Instantiate(_gi) as T;
                    return _copyEntity;
                }
            }
        }

        LogHandler.WriteLog("ID가 " + _id + "인 " + typeof(T).ToString() + "를 찾을 수 없습니다. 또는, " +
            typeof(T).ToString() + "형태는 검색이 불가능합니다.", this.GetType().Name, LogType.Error, true);

        return null;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

//ĳ���Ϳ� ����� ������ ��� ScriptableObject�� �ε��ϰ� �����ϴ� Ŭ����
public class EntityManager : Singleton<EntityManager>
{
    [Tooltip("ĳ���� ���� ����Ʈ")]
    [SerializeField, ReadOnly] protected List<CharacterInfo> characterList;
    [Tooltip("���� ���� ����Ʈ")]
    [SerializeField, ReadOnly] protected List<WeaponInfo> weaponList;
    [Tooltip("�� ���� ����Ʈ")]
    [SerializeField, ReadOnly] protected List<WearInfo> wearList;

    [Tooltip("���� ���� ���� ����Ʈ")]
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
    /// ĳ���� ������ �ε��ϴ� �Լ�
    /// </summary>
    void LoadCharacterData()
    {
        CharacterInfo[] _characterInfo = Resources.LoadAll<CharacterInfo>("Scriptable/Character/");

        if (_characterInfo.Length > 0)
        {
            characterList.AddRange(_characterInfo);

            characterList = characterList.OrderBy(_ch => _ch.ID).ToList(); // ID�� �������� ����

            for (int i = 0; i < characterList.Count - 1; i++)
            {
                if (characterList[i].ID == characterList[i + 1].ID)
                    LogHandler.WriteLog(characterList[i].CharacterName + "�� " + characterList[i + 1].CharacterName + "�� ID�� �ߺ��˴ϴ�.", this.GetType().Name, LogType.Error, true);
            }
        }
        else
            LogHandler.WriteLog("characterInfo�� null�Դϴ�. �ε��� �� �����ϴ�.", this.GetType().Name, LogType.Error, true);
    }

    /// <summary>
    /// ���� ������ �ε��ϴ� �Լ�
    /// </summary>
    void LoadWeaponData()
    {
        EquipInfo[] _weaponInfo = Resources.LoadAll<WeaponInfo>("Scriptable/Equip/Weapon/");

        if (_weaponInfo.Length > 0)
        {
            weaponList.AddRange(_weaponInfo);

            weaponList = weaponList.OrderBy(_eq => _eq.ID).ToList(); // ID�� �������� ����

            for (int i = 0; i < weaponList.Count - 1; i++)
            {
                if (weaponList[i].ID == weaponList[i + 1].ID)
                    LogHandler.WriteLog(weaponList[i].EquipName + "�� " + weaponList[i + 1].EquipName + "�� ID�� �ߺ��˴ϴ�.", this.GetType().Name, LogType.Error, true);
            }
        }
        else
            LogHandler.WriteLog("weaponInfo�� null�Դϴ�. �ε��� �� �����ϴ�.", this.GetType().Name, LogType.Error, true);
    }

    /// <summary>
    /// �� ������ �ε��ϴ� �Լ�
    /// </summary>
    void LoadWearData()
    {
        EquipInfo[] _wearInfo = Resources.LoadAll<WearInfo>("Scriptable/Equip/Wear/");

        if (_wearInfo.Length > 0)
        {
            wearList.AddRange(_wearInfo);

            wearList = wearList.OrderBy(_eq => _eq.ID).ToList(); // ID�� �������� ����

            for (int i = 0; i < wearList.Count - 1; i++)
            {
                if (wearList[i].ID == wearList[i + 1].ID)
                    LogHandler.WriteLog(wearList[i].EquipName + "�� " + wearList[i + 1].EquipName + "�� ID�� �ߺ��˴ϴ�.", this.GetType().Name, LogType.Error, true);
            }
        }
        else
            LogHandler.WriteLog("wearList�� null�Դϴ�. �ε��� �� �����ϴ�.", this.GetType().Name, LogType.Error, true);
    }

    /// <summary>
    /// ���� ���� ������ �ε��ϴ� �Լ�
    /// </summary>
    void LoadGameInitInfoData()
    {
        GameInitInfo[] _gameInitInfo = Resources.LoadAll<GameInitInfo>("Scriptable/GameInitInfo/");

        if (_gameInitInfo.Length > 0)
        {
            gameInitList.AddRange(_gameInitInfo);

            gameInitList = gameInitList.OrderBy(_gi => _gi.ID).ToList(); // ID�� �������� ����

            for (int i = 0; i < gameInitList.Count - 1; i++)
            {
                if (gameInitList[i].ID == gameInitList[i + 1].ID)
                    LogHandler.WriteLog(gameInitList[i].GameInitInfoName + "�� " + gameInitList[i + 1].GameInitInfoName + "�� ID�� �ߺ��˴ϴ�.", this.GetType().Name, LogType.Error, true);
            }
        }
        else
            LogHandler.WriteLog("gameInitInfo�� null�Դϴ�. �ε��� �� �����ϴ�.", this.GetType().Name, LogType.Error, true);
    }

    /// <summary>
    /// ID�� ����Ͽ� ScriptableObject ��� ��ƼƼ�� �����ϴ� �Լ�
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

        LogHandler.WriteLog("ID�� " + _id + "�� " + typeof(T).ToString() + "�� ã�� �� �����ϴ�. �Ǵ�, " +
            typeof(T).ToString() + "���´� �˻��� �Ұ����մϴ�.", this.GetType().Name, LogType.Error, true);

        return null;
    }
}
using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

//ĳ���Ϳ� ����� ������ ��� ScriptableObject�� �ε��ϰ� ����, �����ϴ� Ŭ����
public class EntityManager : Singleton<EntityManager>
{
    [Tooltip("ĳ���� ���� ��ųʸ�")]
    [SerializeField, ReadOnly] protected SerializedDictionary<string, CharacterInfo> characterDict;
    [Tooltip("���� ���� ��ųʸ�")]
    [SerializeField, ReadOnly] protected SerializedDictionary<string, WeaponInfo> weaponDict;
    [Tooltip("�� ���� ��ųʸ�")]
    [SerializeField, ReadOnly] protected SerializedDictionary<string, WearInfo> wearDict;
    [Tooltip("��ų ���� ��ųʸ�")]
    [SerializeField, ReadOnly] protected SerializedDictionary<string, SkillInfo> skillDict;
    [Tooltip("���� ���� ���� ��ųʸ�")]
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
    /// ĳ���� ������ �ε��ϴ� �Լ�
    /// </summary>
    void LoadCharacterData()
    {
        CharacterInfo[] _characterInfo = Resources.LoadAll<CharacterInfo>("Scriptable/Character/");

        if (_characterInfo.Length > 0)
        {
            foreach (CharacterInfo _chara in _characterInfo)
            {
                if (characterDict.ContainsKey(_chara.ID))//ID�� �ߺ��Ǵ� ScriptableObject�� �ִ��� Ȯ��
                {
                    LogHandler.WriteLog(_chara.CharacterName + "�� ID�� �ߺ��˴ϴ�.", this.GetType().Name, LogType.Error, true);
                }
                else
                {
                    characterDict.Add(_chara.ID, _chara);
                }
            }

            //�⺻������ ��ųʸ��� ������ �ʿ�� ������, ��ȸ�� �ؾ��� ��츦 ���, �׸��� �����Ϳ��� ���ϰ� ���� ���� ����
            characterDict = new SerializedDictionary<string, CharacterInfo>(characterDict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value));
        }
        else
        {
            LogHandler.WriteLog("characterInfo�� null�Դϴ�. �ε��� �� �����ϴ�.", this.GetType().Name, LogType.Error, true);
        }
    }

    /// <summary>
    /// ���� ������ �ε��ϴ� �Լ�
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
                    LogHandler.WriteLog(_weapon.EquipName + "�� ID�� �ߺ��˴ϴ�.", this.GetType().Name, LogType.Error, true);
                }
                else
                {
                    weaponDict.Add(_weapon.ID, _weapon);
                }
            }

            weaponDict = new SerializedDictionary<string, WeaponInfo>(weaponDict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value));
        }
        else
        {
            LogHandler.WriteLog("weaponInfo�� null�Դϴ�. �ε��� �� �����ϴ�.", this.GetType().Name, LogType.Error, true);
        }
    }

    /// <summary>
    /// �� ������ �ε��ϴ� �Լ�
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
                    LogHandler.WriteLog(_wear.EquipName + "�� ID�� �ߺ��˴ϴ�.", this.GetType().Name, LogType.Error, true);
                }
                else
                {
                    wearDict.Add(_wear.ID, _wear);
                }
            }

            wearDict = new SerializedDictionary<string, WearInfo>(wearDict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value));
        }
        else
        {
            LogHandler.WriteLog("wearList�� null�Դϴ�. �ε��� �� �����ϴ�.", this.GetType().Name, LogType.Error, true);
        }
    }

    /// <summary>
    /// ��ų ������ �ε��ϴ� �Լ�
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
                    LogHandler.WriteLog(_skill.SkillName + "�� ID�� �ߺ��˴ϴ�.", this.GetType().Name, LogType.Error, true);
                }
                else
                {
                    skillDict.Add(_skill.ID, _skill);
                }
            }

            skillDict = new SerializedDictionary<string, SkillInfo>(skillDict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value));
        }
        else
        {
            LogHandler.WriteLog("skillList�� null�Դϴ�. �ε��� �� �����ϴ�.", this.GetType().Name, LogType.Error, true);
        }
    }

    /// <summary>
    /// ���� ���� ������ �ε��ϴ� �Լ�
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
                    LogHandler.WriteLog(_gameInit.GameInitInfoName + "�� ID�� �ߺ��˴ϴ�.", this.GetType().Name, LogType.Error, true);
                }
                else
                {
                    gameInitDict.Add(_gameInit.ID, _gameInit);
                }
            }

            gameInitDict = new SerializedDictionary<string, GameInitInfo>(gameInitDict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value));
        }
        else
        {
            LogHandler.WriteLog("gameInitInfo�� null�Դϴ�. �ε��� �� �����ϴ�.", this.GetType().Name, LogType.Error, true);
        }
    }

    /// <summary>
    /// ID�� ����Ͽ� ScriptableObject ��� ��ƼƼ�� �����ϴ� �Լ�
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
        else if(typeof(T).IsSubclassOf(typeof(EquipInfo)) || typeof(T) == typeof(EquipInfo))//���׸� Ÿ���� EquipInfo�� �ڽ� Ŭ�������� Ȯ��
        {
            if (typeof(T) == typeof(WeaponInfo) || typeof(T) == typeof(EquipInfo))
            {
                if (weaponDict.ContainsKey(_id))
                {
                    T _copyEntity = Instantiate(weaponDict[_id]) as T;
                    return _copyEntity;
                }
            }
            if (typeof(T) == typeof(WearInfo) || typeof(T) == typeof(EquipInfo))
            {
                if (wearDict.ContainsKey(_id))
                {
                    T _copyEntity = Instantiate(wearDict[_id]) as T;
                    return _copyEntity;
                }
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

        LogHandler.WriteLog("ID�� " + _id + "�� " + typeof(T).ToString() + "�� ã�� �� �����ϴ�. �Ǵ�, " +
            typeof(T).ToString() + "���´� �˻��� �Ұ����մϴ�.", this.GetType().Name, LogType.Error, true);

        return null;
    }
}
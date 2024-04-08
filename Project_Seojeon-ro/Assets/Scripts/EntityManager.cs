using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

//ĳ���Ϳ� ����� ������ ��� ��ũ���ͺ� ������Ʈ�� �ε��ϰ� �����ϴ� Ŭ����
public class EntityManager : Singleton<EntityManager>
{
    [Tooltip("ĳ���� ���� ����Ʈ")]
    [SerializeField, ReadOnly] protected List<CharacterInfo> characterList;
    [Tooltip("��� ���� ����Ʈ")]
    [SerializeField, ReadOnly] protected List<EquipInfo> equipList;

    void Start()
    {
        characterList = new List<CharacterInfo>();
        equipList = new List<EquipInfo>();

        LoadCharacterData();
        LoadEquipData();
    }

    /// <summary>
    /// ĳ���� ������ �ε��ϴ� �Լ�
    /// </summary>
    void LoadCharacterData()
    {
        CharacterInfo[] _characterInfo = Resources.LoadAll<CharacterInfo>("Scriptable/Character/");

        if (_characterInfo.Count() > 0)
        {
            characterList.AddRange(_characterInfo);

            for (int i = 0; i < characterList.Count - 1; i++)
            {
                if (characterList[i].ID == characterList[i + 1].ID)
                    LogHandler.WriteLog("ID�� �ߺ��Ǿ����ϴ�. " + characterList[i].CharacterName + "�� " +
                        characterList[i + 1].CharacterName + "�� ID�� �ߺ��˴ϴ�.", true, true);
            }
        }
        else
            LogHandler.WriteLog("characterInfo�� null�Դϴ�. �ε��� �� �����ϴ�.", true, true);
    }

    /// <summary>
    /// ��� ������ �ε��ϴ� �Լ�
    /// </summary>
    void LoadEquipData()
    {
        EquipInfo[] _equipInfo = Resources.LoadAll<EquipInfo>("Scriptable/Equip/");

        if (_equipInfo.Count() > 0)
            equipList.AddRange(_equipInfo);
        else
            LogHandler.WriteLog("equipInfo�� null�Դϴ�. �ε��� �� �����ϴ�.", true, true);
    }
}

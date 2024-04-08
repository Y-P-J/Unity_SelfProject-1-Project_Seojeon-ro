using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

//캐릭터와 장비의 정보를 담는 스크립터블 오브젝트를 로드하고 관리하는 클래스
public class EntityManager : Singleton<EntityManager>
{
    [Tooltip("캐릭터 정보 리스트")]
    [SerializeField, ReadOnly] protected List<CharacterInfo> characterList;
    [Tooltip("장비 정보 리스트")]
    [SerializeField, ReadOnly] protected List<EquipInfo> equipList;

    void Start()
    {
        characterList = new List<CharacterInfo>();
        equipList = new List<EquipInfo>();

        LoadCharacterData();
        LoadEquipData();
    }

    /// <summary>
    /// 캐릭터 정보를 로드하는 함수
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
                    LogHandler.WriteLog("ID가 중복되었습니다. " + characterList[i].CharacterName + "와 " +
                        characterList[i + 1].CharacterName + "의 ID가 중복됩니다.", true, true);
            }
        }
        else
            LogHandler.WriteLog("characterInfo가 null입니다. 로드할 수 없습니다.", true, true);
    }

    /// <summary>
    /// 장비 정보를 로드하는 함수
    /// </summary>
    void LoadEquipData()
    {
        EquipInfo[] _equipInfo = Resources.LoadAll<EquipInfo>("Scriptable/Equip/");

        if (_equipInfo.Count() > 0)
            equipList.AddRange(_equipInfo);
        else
            LogHandler.WriteLog("equipInfo가 null입니다. 로드할 수 없습니다.", true, true);
    }
}

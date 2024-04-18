using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 장착 가능한 무기의 종류를 나타내는 열거형
/// </summary>
public enum WEAPON_TYPE
{
    NONE = 0,           //없음

    SWORD = 1,          //검
    AXE = 2,            //도끼
    WAND = 21,          //지팡이
}

//무기의 정보를 담는 ScriptableObject
[CreateAssetMenu(fileName = "WeaponInfo", menuName = "PlayableObject/WeaponInfo")]
public class WeaponInfo : EquipInfo
{
    [Tooltip("무기 타입")]
    [SerializeField] WEAPON_TYPE weaponType;

    public WEAPON_TYPE WeaponType => weaponType;

    void OnEnable()
    {
        id = IDGenerator.GenerateID(this);
    }

    public string WeaponTypeToString()
    {
        return weaponType switch
        {
            WEAPON_TYPE.SWORD => "검",
            WEAPON_TYPE.AXE => "도끼",
            WEAPON_TYPE.WAND => "지팡이",
            _ => "없음",
        };
    }
}

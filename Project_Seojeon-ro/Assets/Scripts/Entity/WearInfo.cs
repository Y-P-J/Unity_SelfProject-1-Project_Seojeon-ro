using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 장착 가능한 방어구의 종류를 나타내는 열거형
/// </summary>
public enum WEAR_TYPE
{
    NONE = 0,           //없음

    HELMET = 1,         //투구
    ARMOR = 11,         //갑옷
    GLOVES = 21,        //장갑
    SHOES = 31,         //신발

    RING = 101,         //반지
}

//방어구의 정보를 담는 ScriptableObject
[CreateAssetMenu(fileName = "WearInfo", menuName = "PlayableObject/WearInfo")]
public class WearInfo : EquipInfo
{
    [Tooltip("방어구 타입")]
    [SerializeField] WEAR_TYPE wearType;

    public WEAR_TYPE WearType => wearType;

    void OnEnable()
    {
        id = IDGenerator.GenerateID(this);
    }
}

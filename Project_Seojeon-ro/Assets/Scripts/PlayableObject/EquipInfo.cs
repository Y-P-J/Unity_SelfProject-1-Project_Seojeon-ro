using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 장착 가능한 아이템의 종류를 나타내는 열거형
/// </summary>
public enum EQUIP_TYPE
{
    //무기류의 경우 0 ~ 999번까지 사용
    //방어구류의 경우 1000 ~ 1999번까지 사용
    //악세사리류의 경우 2000 ~ 2999번까지 사용
    SWORD = 0,          //검
    AXE = 1,            //도끼
    WAND = 200,         //지팡이

    HELMET = 1000,      //투구
    ARMOR = 1100,       //갑옷
    GLOVE = 1200,       //장갑
    SHOES = 1300,       //신발

    RING = 2000,        //반지
}

/// <summary>
/// 아이템의 희귀도를 나타내는 열거형
/// </summary>
public enum QUILTY
{
    COMMON = 0,         //일반
    UNCOMMON = 10,      //희귀
    RARE = 20,          //레어
    EPIC = 30,          //에픽
    LEGENDARY = 40,     //레전더리
}

//장비의 정보를 담는 스크립트에이블 오브젝트
[CreateAssetMenu(fileName = "EquipInfo", menuName = "PlayableObject/EquipInfo")]
public class EquipInfo : ScriptableObject
{
    [Tooltip("장비 이름")]
    string equipName;
    [Tooltip("캐릭터 순서")]
    string number;

    [Space]

    [Tooltip("장비 타입")]
    EQUIP_TYPE equipType;
    [Tooltip("장비 희귀도")]
    QUILTY quilty;

    [Space]

    [Tooltip("장비 스테이터스")]
    Status status;

    [Space]

    [Tooltip("장비 대표 이미지")]
    Sprite repImage;
}

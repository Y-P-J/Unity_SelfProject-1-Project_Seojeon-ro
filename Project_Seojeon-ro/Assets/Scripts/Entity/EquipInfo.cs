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
    SWORD = 1,          //검
    AXE = 2,            //도끼
    WAND = 201,         //지팡이

    HELMET = 1001,      //투구
    ARMOR = 1101,       //갑옷
    GLOVE = 1201,       //장갑
    SHOES = 1301,       //신발

    RING = 2001,        //반지
}

/// <summary>
/// 아이템의 희귀도를 나타내는 열거형
/// </summary>
public enum QUILTY
{
    COMMON = 1,         //일반
    UNCOMMON = 11,      //희귀
    RARE = 21,          //레어
    EPIC = 31,          //에픽
    LEGENDARY = 41,     //레전더리
}

//장비의 정보를 담는 스크립트에이블 오브젝트
[CreateAssetMenu(fileName = "EquipInfo", menuName = "PlayableObject/EquipInfo")]
public class EquipInfo : ScriptableObject
{
    [Tooltip("장비 이름")]
    [SerializeField] string equipName;
    [Tooltip("장비 고유 숫자")]
    [SerializeField] int number;
    [Tooltip("장비 ID(장비 ID는 장비 고유 숫자와 그 외의 정보를 토대로 IDGenerator에서 생성되어 지급받는다)")] 
    [SerializeField, ReadOnly] string id;

    [Space]

    [Tooltip("장비 타입")]
    [SerializeField] EQUIP_TYPE equipType;
    [Tooltip("장비 희귀도")]
    [SerializeField] QUILTY quilty;

    [Space]

    [Tooltip("장비 스테이터스")]
    [SerializeField] protected Status status;

    [Space]

    [Tooltip("장비 대표 이미지")]
    [SerializeField] Sprite repImage;

    #region 람다식 프로퍼티
    public string EquipName => equipName;
    public int Number => number;
    public string ID => id;
    public EQUIP_TYPE EquipType => equipType;
    public QUILTY Quilty => quilty;
    public Status Status => status;
    public Sprite RepImage => repImage;
    #endregion

    void OnEnable()
    {
        id = IDGenerator.GenerateID(this);
    }
}

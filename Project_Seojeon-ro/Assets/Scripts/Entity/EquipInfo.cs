using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 아이템의 희귀도를 나타내는 열거형
/// </summary>
public enum QUILTY
{
    NONE = 0,           //없음

    COMMON = 1,         //일반
    UNCOMMON = 11,      //희귀
    RARE = 21,          //레어
    EPIC = 31,          //에픽
    LEGENDARY = 41,     //레전더리
}

//장비의 정보를 담는 ScriptableObject(단일로 사용되지 않으며, 상속받아 사용된다)
public abstract class EquipInfo : ScriptableObject
{
    [Tooltip("장비 이름")]
    [SerializeField] protected string equipName;
    [Tooltip("장비 고유 숫자")]
    [SerializeField] protected int number;
    [Tooltip("장비 ID(장비 ID는 장비 고유 숫자와 그 외의 정보를 토대로 IDGenerator에서 생성되어 지급받는다)")] 
    [SerializeField, ReadOnly] protected string id;

    [Space]

    [Tooltip("장비 설명")]
    [SerializeField, TextArea(2, 3)] protected string description;

    [Space]

    [Tooltip("장비 희귀도")]
    [SerializeField] protected QUILTY quilty;

    [Space]

    [Tooltip("장비 스테이터스")]
    [SerializeField] protected Status status;

    [Space]

    [Tooltip("장비 대표 이미지")]
    [SerializeField] protected Sprite repImage;


    #region 람다식 프로퍼티
    public string EquipName => equipName;
    public int Number => number;
    public string ID => id;
    public QUILTY Quilty => quilty;
    public Status Status => status;
    public Sprite RepImage => repImage;
    #endregion
}

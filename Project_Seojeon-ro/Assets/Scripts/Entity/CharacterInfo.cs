using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//캐릭터의 정보를 담는 ScriptableObject
[CreateAssetMenu(fileName = "CharacterInfo", menuName = "PlayableObject/CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    [Tooltip("캐릭터 이름")]
    [SerializeField] protected string characterName;
    [Tooltip("캐릭터 고유 숫자")]
    [SerializeField] protected int number;
    [Tooltip("캐릭터 ID(캐릭터 ID는 캐릭터 고유 숫자와 그 외의 정보를 토대로 IDGenerator에서 생성되어 지급받는다)")] 
    [SerializeField, ReadOnly] protected string id;

    [Space]

    [Tooltip("캐릭터 레벨")]
    [SerializeField] protected int level;

    [Space]

    [Tooltip("캐릭터 기존 스테이터스")]
    [SerializeField] protected Status originStatus;
    [Tooltip("캐릭터 현재 스테이터스")]
    [SerializeField, ReadOnly] protected Status currentStatus;

    [Space]

    //각 하단의 EQUIP_TYPE[] 배열은 해당 장비를 장착할 수 있는 타입을 표시함
    [Tooltip("현재 장착 무기")]
    [SerializeField] protected WeaponInfo weapon;
    [SerializeField] WEAPON_TYPE[] weaponTypes;
    [Tooltip("현재 장착 헬멧")]
    [SerializeField] protected WearInfo helmet;
    [SerializeField] WEAR_TYPE[] helmetTypes;
    [Tooltip("현재 장착 갑옷")]
    [SerializeField] protected WearInfo armor;
    [SerializeField] WEAR_TYPE[] armorTypes;
    [Tooltip("현재 장착 장갑")]
    [SerializeField] protected WearInfo glove;
    [SerializeField] WEAR_TYPE[] gloveTypes;
    [Tooltip("현재 장착 신발")]
    [SerializeField] protected WearInfo shoes;
    [SerializeField] WEAR_TYPE[] shoesTypes;
    [Tooltip("현재 장착 반지")]
    [SerializeField] protected WearInfo ring;
    [SerializeField] WEAR_TYPE[] ringTypes;

    [Tooltip("캐릭터 대표 이미지")]
    [SerializeField] protected Sprite repImage;

    #region 람다식 프로퍼티
    public string CharacterName => characterName;
    public int Number => number;
    public string ID => id;
    public int Level => level;
    public Status OriginStatus => originStatus;
    public Status CurrentStatus => currentStatus;
    public EquipInfo Weapon => weapon;
    public WEAPON_TYPE[] WeaponTypes => weaponTypes;
    public EquipInfo Helmet => helmet;
    public WEAR_TYPE[] HelmetTypes => helmetTypes;
    public EquipInfo Armor => armor;
    public WEAR_TYPE[] ArmorTypes => armorTypes;
    public EquipInfo Glove => glove;
    public WEAR_TYPE[] GloveTypes => gloveTypes;
    public EquipInfo Shoes => shoes;
    public WEAR_TYPE[] ShoesTypes => shoesTypes;
    public EquipInfo Ring => ring;
    public WEAR_TYPE[] RingTypes => ringTypes;
    public Sprite RepImage => repImage;
    #endregion

    void OnEnable()
    {
        id = IDGenerator.GenerateID(this);
        currentStatus = originStatus;
    }
}

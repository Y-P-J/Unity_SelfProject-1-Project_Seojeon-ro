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
    [Tooltip("캐릭터 고유 숫자 / 기본적으로 피아구분없이 사용하기 위해 같은 ScriptableObject를 사용하나 주로 적으로 사용되는 캐릭터는 1001 이상의 숫자를 사용하길 권장")]
    [SerializeField] protected int number;
    [Tooltip("캐릭터 ID(캐릭터 ID는 캐릭터 고유 숫자와 그 외의 정보를 토대로 IDGenerator에서 생성되어 지급받는다)")]
    [SerializeField, ReadOnly] protected string id;

    [Space]

    [Tooltip("캐릭터 레벨")]
    [SerializeField] protected int level;

    [Space]

    [Tooltip("캐릭터 기존 스테이터스")]
    [SerializeField] protected Status originStatus;
    [Tooltip("캐릭터 레벨업 시 증가하는 스테이터스")]
    [SerializeField] protected Status levelUpStatus;
    [Tooltip("레벨 내용이 적용된 스테이터스")]
    [SerializeField, ReadOnly] protected Status levelModifiedStatus;
    [Tooltip("캐릭터 현재 스테이터스 / 캐릭터의 최종 스테이터스는 레벨, 장비 장착, 버프/디버프에 따라 변동됨")]
    [SerializeField, ReadOnly] protected Status finalStatus;
    [Tooltip("캐릭터 현재 HP")]//하단의 hp, mp는 전투중인 캐릭터의 현재 HP, MP를 나타냄
    [SerializeField, ReadOnly] protected int currentHp;
    [Tooltip("캐릭터 현재 MP")]
    [SerializeField, ReadOnly] protected int currentMp;

    [Space]

    [Tooltip("캐릭터의 1번 스킬 정보")]
    [SerializeField] protected SkillInfo firstSkill;
    [Tooltip("캐릭터의 2번 스킬 정보")]
    [SerializeField] protected SkillInfo secondSkill;
    [Tooltip("캐릭터의 3번 스킬 정보")]
    [SerializeField] protected SkillInfo thirdSkill;

    [Space]

    //각 하단의 EQUIP_TYPE[] 배열은 해당 장비를 장착할 수 있는 타입을 표시함
    [Tooltip("현재 장착 무기")]
    [SerializeField] protected WeaponInfo weapon;
    [SerializeField] protected WEAPON_TYPE[] weaponTypes;
    [Tooltip("현재 장착 헬멧")]
    [SerializeField] protected WearInfo helmet;
    [SerializeField] protected WEAR_TYPE[] helmetTypes;
    [Tooltip("현재 장착 갑옷")]
    [SerializeField] protected WearInfo armor;
    [SerializeField] protected WEAR_TYPE[] armorTypes;
    [Tooltip("현재 장착 장갑")]
    [SerializeField] protected WearInfo gloves;
    [SerializeField] protected WEAR_TYPE[] gloveTypes;
    [Tooltip("현재 장착 신발")]
    [SerializeField] protected WearInfo shoes;
    [SerializeField] protected WEAR_TYPE[] shoesTypes;
    [Tooltip("현재 장착 반지")]
    [SerializeField] protected WearInfo ring;
    [SerializeField] protected WEAR_TYPE[] ringTypes;

    [Tooltip("캐릭터 대표 이미지")]
    [SerializeField] protected Sprite repImage;

    #region 람다식 프로퍼티
    public string CharacterName => characterName;
    public int Number => number;
    public string ID => id;
    public int Level => level;
    public Status OriginStatus => originStatus;
    public Status LevelUpStatus => levelUpStatus;
    public Status LevelModifiedStatus => levelModifiedStatus;
    public Status FinalStatus => finalStatus;
    public int CurrentHp => currentHp;
    public int CurrentMp => currentMp;
    public SkillInfo FirstSkill => firstSkill;
    public SkillInfo SecondSkill => secondSkill;
    public SkillInfo ThirdSkill => thirdSkill;
    public EquipInfo Weapon => weapon;
    public WEAPON_TYPE[] WeaponTypes => weaponTypes;
    public EquipInfo Helmet => helmet;
    public WEAR_TYPE[] HelmetTypes => helmetTypes;
    public EquipInfo Armor => armor;
    public WEAR_TYPE[] ArmorTypes => armorTypes;
    public EquipInfo Gloves => gloves;
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

        levelModifiedStatus = originStatus + levelUpStatus * (level - 1);

        UpdateStatus();
    }

    public WeaponInfo SwitchWeapon(WeaponInfo _weapon)
    {
        WeaponInfo _temp = weapon;
        weapon = _weapon;

        UpdateStatus();

        return _temp;
    }

    public WearInfo SwitchWear(WearInfo _wear)
    {
        WearInfo _temp = null;

        switch (_wear.WearType)
        {
            case WEAR_TYPE.HELMET:
                _temp = helmet;
                helmet = _wear;
                break;

            case WEAR_TYPE.ARMOR:
                _temp = armor;
                armor = _wear;
                break;

            case WEAR_TYPE.GLOVES:
                _temp = gloves;
                gloves = _wear;
                break;

            case WEAR_TYPE.SHOES:
                _temp = shoes;
                shoes = _wear;
                break;

            case WEAR_TYPE.RING:
                _temp = ring;
                ring = _wear;
                break;
        }

        UpdateStatus();

        return _temp;
    }

    public void UpdateStatus()
    {
        finalStatus = levelModifiedStatus + weapon.Status + helmet.Status + armor.Status + gloves.Status + shoes.Status + ring.Status;
        currentHp = finalStatus.hp;
        currentMp = finalStatus.mp;
    }
}

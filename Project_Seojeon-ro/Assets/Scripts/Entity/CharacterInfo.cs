using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ĳ������ ������ ��� ScriptableObject
[CreateAssetMenu(fileName = "CharacterInfo", menuName = "PlayableObject/CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    [Tooltip("ĳ���� �̸�")]
    [SerializeField] protected string characterName;
    [Tooltip("ĳ���� ���� ���� / �⺻������ �ǾƱ��о��� ����ϱ� ���� ���� ScriptableObject�� ����ϳ� �ַ� ������ ���Ǵ� ĳ���ʹ� 1001 �̻��� ���ڸ� ����ϱ� ����")]
    [SerializeField] protected int number;
    [Tooltip("ĳ���� ID(ĳ���� ID�� ĳ���� ���� ���ڿ� �� ���� ������ ���� IDGenerator���� �����Ǿ� ���޹޴´�)")]
    [SerializeField, ReadOnly] protected string id;

    [Space]

    [Tooltip("ĳ���� ����")]
    [SerializeField] protected int level;

    [Space]

    [Tooltip("ĳ���� ���� �������ͽ�")]
    [SerializeField] protected Status originStatus;
    [Tooltip("ĳ���� ������ �� �����ϴ� �������ͽ�")]
    [SerializeField] protected Status levelUpStatus;
    [Tooltip("���� ������ ����� �������ͽ�")]
    [SerializeField, ReadOnly] protected Status levelModifiedStatus;
    [Tooltip("ĳ���� ���� �������ͽ� / ĳ������ ���� �������ͽ��� ����, ��� ����, ����/������� ���� ������")]
    [SerializeField, ReadOnly] protected Status finalStatus;
    [Tooltip("ĳ���� ���� HP")]//�ϴ��� hp, mp�� �������� ĳ������ ���� HP, MP�� ��Ÿ��
    [SerializeField, ReadOnly] protected int currentHp;
    [Tooltip("ĳ���� ���� MP")]
    [SerializeField, ReadOnly] protected int currentMp;

    [Space]

    [Tooltip("ĳ������ 1�� ��ų ����")]
    [SerializeField] protected SkillInfo firstSkill;
    [Tooltip("ĳ������ 2�� ��ų ����")]
    [SerializeField] protected SkillInfo secondSkill;
    [Tooltip("ĳ������ 3�� ��ų ����")]
    [SerializeField] protected SkillInfo thirdSkill;

    [Space]

    //�� �ϴ��� EQUIP_TYPE[] �迭�� �ش� ��� ������ �� �ִ� Ÿ���� ǥ����
    [Tooltip("���� ���� ����")]
    [SerializeField] protected WeaponInfo weapon;
    [SerializeField] protected WEAPON_TYPE[] weaponTypes;
    [Tooltip("���� ���� ���")]
    [SerializeField] protected WearInfo helmet;
    [SerializeField] protected WEAR_TYPE[] helmetTypes;
    [Tooltip("���� ���� ����")]
    [SerializeField] protected WearInfo armor;
    [SerializeField] protected WEAR_TYPE[] armorTypes;
    [Tooltip("���� ���� �尩")]
    [SerializeField] protected WearInfo gloves;
    [SerializeField] protected WEAR_TYPE[] gloveTypes;
    [Tooltip("���� ���� �Ź�")]
    [SerializeField] protected WearInfo shoes;
    [SerializeField] protected WEAR_TYPE[] shoesTypes;
    [Tooltip("���� ���� ����")]
    [SerializeField] protected WearInfo ring;
    [SerializeField] protected WEAR_TYPE[] ringTypes;

    [Tooltip("ĳ���� ��ǥ �̹���")]
    [SerializeField] protected Sprite repImage;

    #region ���ٽ� ������Ƽ
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

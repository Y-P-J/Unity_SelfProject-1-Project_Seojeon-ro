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
    [Tooltip("ĳ���� ���� ����")]
    [SerializeField] protected int number;
    [Tooltip("ĳ���� ID(ĳ���� ID�� ĳ���� ���� ���ڿ� �� ���� ������ ���� IDGenerator���� �����Ǿ� ���޹޴´�)")] 
    [SerializeField, ReadOnly] protected string id;

    [Space]

    [Tooltip("ĳ���� ����")]
    [SerializeField] protected int level;

    [Space]

    [Tooltip("ĳ���� ���� �������ͽ�")]
    [SerializeField] protected Status originStatus;
    [Tooltip("ĳ���� ���� �������ͽ�")]
    [SerializeField, ReadOnly] protected Status currentStatus;

    [Space]

    //�� �ϴ��� EQUIP_TYPE[] �迭�� �ش� ��� ������ �� �ִ� Ÿ���� ǥ����
    [Tooltip("���� ���� ����")]
    [SerializeField] protected WeaponInfo weapon;
    [SerializeField] WEAPON_TYPE[] weaponTypes;
    [Tooltip("���� ���� ���")]
    [SerializeField] protected WearInfo helmet;
    [SerializeField] WEAR_TYPE[] helmetTypes;
    [Tooltip("���� ���� ����")]
    [SerializeField] protected WearInfo armor;
    [SerializeField] WEAR_TYPE[] armorTypes;
    [Tooltip("���� ���� �尩")]
    [SerializeField] protected WearInfo glove;
    [SerializeField] WEAR_TYPE[] gloveTypes;
    [Tooltip("���� ���� �Ź�")]
    [SerializeField] protected WearInfo shoes;
    [SerializeField] WEAR_TYPE[] shoesTypes;
    [Tooltip("���� ���� ����")]
    [SerializeField] protected WearInfo ring;
    [SerializeField] WEAR_TYPE[] ringTypes;

    [Tooltip("ĳ���� ��ǥ �̹���")]
    [SerializeField] protected Sprite repImage;

    #region ���ٽ� ������Ƽ
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

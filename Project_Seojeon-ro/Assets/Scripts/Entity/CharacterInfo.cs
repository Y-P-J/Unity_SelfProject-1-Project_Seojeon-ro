using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ĳ������ ������ ��� ��ũ��Ʈ���̺� ������Ʈ
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
    [SerializeField] protected EquipInfo weapon;
    [SerializeField] EQUIP_TYPE[] weaponTypes;
    [Tooltip("���� ���� ���")]
    [SerializeField] protected EquipInfo helmet;
    [SerializeField] EQUIP_TYPE[] helmetTypes;
    [Tooltip("���� ���� ����")]
    [SerializeField] protected EquipInfo armor;
    [SerializeField] EQUIP_TYPE[] armorTypes;
    [Tooltip("���� ���� �尩")]
    [SerializeField] protected EquipInfo glove;
    [SerializeField] EQUIP_TYPE[] gloveTypes;
    [Tooltip("���� ���� �Ź�")]
    [SerializeField] protected EquipInfo shoes;
    [SerializeField] EQUIP_TYPE[] shoesTypes;
    [Tooltip("���� ���� ����")]
    [SerializeField] protected EquipInfo ring;
    [SerializeField] EQUIP_TYPE[] ringTypes;

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
    public EQUIP_TYPE[] WeaponTypes => weaponTypes;
    public EquipInfo Helmet => helmet;
    public EQUIP_TYPE[] HelmetTypes => helmetTypes;
    public EquipInfo Armor => armor;
    public EQUIP_TYPE[] ArmorTypes => armorTypes;
    public EquipInfo Glove => glove;
    public EQUIP_TYPE[] GloveTypes => gloveTypes;
    public EquipInfo Shoes => shoes;
    public EQUIP_TYPE[] ShoesTypes => shoesTypes;
    public EquipInfo Ring => ring;
    public EQUIP_TYPE[] RingTypes => ringTypes;
    public Sprite RepImage => repImage;
    #endregion

    void OnEnable()
    {
        id = IDGenerator.GenerateID(this);
        currentStatus = originStatus;
    }
}

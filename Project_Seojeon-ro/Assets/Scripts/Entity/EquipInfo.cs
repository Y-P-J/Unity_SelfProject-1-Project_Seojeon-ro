using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������ �������� ������ ��Ÿ���� ������
/// </summary>
public enum EQUIP_TYPE
{
    //������� ��� 0 ~ 999������ ���
    //������ ��� 1000 ~ 1999������ ���
    //�Ǽ��縮���� ��� 2000 ~ 2999������ ���
    SWORD = 1,          //��
    AXE = 2,            //����
    WAND = 201,         //������

    HELMET = 1001,      //����
    ARMOR = 1101,       //����
    GLOVE = 1201,       //�尩
    SHOES = 1301,       //�Ź�

    RING = 2001,        //����
}

/// <summary>
/// �������� ��͵��� ��Ÿ���� ������
/// </summary>
public enum QUILTY
{
    COMMON = 1,         //�Ϲ�
    UNCOMMON = 11,      //���
    RARE = 21,          //����
    EPIC = 31,          //����
    LEGENDARY = 41,     //��������
}

//����� ������ ��� ��ũ��Ʈ���̺� ������Ʈ
[CreateAssetMenu(fileName = "EquipInfo", menuName = "PlayableObject/EquipInfo")]
public class EquipInfo : ScriptableObject
{
    [Tooltip("��� �̸�")]
    [SerializeField] string equipName;
    [Tooltip("��� ���� ����")]
    [SerializeField] int number;
    [Tooltip("��� ID(��� ID�� ��� ���� ���ڿ� �� ���� ������ ���� IDGenerator���� �����Ǿ� ���޹޴´�)")] 
    [SerializeField, ReadOnly] string id;

    [Space]

    [Tooltip("��� Ÿ��")]
    [SerializeField] EQUIP_TYPE equipType;
    [Tooltip("��� ��͵�")]
    [SerializeField] QUILTY quilty;

    [Space]

    [Tooltip("��� �������ͽ�")]
    [SerializeField] protected Status status;

    [Space]

    [Tooltip("��� ��ǥ �̹���")]
    [SerializeField] Sprite repImage;

    #region ���ٽ� ������Ƽ
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

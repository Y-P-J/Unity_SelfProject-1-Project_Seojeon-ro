using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ��͵��� ��Ÿ���� ������
/// </summary>
public enum QUALITY
{
    NONE = 0,           //����

    COMMON = 1,         //�Ϲ�
    UNCOMMON = 11,      //���
    RARE = 21,          //����
    EPIC = 31,          //����
    LEGENDARY = 41,     //��������
}

//����� ������ ��� ScriptableObject(���Ϸ� ������ ������, ��ӹ޾� ���ȴ�)
public abstract class EquipInfo : ScriptableObject
{
    [Tooltip("��� �̸�")]
    [SerializeField] protected string equipName;
    [Tooltip("��� ���� ����")]
    [SerializeField] protected int number;
    [Tooltip("��� ID(��� ID�� ��� ���� ���ڿ� �� ���� ������ ���� IDGenerator���� �����Ǿ� ���޹޴´�)")] 
    [SerializeField, ReadOnly] protected string id;

    [Space]

    [Tooltip("��� ����")]
    [SerializeField, TextArea(2, 3)] protected string description;

    [Space]

    [Tooltip("��� ��͵�")]
    [SerializeField] protected QUALITY quality;

    [Space]

    [Tooltip("��� �������ͽ�")]
    [SerializeField] protected Status status;

    [Space]

    [Tooltip("��� ��ǥ �̹���")]
    [SerializeField] protected Sprite repImage;


    #region ���ٽ� ������Ƽ
    public string EquipName => equipName;
    public int Number => number;
    public string ID => id;
    public string Description => description;
    public QUALITY Quality => quality;
    public Status Status => status;
    public Sprite RepImage => repImage;
    #endregion

    public string QualityToString()
    {
        return quality switch
        {
            QUALITY.COMMON => "�Ϲ�",
            QUALITY.UNCOMMON => "���",
            QUALITY.RARE => "����",
            QUALITY.EPIC => "����",
            QUALITY.LEGENDARY => "��������",
            _ => "����",
        };
    }
}

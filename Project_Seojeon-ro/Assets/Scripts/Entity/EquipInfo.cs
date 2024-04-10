using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ��͵��� ��Ÿ���� ������
/// </summary>
public enum QUILTY
{
    NONE = 0,           //����

    COMMON = 1,         //�Ϲ�
    UNCOMMON = 11,      //���
    RARE = 21,          //����
    EPIC = 31,          //����
    LEGENDARY = 41,     //��������
}

//����� ������ ��� ScriptableObject
public class EquipInfo : ScriptableObject
{
    [Tooltip("��� �̸�")]
    [SerializeField] protected string equipName;
    [Tooltip("��� ���� ����")]
    [SerializeField] protected int number;
    [Tooltip("��� ID(��� ID�� ��� ���� ���ڿ� �� ���� ������ ���� IDGenerator���� �����Ǿ� ���޹޴´�)")] 
    [SerializeField, ReadOnly] protected string id;

    [Space]

    [Tooltip("��� ��͵�")]
    [SerializeField] protected QUILTY quilty;

    [Space]

    [Tooltip("��� ��ǥ �̹���")]
    [SerializeField] protected Sprite repImage;

    [Space]

    [Tooltip("��� �������ͽ�")]
    [SerializeField] protected Status status;



    #region ���ٽ� ������Ƽ
    public string EquipName => equipName;
    public int Number => number;
    public string ID => id;
    public QUILTY Quilty => quilty;
    public Status Status => status;
    public Sprite RepImage => repImage;
    #endregion
}
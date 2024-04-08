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
    SWORD = 0,          //��
    AXE = 1,            //����
    WAND = 200,         //������

    HELMET = 1000,      //����
    ARMOR = 1100,       //����
    GLOVE = 1200,       //�尩
    SHOES = 1300,       //�Ź�

    RING = 2000,        //����
}

/// <summary>
/// �������� ��͵��� ��Ÿ���� ������
/// </summary>
public enum QUILTY
{
    COMMON = 0,         //�Ϲ�
    UNCOMMON = 10,      //���
    RARE = 20,          //����
    EPIC = 30,          //����
    LEGENDARY = 40,     //��������
}

//����� ������ ��� ��ũ��Ʈ���̺� ������Ʈ
[CreateAssetMenu(fileName = "EquipInfo", menuName = "PlayableObject/EquipInfo")]
public class EquipInfo : ScriptableObject
{
    [Tooltip("��� �̸�")]
    string equipName;
    [Tooltip("ĳ���� ����")]
    string number;

    [Space]

    [Tooltip("��� Ÿ��")]
    EQUIP_TYPE equipType;
    [Tooltip("��� ��͵�")]
    QUILTY quilty;

    [Space]

    [Tooltip("��� �������ͽ�")]
    Status status;

    [Space]

    [Tooltip("��� ��ǥ �̹���")]
    Sprite repImage;
}

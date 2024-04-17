using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������ ���� ������ ��Ÿ���� ������
/// </summary>
public enum WEAR_TYPE
{
    NONE = 0,           //����

    HELMET = 1,         //����
    ARMOR = 11,         //����
    GLOVES = 21,        //�尩
    SHOES = 31,         //�Ź�

    RING = 101,         //����
}

//���� ������ ��� ScriptableObject
[CreateAssetMenu(fileName = "WearInfo", menuName = "PlayableObject/WearInfo")]
public class WearInfo : EquipInfo
{
    [Tooltip("�� Ÿ��")]
    [SerializeField] WEAR_TYPE wearType;

    public WEAR_TYPE WearType => wearType;

    void OnEnable()
    {
        id = IDGenerator.GenerateID(this);
    }
}

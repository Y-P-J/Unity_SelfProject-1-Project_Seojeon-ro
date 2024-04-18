using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������ ������ ������ ��Ÿ���� ������
/// </summary>
public enum WEAPON_TYPE
{
    NONE = 0,           //����

    SWORD = 1,          //��
    AXE = 2,            //����
    WAND = 21,          //������
}

//������ ������ ��� ScriptableObject
[CreateAssetMenu(fileName = "WeaponInfo", menuName = "PlayableObject/WeaponInfo")]
public class WeaponInfo : EquipInfo
{
    [Tooltip("���� Ÿ��")]
    [SerializeField] WEAPON_TYPE weaponType;

    public WEAPON_TYPE WeaponType => weaponType;

    void OnEnable()
    {
        id = IDGenerator.GenerateID(this);
    }

    public string WeaponTypeToString()
    {
        return weaponType switch
        {
            WEAPON_TYPE.SWORD => "��",
            WEAPON_TYPE.AXE => "����",
            WEAPON_TYPE.WAND => "������",
            _ => "����",
        };
    }
}

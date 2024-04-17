using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�κ��丮�� ����ϴ� Ŭ����
public class Inventory : Singleton<Inventory>
{
    //�κ��丮�� �� �����۵�
    [SerializeField, ReadOnly] EquipInfo[] items;

    #region ���ٽ� ������Ƽ
    public EquipInfo[] Items => items;
    #endregion

    void Start()
    {
        items = new EquipInfo[30];

        for (int i = 0; i < items.Length; i++)
        {
            items[i] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0000000000");
        }

        items[items.Length - 1] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0001010001");
        items[7] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0002010001");
        items[3] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0001010001");

        SortInventory();
    }

    /// <summary>
    /// �������� �����ϴ� �Լ�
    /// </summary>
    public void SwitchItem(int _index)
    {
        if (items[_index] is WeaponInfo)
        {
            Debug.Log(_index + "��° �������� �����Դϴ�.");
        }
        else if (items[_index] is WearInfo)
        {
            Debug.Log(_index + "��° �������� �����Դϴ�.");
        }
    }

    /// <summary>
    /// �������� �����ϴ� �Լ�
    /// </summary>
    public void RemoveItem(EquipInfo _item)
    {
    }

    /// <summary>
    /// �κ��丮 ���� �Լ�
    /// </summary>
    public void SortInventory()
    {

    }
}

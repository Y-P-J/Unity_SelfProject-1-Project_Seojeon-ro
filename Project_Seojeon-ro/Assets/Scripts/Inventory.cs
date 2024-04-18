using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Services.Analytics;
using Unity.VisualScripting;
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

        items[3] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0001010001");
        items[5] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0001010001");
        items[7] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0002010001");
        items[9] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0011010001");
        items[15] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0021010001");
        items[22] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0101010001");
        items[28] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0002010001");

        SortInventory();
    }

    /// <summary>
    /// �������� �����ϴ� �Լ�
    /// </summary>
    public void SwitchItem(int _index)
    {
        if (items[_index] is WeaponInfo)
        {
            Debug.Log(_index + "��° ��������" + items[_index].ID + " �����Դϴ�.");
        }
        else if (items[_index] is WearInfo)
        {
            Debug.Log(_index + "��° ��������" + items[_index].ID + " �����Դϴ�.");
        }

        SortInventory();
    }

    /// <summary>
    /// �κ��丮 ���� �Լ�
    /// </summary>
    public void SortInventory()
    {
        List<EquipInfo> _none = new List<EquipInfo>();
        List<EquipInfo> _weapon = new List<EquipInfo>();
        List<EquipInfo> _wear = new List<EquipInfo>();

        foreach (var item in items)
        {
            if (item.ID.EndsWith("0"))
                _none.Add(item);
            else if (item is WeaponInfo)
                _weapon.Add(item);
            else if (item is WearInfo)
                _wear.Add(item);
            else
                _none.Add(item);
        }

        _weapon.Sort((x, y) => x.ID.CompareTo(y.ID));
        _wear.Sort((x, y) => x.ID.CompareTo(y.ID));

        _weapon.AddRange(_wear);
        _weapon.AddRange(_none);

        items = _weapon.ToArray();
    }
}

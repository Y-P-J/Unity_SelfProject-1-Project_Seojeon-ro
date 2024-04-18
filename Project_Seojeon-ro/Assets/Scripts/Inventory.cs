using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Services.Analytics;
using Unity.VisualScripting;
using UnityEngine;

//�κ��丮�� ����ϴ� Ŭ����
public class Inventory : MonoBehaviour
{
    //�κ��丮�� �� �����۵�
    [SerializeField, ReadOnly] EquipInfo[] items;

    #region ���ٽ� ������Ƽ
    public EquipInfo[] Items => items;
    #endregion

    void Start()
    {
        items = new EquipInfo[30];
    }

    public void Setup()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0000000000");
        }

        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0001010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0001010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0002010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0011010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0021010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0101010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0002010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0101010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0101010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0101010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0101010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0002010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0011010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0021010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0101010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0021010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0101010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0001010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0001010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0021010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0011010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0021010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0001010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0002010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0021010001"));
        AddItem(EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0031010001"));

        SortInventory();
    }

    /// <summary>
    /// ������ �߰� �Լ�
    /// </summary>
    public void AddItem(EquipInfo _item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].ID == "WP0000000000")
            {
                items[i] = _item;
                SortInventory();
                return;
            }
        }

        Debug.Log("�� ���� �ϴ� �����մϴ�. ���� ���� ����");
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

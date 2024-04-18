using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Services.Analytics;
using Unity.VisualScripting;
using UnityEngine;

//인벤토리를 담당하는 클래스
public class Inventory : MonoBehaviour
{
    //인벤토리에 들어갈 아이템들
    [SerializeField, ReadOnly] EquipInfo[] items;

    #region 람다식 프로퍼티
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
    /// 아이템 추가 함수
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

        Debug.Log("꽉 차서 일단 무시합니다. 이후 수정 예정");
    }

    /// <summary>
    /// 인벤토리 정렬 함수
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

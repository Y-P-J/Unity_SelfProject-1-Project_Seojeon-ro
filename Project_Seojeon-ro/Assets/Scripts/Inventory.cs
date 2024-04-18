using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Services.Analytics;
using Unity.VisualScripting;
using UnityEngine;

//인벤토리를 담당하는 클래스
public class Inventory : Singleton<Inventory>
{
    //인벤토리에 들어갈 아이템들
    [SerializeField, ReadOnly] EquipInfo[] items;

    #region 람다식 프로퍼티
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
    /// 아이템을 변경하는 함수
    /// </summary>
    public void SwitchItem(int _index)
    {
        if (items[_index] is WeaponInfo)
        {
            Debug.Log(_index + "번째 아이템은" + items[_index].ID + " 무기입니다.");
        }
        else if (items[_index] is WearInfo)
        {
            Debug.Log(_index + "번째 아이템은" + items[_index].ID + " 갑옷입니다.");
        }

        SortInventory();
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

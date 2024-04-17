using System;
using System.Collections;
using System.Collections.Generic;
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

        items[items.Length - 1] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0001010001");
        items[7] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WP0002010001");
        items[3] = EntityManager.Instance.CopyEntityByID<EquipInfo>("WE0001010001");

        SortInventory();
    }

    /// <summary>
    /// 아이템을 변경하는 함수
    /// </summary>
    public void SwitchItem(int _index)
    {
        if (items[_index] is WeaponInfo)
        {
            Debug.Log(_index + "번째 아이템은 무기입니다.");
        }
        else if (items[_index] is WearInfo)
        {
            Debug.Log(_index + "번째 아이템은 갑옷입니다.");
        }
    }

    /// <summary>
    /// 아이템을 제거하는 함수
    /// </summary>
    public void RemoveItem(EquipInfo _item)
    {
    }

    /// <summary>
    /// 인벤토리 정렬 함수
    /// </summary>
    public void SortInventory()
    {

    }
}

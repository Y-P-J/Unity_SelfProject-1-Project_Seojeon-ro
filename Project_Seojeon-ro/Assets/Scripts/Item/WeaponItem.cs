using ItemStruct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon")]
public class WeaponItem : Item
{
    public WEAPON_TYPE weaponType;
    public QUALITY_TYPE qualityType;
    public ItemStat itemStat;
}

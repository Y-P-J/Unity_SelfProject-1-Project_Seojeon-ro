using ItemStruct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wearable", menuName = "Item/Wearable")]
public class WearableItem : Item
{
    public WEARABLE_TYPE wearableType;
    public QUALITY_TYPE qualityType;
    public ItemStat itemStat;
}

using ItemStruct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemStruct
{
    public enum ITEM_TYPE
    {
        WEAPON = 1,
        WEARABLE = 2,
        CONSUMABLE = 101,
        MATERIAL = 201,
    }

    public enum WEAPON_TYPE
    {
        SWORD = 1,
        AXE = 2,
        BOW = 101,
        WAND = 201,
    }

    public enum WEARABLE_TYPE
    {
        HELMET = 1,
        CLOTH = 101,
        GLOVE = 201,
        BOOTS = 301,
        RING = 401,
    }

    public enum QUALITY_TYPE
    {
        COMMON = 1,
        RARE = 11,
        EPIC = 21,
    }

    [System.Serializable]
    public struct ItemStat
    {
        public int hp;
        public int mp;
        public int atk;
        public int def;
        public float cri;
        public float eva;
        public int speed;
    }
}

[System.Serializable]
public class Item : ScriptableObject
{
    public string itemName;
    [TextArea(1, 4)] public string description;
    public Sprite itemImage;
    public int IdNumber;
    public ITEM_TYPE itemType;
}

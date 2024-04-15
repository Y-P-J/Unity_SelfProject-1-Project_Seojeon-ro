using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

//스텟을 나타내는 구조체
[System.Serializable]
public struct Status
{
    [Tooltip("체력")]
    public int hp;
    [Tooltip("마나")]
    public int mp;
    [Tooltip("속도")]
    public int speed;
    [Tooltip("공격력")]
    public int attack;
    [Tooltip("방어력")]
    public int defense;
    [Tooltip("치명률")]
    public float critical;
    [Tooltip("회피율")]
    public float avoid;

    public static Status operator +(Status a, Status b)
    {
        Status result = new Status();
        result.hp = a.hp + b.hp;
        result.mp = a.mp + b.mp;
        result.speed = a.speed + b.speed;
        result.attack = a.attack + b.attack;
        result.defense = a.defense + b.defense;
        result.critical = a.critical + b.critical;
        result.avoid = a.avoid + b.avoid;
        return result;
    }
    public static Status operator *(Status a, int b)
    {
        Status result = new Status();
        result.hp = a.hp * b;
        result.mp = a.mp * b;
        result.speed = a.speed * b;
        result.attack = a.attack * b;
        result.defense = a.defense * b;
        result.critical = a.critical * b;
        result.avoid = a.avoid * b;
        return result;
    }
}

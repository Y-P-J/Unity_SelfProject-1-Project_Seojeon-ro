using System.Collections;
using System.Collections.Generic;
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
    public int critical;
    [Tooltip("회피율")]
    public int avoid;
}

using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

//������ ��Ÿ���� ����ü
[System.Serializable]
public struct Status
{
    [Tooltip("ü��")]
    public int hp;
    [Tooltip("����")]
    public int mp;
    [Tooltip("�ӵ�")]
    public int speed;
    [Tooltip("���ݷ�")]
    public int attack;
    [Tooltip("����")]
    public int defense;
    [Tooltip("ġ���")]
    public float critical;
    [Tooltip("ȸ����")]
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

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

    public static Status operator +(Status _origin, Status _target)
    {
        Status _result = new Status();
        _result.hp = _origin.hp + _target.hp;
        _result.mp = _origin.mp + _target.mp;
        _result.speed = _origin.speed + _target.speed;
        _result.attack = _origin.attack + _target.attack;
        _result.defense = _origin.defense + _target.defense;
        _result.critical = _origin.critical + _target.critical;
        _result.avoid = _origin.avoid + _target.avoid;
        return _result;
    }
    public static Status operator *(Status _origin, int _scale)
    {
        Status _result = new Status();
        _result.hp = _origin.hp * _scale;
        _result.mp = _origin.mp * _scale;
        _result.speed = _origin.speed * _scale;
        _result.attack = _origin.attack * _scale;
        _result.defense = _origin.defense * _scale;
        _result.critical = _origin.critical * _scale;
        _result.avoid = _origin.avoid * _scale;
        return _result;
    }
}

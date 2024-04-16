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

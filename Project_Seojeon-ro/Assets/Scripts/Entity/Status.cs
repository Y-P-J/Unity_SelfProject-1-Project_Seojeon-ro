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
}

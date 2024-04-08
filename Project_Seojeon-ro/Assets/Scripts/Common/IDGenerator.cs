using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//ID�� �����ϴ� Ŭ����
public static class IDGenerator
{
    /// <summary>
    /// ĳ���� ID�� �����ϴ� �Լ�
    /// </summary>
    public static string GenerateID(CharacterInfo _characterInfo)
    {
        StringBuilder _ID = new StringBuilder();

        _ID.Append("CH");
        _ID.Append(_characterInfo.Number.ToString("D4"));

        return _ID.ToString();
    }

    /// <summary>
    /// ��� ID�� �����ϴ� �Լ�
    /// </summary>
    public static string GenerateID(EquipInfo _equipInfo)
    {
        StringBuilder _ID = new StringBuilder();

        _ID.Append("EQ");
        _ID.Append(((int)_equipInfo.EquipType).ToString("D4"));
        _ID.Append(((int)_equipInfo.Quilty).ToString("D2"));
        _ID.Append(_equipInfo.Number.ToString("D4"));

        return _ID.ToString();
    }
}

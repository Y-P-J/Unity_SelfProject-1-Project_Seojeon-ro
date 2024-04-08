using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//ID를 생성하는 클래스
public static class IDGenerator
{
    /// <summary>
    /// 캐릭터 ID를 생성하는 함수
    /// </summary>
    public static string GenerateID(CharacterInfo _characterInfo)
    {
        StringBuilder _ID = new StringBuilder();

        _ID.Append("CH");
        _ID.Append(_characterInfo.Number.ToString("D4"));

        return _ID.ToString();
    }

    /// <summary>
    /// 장비 ID를 생성하는 함수
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

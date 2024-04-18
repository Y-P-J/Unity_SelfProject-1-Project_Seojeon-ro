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
    /// 무기 ID를 생성하는 함수
    /// </summary>
    public static string GenerateID(WeaponInfo _info)
    {
        StringBuilder _ID = new StringBuilder();

        _ID.Append("WP");
        _ID.Append(((int)_info.WeaponType).ToString("D4"));
        _ID.Append(((int)_info.Quality).ToString("D2"));
        _ID.Append(_info.Number.ToString("D4"));

        return _ID.ToString();
    }

    /// <summary>
    /// 방어구 ID를 생성하는 함수
    /// </summary>
    public static string GenerateID(WearInfo _info)
    {
        StringBuilder _ID = new StringBuilder();

        _ID.Append("WE");
        _ID.Append(((int)_info.WearType).ToString("D4"));
        _ID.Append(((int)_info.Quality).ToString("D2"));
        _ID.Append(_info.Number.ToString("D4"));

        return _ID.ToString();
    }

    /// <summary>
    /// 스킬 ID를 생성하는 함수
    /// </summary>
    public static string GenerateID(SkillInfo _info)
    {
        StringBuilder _ID = new StringBuilder();

        _ID.Append("SK");
        _ID.Append(_info.Number.ToString("D4"));

        return _ID.ToString();
    }

    /// <summary>
    /// 게임 초기화 정보 ID를 생성하는 함수
    /// </summary>
    public static string GenerateID(GameInitInfo _info)
    {
        StringBuilder _ID = new StringBuilder();

        _ID.Append("GI");
        _ID.Append(_info.Number.ToString("D4"));

        return _ID.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class IDGenerator
{
    string GenerateID(CharacterInfo _characterInfo)
    {
        StringBuilder _ID = new StringBuilder();

        _ID.Append("CH");

        return _ID.ToString();
    }

    string GenerateID(EquipInfo _equipInfo)
    {
        StringBuilder _ID = new StringBuilder();
        return _ID.ToString();
    }
}

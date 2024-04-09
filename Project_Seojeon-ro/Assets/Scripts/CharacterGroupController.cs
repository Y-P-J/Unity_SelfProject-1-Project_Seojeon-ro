using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ĳ���� �׷��� �����ϴ� Ŭ����
public class CharacterGroupController : MonoBehaviour
{
    [Tooltip("ĳ���� ���� ����Ʈ")]
    [SerializeField, ReadOnly] protected CharacterInfo[] characterGroup;

    public void Setup(string[] _id)
    {
        characterGroup = new CharacterInfo[3];

        for(int i = 0; i < 3; i++)
        characterGroup[i] = EntityManager.Instance.CopyEntityByID<CharacterInfo>(_id[i]);
    }
}

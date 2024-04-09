using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//캐릭터 그룹을 관리하는 클래스
public class CharacterGroupController : MonoBehaviour
{
    [Tooltip("캐릭터 정보 리스트")]
    [SerializeField, ReadOnly] protected CharacterInfo[] characterGroup;

    public void Setup(string[] _id)
    {
        characterGroup = new CharacterInfo[3];

        for(int i = 0; i < 3; i++)
        characterGroup[i] = EntityManager.Instance.CopyEntityByID<CharacterInfo>(_id[i]);
    }
}

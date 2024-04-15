using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//캐릭터 그룹을 관리하는 클래스
public class CharacterGroupController : MonoBehaviour
{
    [Tooltip("캐릭터 정보 리스트")]
    [SerializeField, 
        ] protected CharacterInfo[] characterGroup;


    #region 람다식 프로퍼티
    public CharacterInfo[] CharacterGroup => characterGroup;
    #endregion

    /// <summary>
    /// 현재 3 vs 3 기반의 게임이기에 3개만 받아서 설정하며, 확장성은 고려하지 않음
    /// </summary>
    /// <param name="_id"></param>
    public void Setup(string _id1, string _id2, string _id3)
    {
        characterGroup = new CharacterInfo[3];

        characterGroup[0] = EntityManager.Instance.CopyEntityByID<CharacterInfo>(_id1);
        characterGroup[1] = EntityManager.Instance.CopyEntityByID<CharacterInfo>(_id2);
        characterGroup[2] = EntityManager.Instance.CopyEntityByID<CharacterInfo>(_id3);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ĳ���� �׷��� �����ϴ� Ŭ����
public class CharacterGroupController : MonoBehaviour
{
    [Tooltip("ĳ���� ���� ����Ʈ")]
    [SerializeField, ReadOnly] protected CharacterInfo[] characterGroup;

    #region ���ٽ� ������Ƽ
    public CharacterInfo[] CharacterGroup => characterGroup;
    #endregion

    void Start()
    {
        characterGroup = new CharacterInfo[3];
    }

    /// <summary>
    /// ���� 3 vs 3 ����� �����̱⿡ 3���� �޾Ƽ� �����ϸ�, Ȯ�强�� ������� ����
    /// </summary>
    public void Setup(string _id1, string _id2, string _id3)
    {
        characterGroup[0] = EntityManager.Instance.CopyEntityByID<CharacterInfo>(_id1);
        characterGroup[1] = EntityManager.Instance.CopyEntityByID<CharacterInfo>(_id2);
        characterGroup[2] = EntityManager.Instance.CopyEntityByID<CharacterInfo>(_id3);
    }
}

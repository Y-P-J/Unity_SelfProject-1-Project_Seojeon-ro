using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ���� ������ ��� ScriptableObject
[CreateAssetMenu(fileName = "GameInitInfo", menuName = "GameInitInfo", order = 2)]
public class GameInitInfo : ScriptableObject
{
    [Tooltip("���� ���� ���� �̸�")]
    [SerializeField] protected string gameInitInfoName;
    [Tooltip("���� ���� ���� ���� ����")]
    [SerializeField] protected int number;
    [Tooltip("���� ���� ���� ID(���� ���� ���� ID�� ���� ���� ���� ���� ���ڿ� �� ���� ������ ���� IDGenerator���� �����Ǿ� ���޹޴´�)")]
    [SerializeField, ReadOnly] protected string id;

    [Tooltip("���� ����")]
    [SerializeField] protected int currentStage;

    [Tooltip("�÷��̾� ĳ����1")]
    [SerializeField] protected string playerChara1_ID;
    [Tooltip("�÷��̾� ĳ����2")]
    [SerializeField] protected string playerChara2_ID;
    [Tooltip("�÷��̾� ĳ����3")]
    [SerializeField] protected string playerChara3_ID;

    [Tooltip("�� ĳ����1")]
    [SerializeField] protected string enemyChara1_ID;
    [Tooltip("�� ĳ����2")]
    [SerializeField] protected string enemyChara2_ID;
    [Tooltip("�� ĳ����3")]
    [SerializeField] protected string enemyChara3_ID;

    #region ���ٽ� ������Ƽ
    public string GameInitInfoName => gameInitInfoName;
    public int Number => number;
    public string ID => id;
    public int CurrentStage => currentStage;
    public string PlayerChara1_ID => playerChara1_ID;
    public string PlayerChara2_ID => playerChara2_ID;
    public string PlayerChara3_ID => playerChara3_ID;
    public string EnemyChara1_ID => enemyChara1_ID;
    public string EnemyChara2_ID => enemyChara2_ID;
    public string EnemyChara3_ID => enemyChara3_ID;
    #endregion

    void OnEnable()
    {
        id = IDGenerator.GenerateID(this);
    }
}

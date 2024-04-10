using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 시작 정보를 담는 ScriptableObject
[CreateAssetMenu(fileName = "GameInitInfo", menuName = "GameInitInfo", order = 2)]
public class GameInitInfo : ScriptableObject
{
    [Tooltip("게임 시작 정보 이름")]
    [SerializeField] protected string gameInitInfoName;
    [Tooltip("게임 시작 정보 고유 숫자")]
    [SerializeField] protected int number;
    [Tooltip("게임 시작 정보 ID(게임 시작 정보 ID는 게임 시작 정보 고유 숫자와 그 외의 정보를 토대로 IDGenerator에서 생성되어 지급받는다)")]
    [SerializeField, ReadOnly] protected string id;

    [Tooltip("시작 층수")]
    [SerializeField] protected int currentStage;

    [Tooltip("플레이어 캐릭터1")]
    [SerializeField] protected string playerChara1_ID;
    [Tooltip("플레이어 캐릭터2")]
    [SerializeField] protected string playerChara2_ID;
    [Tooltip("플레이어 캐릭터3")]
    [SerializeField] protected string playerChara3_ID;

    [Tooltip("적 캐릭터1")]
    [SerializeField] protected string enemyChara1_ID;
    [Tooltip("적 캐릭터2")]
    [SerializeField] protected string enemyChara2_ID;
    [Tooltip("적 캐릭터3")]
    [SerializeField] protected string enemyChara3_ID;

    #region 람다식 프로퍼티
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

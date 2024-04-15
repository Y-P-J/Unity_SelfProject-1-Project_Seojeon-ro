using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임에서 정보와 관련된 전체적인 흐름을 관리하는 클래스
public class GameProgressManager : Singleton<GameProgressManager>
{
    [Tooltip("현재 스테이지")]
    [SerializeField, ReadOnly] int currentStage = -1;

    [Tooltip("플레이어 캐릭터 그룹")]
    [SerializeField] CharacterGroupController playerCharacter;
    [Tooltip("적 캐릭터 그룹")]
    [SerializeField] CharacterGroupController enemyCharacter;

    #region 람다식 프로퍼티
    public int CurrentStage => currentStage;
    public CharacterGroupController PlayerCharacter => playerCharacter;
    public CharacterGroupController EnemyCharacter => enemyCharacter;
    #endregion

    /// <summary>
    /// GameInitInfo를 통해, 또는 그 외의 경로로 게임을 초기화하는 함수
    /// </summary>
    /// <param name="_id"></param>
    public void Setup(string _id)
    {
        GameInitInfo _info = EntityManager.Instance.CopyEntityByID<GameInitInfo>(_id);

        currentStage = _info.CurrentStage;

        playerCharacter.Setup(_info.PlayerChara1_ID, _info.PlayerChara2_ID, _info.PlayerChara3_ID);

        enemyCharacter.Setup(_info.EnemyChara1_ID, _info.EnemyChara2_ID, _info.EnemyChara3_ID);
    }
}

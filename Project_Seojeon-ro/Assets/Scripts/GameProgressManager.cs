using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ӿ��� ������ ���õ� ��ü���� �帧�� �����ϴ� Ŭ����
public class GameProgressManager : Singleton<GameProgressManager>
{
    [Tooltip("���� ��������")]
    [SerializeField, ReadOnly] int currentStage = -1;

    [Tooltip("�÷��̾� ĳ���� �׷�")]
    [SerializeField] CharacterGroupController playerCharacter;
    [Tooltip("�� ĳ���� �׷�")]
    [SerializeField] CharacterGroupController enemyCharacter;

    #region ���ٽ� ������Ƽ
    public int CurrentStage => currentStage;
    public CharacterGroupController PlayerCharacter => playerCharacter;
    public CharacterGroupController EnemyCharacter => enemyCharacter;
    #endregion

    public void Setup(string _id)
    {
        GameInitInfo _info = EntityManager.Instance.CopyEntityByID<GameInitInfo>(_id);

        currentStage = _info.CurrentStage;

        playerCharacter.Setup(_info.PlayerChara1_ID, _info.PlayerChara2_ID, _info.PlayerChara3_ID);

        //enemyCharacter.Setup(_info.enemyChara1, _info.enemyChara2, _info.enemyChara3);
    }
}

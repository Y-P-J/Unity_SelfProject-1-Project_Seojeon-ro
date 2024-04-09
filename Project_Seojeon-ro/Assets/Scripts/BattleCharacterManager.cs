using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//배틀씬에서 사용되는 캐릭터들을 관리하는 클래스
public class BattleCharacterManager : Singleton<BattleCharacterManager>
{
    [Tooltip("플레이어 캐릭터 그룹")]
    [SerializeField] CharacterGroupController playerCharacter;
    [Tooltip("적 캐릭터 그룹")]
    [SerializeField] CharacterGroupController enemyCharacter;

    void Start()
    {
        string[] _playerCharacterSetting = { "CH0001", "CH0002", "CH0003" };
        playerCharacter.Setup(_playerCharacterSetting);

        //string[] _enemyCharacterSetting = { "CH0004", "CH0005", "CH0006" };
        //enemyCharacter.Setup(_enemyCharacterSetting);
    }
}
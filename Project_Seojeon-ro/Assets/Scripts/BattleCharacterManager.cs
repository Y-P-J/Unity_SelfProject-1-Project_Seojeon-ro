using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ʋ������ ���Ǵ� ĳ���͵��� �����ϴ� Ŭ����
public class BattleCharacterManager : Singleton<BattleCharacterManager>
{
    [Tooltip("�÷��̾� ĳ���� �׷�")]
    [SerializeField] CharacterGroupController playerCharacter;
    [Tooltip("�� ĳ���� �׷�")]
    [SerializeField] CharacterGroupController enemyCharacter;

    void Start()
    {
        string[] _playerCharacterSetting = { "CH0001", "CH0002", "CH0003" };
        playerCharacter.Setup(_playerCharacterSetting);

        //string[] _enemyCharacterSetting = { "CH0004", "CH0005", "CH0006" };
        //enemyCharacter.Setup(_enemyCharacterSetting);
    }
}
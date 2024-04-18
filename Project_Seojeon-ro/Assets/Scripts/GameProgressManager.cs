using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임에서 정보와 관련된 전체적인 흐름을 관리하는 클래스
public class GameProgressManager : Singleton<GameProgressManager>
{
    [Tooltip("현재 스테이지")]
    [SerializeField, ReadOnly] int currentStage = -1;

    [Tooltip("플레이어 캐릭터 그룹")]
    [SerializeField] protected CharacterGroupController playerCharacter;
    [Tooltip("적 캐릭터 그룹")]
    [SerializeField] protected CharacterGroupController enemyCharacter;
    [Tooltip("아이템 인벤토리")]
    [SerializeField] protected Inventory inventory;

    #region 람다식 프로퍼티
    public int CurrentStage => currentStage;
    public CharacterGroupController PlayerCharacter => playerCharacter;
    public CharacterGroupController EnemyCharacter => enemyCharacter;
    public Inventory Inventory => inventory;
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

        inventory.Setup();
    }

    /// <summary>
    /// 캐릭터와 인벤토리의 아이템을 교환하는 함수
    /// </summary>
    public void SwitchItem(int _charaIndex, int _invenIndex)
    {
        CharacterInfo _character = playerCharacter.CharacterGroup[_charaIndex];
        EquipInfo _item = inventory.Items[_invenIndex];

        if (_item is WeaponInfo _weapon)
        {
            for(int i = 0; i < _character.WeaponTypes.Length; i++)
            {
                if (_character.WeaponTypes[i] == _weapon.WeaponType)
                {
                    inventory.Items[_invenIndex] = _character.SwitchWeapon(_weapon);
                    break;
                }
            }
        }
        else if (_item is WearInfo _wear)
        {
            inventory.Items[_invenIndex] = _character.SwitchWear(_wear);
        }

        inventory.SortInventory();
    }
}

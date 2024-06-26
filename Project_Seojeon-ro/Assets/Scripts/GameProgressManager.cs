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
    /// 인벤토리에서 아이템을 교환하는 함수
    /// </summary>
    public void SwitchItemForInven(int _charaIndex, int _invenIndex)
    {
        CharacterInfo _character = playerCharacter.CharacterGroup[_charaIndex];
        EquipInfo _item = inventory.Items[_invenIndex];

        if (_item is WeaponInfo _weapon)
        {
            for (int i = 0; i < _character.WeaponTypes.Length; i++)
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
            for (int i = 0; i < _character.HelmetTypes.Length; i++)
            {
                if (_character.HelmetTypes[i] == _wear.WearType)
                {
                    inventory.Items[_invenIndex] = _character.SwitchHelmet(_wear);
                    break;
                }
            }
            for (int i = 0; i < _character.ArmorTypes.Length; i++)
            {
                if (_character.ArmorTypes[i] == _wear.WearType)
                {
                    inventory.Items[_invenIndex] = _character.SwitchArmor(_wear);
                    break;
                }
            }
            for (int i = 0; i < _character.GloveTypes.Length; i++)
            {
                if (_character.GloveTypes[i] == _wear.WearType)
                {
                    inventory.Items[_invenIndex] = _character.SwitchGloves(_wear);
                    break;
                }
            }
            for (int i = 0; i < _character.ShoesTypes.Length; i++)
            {
                if (_character.ShoesTypes[i] == _wear.WearType)
                {
                    inventory.Items[_invenIndex] = _character.SwitchShoes(_wear);
                    break;
                }
            }
            for (int i = 0; i < _character.RingTypes.Length; i++)
            {
                if (_character.RingTypes[i] == _wear.WearType)
                {
                    inventory.Items[_invenIndex] = _character.SwitchRing(_wear);
                    break;
                }
            }
        }

        inventory.SortInventory();
    }

    /// <summary>
    /// 장비창에서 아이템을 교환하는 함수
    /// </summary>
    public void SwitchItemForEquip(int _charaIndex, int _EquipIndex)
    {
        CharacterInfo _character = playerCharacter.CharacterGroup[_charaIndex];

        int _index = -1;

        for (int i = 0; i < inventory.Items.Length; i++)
        {
            if (inventory.Items[i].ID.EndsWith("0"))
            {
                _index = i;
                break;
            }
        }

        if (_index == -1)
            return;

        switch (_EquipIndex)
        {
            case 0:
                inventory.Items[_index] = _character.SwitchWeapon(EntityManager.Instance.CopyEntityByID<WeaponInfo>("WP0000000000"));
                break;
            case 1:
                inventory.Items[_index] = _character.SwitchHelmet(EntityManager.Instance.CopyEntityByID<WearInfo>("WE0000000000"));
                break;
            case 2:
                inventory.Items[_index] = _character.SwitchArmor(EntityManager.Instance.CopyEntityByID<WearInfo>("WE0000000000"));
                break;
            case 3:
                inventory.Items[_index] = _character.SwitchGloves(EntityManager.Instance.CopyEntityByID<WearInfo>("WE0000000000"));
                break;
            case 4:
                inventory.Items[_index] = _character.SwitchShoes(EntityManager.Instance.CopyEntityByID<WearInfo>("WE0000000000"));
                break;
            case 5:
                inventory.Items[_index] = _character.SwitchRing(EntityManager.Instance.CopyEntityByID<WearInfo>("WE0000000000"));
                break;
        }

        inventory.SortInventory();
    }
}

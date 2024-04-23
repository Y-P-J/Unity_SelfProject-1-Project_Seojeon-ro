using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ӿ��� ������ ���õ� ��ü���� �帧�� �����ϴ� Ŭ����
public class GameProgressManager : Singleton<GameProgressManager>
{
    [Tooltip("���� ��������")]
    [SerializeField, ReadOnly] int currentStage = -1;

    [Tooltip("�÷��̾� ĳ���� �׷�")]
    [SerializeField] protected CharacterGroupController playerCharacter;
    [Tooltip("�� ĳ���� �׷�")]
    [SerializeField] protected CharacterGroupController enemyCharacter;
    [Tooltip("������ �κ��丮")]
    [SerializeField] protected Inventory inventory;

    #region ���ٽ� ������Ƽ
    public int CurrentStage => currentStage;
    public CharacterGroupController PlayerCharacter => playerCharacter;
    public CharacterGroupController EnemyCharacter => enemyCharacter;
    public Inventory Inventory => inventory;
    #endregion

    /// <summary>
    /// GameInitInfo�� ����, �Ǵ� �� ���� ��η� ������ �ʱ�ȭ�ϴ� �Լ�
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
    /// �κ��丮���� �������� ��ȯ�ϴ� �Լ�
    /// </summary>
    public void SwitchItemForInven(int _charaIndex, int _invenIndex)
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

    /// <summary>
    /// ���â���� �������� ��ȯ�ϴ� �Լ�
    /// </summary>
    public void SwitchItemForEquip(int _charaIndex, int _EquipIndex)
    {
        CharacterInfo _character = playerCharacter.CharacterGroup[_charaIndex];

        EquipInfo _item = null;
        int _index= -1;
        for (int i = 0; i < inventory.Items.Length; i++)
        {
            if (inventory.Items[i].ID.EndsWith("0"))
            {
                _item = inventory.Items[i];
                _index = i;
                break;
            }
        }

        if(_item == null)
            return;

        if (_item is WeaponInfo _weapon)
            inventory.Items[_index] = _character.SwitchWeapon(_weapon);
        else if (_item is WearInfo _wear)
            inventory.Items[_index] = _character.SwitchWear(_wear);

        inventory.SortInventory();
    }
}

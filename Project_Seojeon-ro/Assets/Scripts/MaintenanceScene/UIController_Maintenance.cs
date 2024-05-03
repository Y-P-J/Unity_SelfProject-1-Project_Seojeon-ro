using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//�����׳ͽ� ���� UI�� �����ϴ� Ŭ����
public class UIController_Maintenance : MonoBehaviour
{
    [Tooltip("���� ������ ǥ���ϴ� UI")]
    [SerializeField] TMP_Text floorCountUI;

    [Header("ĳ���� ��� ���� �� ��ư")]
    [Tooltip("ĳ���� ��ư��")]
    [SerializeField] Button[] charaButton;
    [Tooltip("ĳ���� ��ǥ �̹���")]
    [SerializeField] Image[] charaRepImages;
    [Tooltip("ĳ���� �̸� �ؽ�Ʈ")]
    [SerializeField] TMP_Text[] charaNameTexts;
    [Tooltip("ĳ���� HP �ؽ�Ʈ")]
    [SerializeField] TMP_Text[] charaLevelTexts;

    [Tooltip("���� ���õ� ĳ����")]
    [SerializeField, ReadOnly] int selectedCharaIndex;

    [Header("ĳ���� ���/���� ����")]
    [Tooltip("�������� ��� �̹���")]//0:����, 1:���, 2:����, 3:�尩, 4:�Ź�, 5:����
    [SerializeField] Image[] equipImages;
    [Tooltip("���� ����")]//0:����, 1:ü��, 2:����, 3:�ӵ�, 4:���ݷ�, 5:����, 6:ġ���, 7:ȸ����
    [SerializeField] TMP_Text[] detailStatusTexts;

    [Header("ĳ���� ��ų ����")]
    [Tooltip("��ų ���� UI")]
    [SerializeField] Image[] skillImages;
    [Tooltip("��ų �̸� �ؽ�Ʈ")]
    [SerializeField] TMP_Text[] skillNameTexts;
    [Tooltip("��ų ���� �ؽ�Ʈ")]
    [SerializeField] TMP_Text[] skillDescriptionTexts;
    [Tooltip("��ų ���� �Ҹ� �ؽ�Ʈ")]
    [SerializeField] TMP_Text[] skillUseManaTexts;
    [Tooltip("��ų ��Ÿ�� �ؽ�Ʈ")]
    [SerializeField] TMP_Text[] skillCooldownTexts;

    [Header("�κ��丮")]
    [Tooltip("�κ��丮 UI")]
    [SerializeField] GameObject inventoryUI;
    [Tooltip("�κ��丮 �̹�����")]
    [SerializeField, ReadOnly] Image[] inventoryImages;

    [Header("������ ����")]
    [Tooltip("������ ���� UI")]
    [SerializeField] GameObject itemDescriptionUI;
    [Tooltip("������ ��ǥ �̹���")]
    [SerializeField] Image itemRepImage;
    [Tooltip("������ �̸� �ؽ�Ʈ")]
    [SerializeField] TMP_Text itemNameText;
    [Tooltip("������ Ÿ�� �ؽ�Ʈ")]
    [SerializeField] TMP_Text itemTypeText;
    [Tooltip("������ ���� ���ɿ��� �ؽ�Ʈ")]
    [SerializeField] TMP_Text itemIsEquipText;
    [Tooltip("������ ǰ�� �ؽ�Ʈ")]
    [SerializeField] TMP_Text itemQuiltyText;
    [Tooltip("������ ���� �ؽ�Ʈ")]
    [SerializeField] TMP_Text itemDescriptionText;
    [SerializeField] TMP_Text itemAttackText;
    [SerializeField] TMP_Text itemDefenseText;
    [SerializeField] TMP_Text itemCriticalText;
    [SerializeField] TMP_Text itemAvoidText;
    [SerializeField] TMP_Text itemHpText;
    [SerializeField] TMP_Text itemMpText;
    [SerializeField] TMP_Text itemSpeedText;

    [Header("�� ��� ����")]
    [Tooltip("�� ��ǥ �̹���")]
    [SerializeField] Image[] enemyRepImages;
    [Tooltip("�� ���� �ؽ�Ʈ")]
    [SerializeField] TMP_Text[] enemyLevelTexts;

    [Tooltip("��ư ���ſ� ����")]
    GameObject lastSelect;

    #region ���ٽ� ������Ƽ
    public Image[] EquipImages => equipImages;
    public Image[] InventoryImages => inventoryImages;
    #endregion

    void Update()
    {
        //�κ��丮 ������ Ŭ���� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData _event = new PointerEventData(EventSystem.current);
            _event.position = Input.mousePosition;
            List<RaycastResult> _ray = new List<RaycastResult>();
            EventSystem.current.RaycastAll(_event, _ray);

            if(_ray.Count == 0)
                return;

            if (_ray[0].gameObject.name == inventoryImages[0].gameObject.name)
            {
                for (int i = 0; i < inventoryImages.Length; i++)
                {
                    if (_ray[0].gameObject == inventoryImages[i].gameObject)
                    {
                        GameProgressManager.Instance.SwitchItemForInven(selectedCharaIndex, i);
                        UpdateItemDescriptionUI(-1, false);
                        UpdateCharaInfoUI();
                        UpdateInventoryUI();
                        break;
                    }
                }
            }
            else if (_ray[0].gameObject.name == equipImages[0].gameObject.name)
            {
                for (int i = 0; i < equipImages.Length; i++)
                {
                    if (_ray[0].gameObject == equipImages[i].gameObject)
                    {
                        GameProgressManager.Instance.SwitchItemForEquip(selectedCharaIndex, i);
                        UpdateItemDescriptionUI(-1, false);
                        UpdateCharaInfoUI();
                        UpdateInventoryUI();
                        break;
                    }
                }
            }
        }
    }

    void OnEnable()
    {
        //���� ������ ǥ��
        floorCountUI.text = GameProgressManager.Instance.CurrentStage.ToString();

        #region ĳ���� ���� UI ����
        //ĳ���� ���� UI ����
        for (int i = 0; i < GameProgressManager.Instance.PlayerCharacter.CharacterGroup.Length; i++)
        {
            charaRepImages[i].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].RepImage;
            charaNameTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].CharacterName;
            charaLevelTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].Level.ToString();
        }

        //ĳ���� ��ư�� �̺�Ʈ �߰�
        charaButton[0].Select();
        CheckCharaButtonClick();
        #endregion

        #region �κ��丮 UI ����
        inventoryImages = new Image[30];
        //�κ��丮 UI�� ��� ������Ʈ�� ������
        Transform[] _object = inventoryUI.GetComponentsInChildren<Transform>();
        List<Transform> _Items = new List<Transform>();

        foreach (Transform _item in _object)//���� ItemIcon�̶�� �̸��� ���� ������Ʈ�� ������
        {
            if (_item.name == "ItemIcon")
                _Items.Add(_item);
        }

        for (int i = 0; i < _Items.Count; i++)//�׷��� ������ ������Ʈ���� �ٽ� �迭�� �־���
            inventoryImages[i] = _Items[i].GetComponent<Image>();

        UpdateInventoryUI();
        #endregion

        //�� ���� UI ����
        UpdateEnemyInfoUI();
    }

    /// <summary>
    /// ĳ���͹�ư Ŭ���� ȣ��Ǵ� �Լ�
    /// </summary>
    public void CheckCharaButtonClick()
    {
        int _index = -1;

        for (int i = 0; i < charaButton.Length; i++)
        {
            if (charaButton[i].gameObject == EventSystem.current.currentSelectedGameObject)
                _index = i;
        }

        if (_index == -1)
        {
            LogHandler.WriteLog("�˸´� ��ư �ε����� �ƴϰų�, ã�� ���߽��ϴ�.", this.GetType().Name, LogType.Error, true);
            return;
        }

        selectedCharaIndex = _index;

        UpdateCharaInfoUI();
    }

    /// <summary>
    /// ĳ���� ���� UI�� �����ϴ� �Լ�
    /// </summary>
    readonly Color selectedColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    readonly Color unselectedColor = new Color(1f, 1f, 1f, 1f);
    public void UpdateCharaInfoUI()
    {
        for(int i =0;charaButton.Length > i; i++)
        {
            if(i == selectedCharaIndex)
            {
                charaButton[i].gameObject.GetComponent<Image>().color = selectedColor;
            }
            else
            {
                charaButton[i].gameObject.GetComponent<Image>().color = unselectedColor;
            }
        }

        CharacterInfo _chara = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex];

        if (_chara.Weapon.ID.EndsWith("0"))
            equipImages[0].gameObject.SetActive(false);
        else
        {
            equipImages[0].sprite = _chara.Weapon.RepImage;
            equipImages[0].gameObject.SetActive(true);
        }

        if(_chara.Helmet.ID.EndsWith("0"))
            equipImages[1].gameObject.SetActive(false);
        else
        {
            equipImages[1].sprite = _chara.Helmet.RepImage;
            equipImages[1].gameObject.SetActive(true);
        }

        if (_chara.Armor.ID.EndsWith("0"))
            equipImages[2].gameObject.SetActive(false);
        else
        {
            equipImages[2].sprite = _chara.Armor.RepImage;
            equipImages[2].gameObject.SetActive(true);
        }

        if (_chara.Gloves.ID.EndsWith("0"))
            equipImages[3].gameObject.SetActive(false);
        else
        {
            equipImages[3].sprite = _chara.Gloves.RepImage;
            equipImages[3].gameObject.SetActive(true);
        }

        if (_chara.Shoes.ID.EndsWith("0"))
            equipImages[4].gameObject.SetActive(false);
        else
        {
            equipImages[4].sprite = _chara.Shoes.RepImage;
            equipImages[4].gameObject.SetActive(true);
        }

        if (_chara.Ring.ID.EndsWith("0"))
            equipImages[5].gameObject.SetActive(false);
        else
        {
            equipImages[5].sprite = _chara.Ring.RepImage;
            equipImages[5].gameObject.SetActive(true);
        }

        detailStatusTexts[0].text = _chara.Level.ToString();
        detailStatusTexts[1].text = _chara.FinalStatus.hp.ToString();
        detailStatusTexts[2].text = _chara.FinalStatus.mp.ToString();
        detailStatusTexts[3].text = _chara.FinalStatus.speed.ToString();
        detailStatusTexts[4].text = _chara.FinalStatus.attack.ToString();
        detailStatusTexts[5].text = _chara.FinalStatus.defense.ToString();
        detailStatusTexts[6].text = _chara.FinalStatus.critical.ToString();
        detailStatusTexts[7].text = _chara.FinalStatus.avoid.ToString();

        for (int i = 0; i < skillImages.Length; i++)
        {
            skillImages[i].sprite = _chara.FirstSkill.RepImage;
            skillNameTexts[i].text = _chara.FirstSkill.SkillName;
            skillDescriptionTexts[i].text = _chara.FirstSkill.DescriptionForUI;
            skillUseManaTexts[i].text = _chara.FirstSkill.MpCost.ToString();
            skillCooldownTexts[i].text = _chara.FirstSkill.Cooldown.ToString();
        }
    }

    /// <summary>
    /// �κ��丮 UI�� �����ϴ� �Լ�
    /// </summary>
    public void UpdateInventoryUI()
    {
        for (int i = 0; i < inventoryImages.Length; i++)
        {
            if (GameProgressManager.Instance.Inventory.Items[i].ID.EndsWith("0"))
                inventoryImages[i].gameObject.SetActive(false);
            else
            {
                inventoryImages[i].sprite = GameProgressManager.Instance.Inventory.Items[i].RepImage;
                inventoryImages[i].gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// ������ ���� UI�� �����ϴ� �Լ�
    /// </summary>
    public void UpdateItemDescriptionUI(int _index, bool _b, bool _isInven = true)
    {
        if (!_b)
        {
            itemDescriptionUI.SetActive(false);

            return;
        }

        RectTransform _description = itemDescriptionUI.GetComponent<RectTransform>();

        if (_isInven)
        {
            RectTransform _itemImage = inventoryImages[_index].GetComponent<RectTransform>();

            _description.position = _itemImage.position;

            if (_index < 15)
                _description.anchoredPosition += new Vector2(0f, -_description.rect.height / 2f + -_itemImage.rect.height / 2f);
            else
                _description.anchoredPosition += new Vector2(0f, _description.rect.height / 2f + _itemImage.rect.height / 2f);

            _description.anchoredPosition = new Vector2(
                Mathf.Clamp(_description.anchoredPosition.x, -Screen.width / 2 + _description.rect.width / 2, Screen.width / 2 - _description.rect.width / 2),
                _description.anchoredPosition.y);

            EquipInfo _item = GameProgressManager.Instance.Inventory.Items[_index];

            itemRepImage.sprite = _item.RepImage;
            itemNameText.text = _item.EquipName;
            itemIsEquipText.gameObject.SetActive(true);

            if (_item is WeaponInfo _weaponItem)
            {
                itemTypeText.text = _weaponItem.WeaponTypeToString();
                for (int i = 0; i < GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].WeaponTypes.Length; i++)
                {
                    if (GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].WeaponTypes[i] == _weaponItem.WeaponType)
                    {
                        itemIsEquipText.gameObject.SetActive(false);
                        break;
                    }
                }
            }
            else if (_item is WearInfo _wearItem)
            {
                itemTypeText.text = _wearItem.WearTypeToString();
                for (int i = 0; i < GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].HelmetTypes.Length; i++)
                {
                    if (GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].HelmetTypes[i] == _wearItem.WearType)
                    {
                        itemIsEquipText.gameObject.SetActive(false);
                        break;
                    }
                }
                for (int i = 0; i < GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].ArmorTypes.Length; i++)
                {
                    if (GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].ArmorTypes[i] == _wearItem.WearType)
                    {
                        itemIsEquipText.gameObject.SetActive(false);
                        break;
                    }
                }
                for (int i = 0; i < GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].GloveTypes.Length; i++)
                {
                    if (GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].GloveTypes[i] == _wearItem.WearType)
                    {
                        itemIsEquipText.gameObject.SetActive(false);
                        break;
                    }
                }
                for (int i = 0; i < GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].ShoesTypes.Length; i++)
                {
                    if (GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].ShoesTypes[i] == _wearItem.WearType)
                    {
                        itemIsEquipText.gameObject.SetActive(false);
                        break;
                    }
                }
                for (int i = 0; i < GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].RingTypes.Length; i++)
                {
                    if (GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].RingTypes[i] == _wearItem.WearType)
                    {
                        itemIsEquipText.gameObject.SetActive(false);
                        break;
                    }
                }
            }

            itemQuiltyText.text = _item.QualityToString();
            itemDescriptionText.text = _item.Description;
            itemAttackText.text = _item.Status.attack.ToString();
            itemDefenseText.text = _item.Status.defense.ToString();
            itemCriticalText.text = _item.Status.critical.ToString();
            itemAvoidText.text = _item.Status.avoid.ToString();
            itemHpText.text = _item.Status.hp.ToString();
            itemMpText.text = _item.Status.mp.ToString();
            itemSpeedText.text = _item.Status.speed.ToString();

            itemDescriptionUI.SetActive(true);
        }
        else
        {
            RectTransform _image = equipImages[_index].GetComponent<RectTransform>();

            _description.position = _image.position;
            _description.anchoredPosition += new Vector2(0f, -_description.rect.height / 2f + -_image.rect.height / 2f);
            _description.anchoredPosition = new Vector2(
                Mathf.Clamp(_description.anchoredPosition.x, -Screen.width / 2 + _description.rect.width / 2, Screen.width / 2 - _description.rect.width / 2),
                _description.anchoredPosition.y);

            EquipInfo _item;

            switch (_index)
            {
                case 0:
                    _item = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Weapon;
                    break;
                case 1:
                    _item = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Helmet;
                    break;
                case 2:
                    _item = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Armor;
                    break;
                case 3:
                    _item = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Gloves;
                    break;
                case 4:
                    _item = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Shoes;
                    break;
                case 5:
                    _item = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Ring;
                    break;
                default:
                    return;
            }

            itemRepImage.sprite = _item.RepImage;
            itemNameText.text = _item.EquipName;
            if (_item is WeaponInfo _weaponItem)
                itemTypeText.text = _weaponItem.WeaponTypeToString();
            else if (_item is WearInfo _wearItem)
                itemTypeText.text = _wearItem.WearTypeToString();
            itemIsEquipText.gameObject.SetActive(false);
            itemQuiltyText.text = _item.QualityToString();
            itemDescriptionText.text = _item.Description;
            itemAttackText.text = _item.Status.attack.ToString();
            itemDefenseText.text = _item.Status.defense.ToString();
            itemCriticalText.text = _item.Status.critical.ToString();
            itemAvoidText.text = _item.Status.avoid.ToString();
            itemHpText.text = _item.Status.hp.ToString();
            itemMpText.text = _item.Status.mp.ToString();
            itemSpeedText.text = _item.Status.speed.ToString();

            itemDescriptionUI.SetActive(true);
        }
    }

    /// <summary>
    /// �� ���� UI�� �����ϴ� �Լ�
    /// </summary>
    public void UpdateEnemyInfoUI()
    {
        for (int i = 0; i < GameProgressManager.Instance.EnemyCharacter.CharacterGroup.Length; i++)
        {
            enemyRepImages[i].sprite = GameProgressManager.Instance.EnemyCharacter.CharacterGroup[i].RepImage;
            enemyLevelTexts[i].text = GameProgressManager.Instance.EnemyCharacter.CharacterGroup[i].Level.ToString();
        }
    }
}

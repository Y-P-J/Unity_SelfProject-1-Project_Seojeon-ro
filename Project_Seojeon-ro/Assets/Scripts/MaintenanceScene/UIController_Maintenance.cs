using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

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
                for(int i =0;i<equipImages.Length;i++)
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

        equipImages[0].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Weapon.RepImage;
        equipImages[1].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Helmet.RepImage;
        equipImages[2].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Armor.RepImage;
        equipImages[3].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Gloves.RepImage;
        equipImages[4].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Shoes.RepImage;
        equipImages[5].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Ring.RepImage;

        detailStatusTexts[0].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Level.ToString();
        detailStatusTexts[1].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.hp.ToString();
        detailStatusTexts[2].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.mp.ToString();
        detailStatusTexts[3].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.speed.ToString();
        detailStatusTexts[4].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.attack.ToString();
        detailStatusTexts[5].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.defense.ToString();
        detailStatusTexts[6].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.critical.ToString();
        detailStatusTexts[7].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.avoid.ToString();

        for (int i = 0; i < skillImages.Length; i++)
        {
            skillImages[i].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FirstSkill.RepImage;
            skillNameTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FirstSkill.SkillName;
            skillDescriptionTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FirstSkill.DescriptionForUI;
            skillUseManaTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FirstSkill.MpCost.ToString();
            skillCooldownTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FirstSkill.Cooldown.ToString();
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
                inventoryImages[i].sprite = GameProgressManager.Instance.Inventory.Items[i].RepImage;
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

        if (_isInven)
        {
            RectTransform _description = itemDescriptionUI.GetComponent<RectTransform>();
            RectTransform _image = inventoryImages[_index].GetComponent<RectTransform>();
            RectTransform _inventory = inventoryUI.GetComponent<RectTransform>();

            if (_index < 15)
                _description.position = new Vector2(_inventory.position.x, _inventory.position.y - (_description.sizeDelta.y * 0.5f));
            else
                _description.position = new Vector2(_inventory.position.x, _inventory.position.y + (_description.sizeDelta.y * 0.5f));

            itemRepImage.sprite = GameProgressManager.Instance.Inventory.Items[_index].RepImage;
            itemNameText.text = GameProgressManager.Instance.Inventory.Items[_index].EquipName;
            if (GameProgressManager.Instance.Inventory.Items[_index] is WeaponInfo _weaponItem)
                itemTypeText.text = _weaponItem.WeaponTypeToString();
            else if (GameProgressManager.Instance.Inventory.Items[_index] is WearInfo _wearItem)
                itemTypeText.text = _wearItem.WearTypeToString();
            itemQuiltyText.text = GameProgressManager.Instance.Inventory.Items[_index].QualityToString();
            itemDescriptionText.text = GameProgressManager.Instance.Inventory.Items[_index].Description;
            itemAttackText.text = GameProgressManager.Instance.Inventory.Items[_index].Status.attack.ToString();
            itemDefenseText.text = GameProgressManager.Instance.Inventory.Items[_index].Status.defense.ToString();
            itemCriticalText.text = GameProgressManager.Instance.Inventory.Items[_index].Status.critical.ToString();
            itemAvoidText.text = GameProgressManager.Instance.Inventory.Items[_index].Status.avoid.ToString();
            itemHpText.text = GameProgressManager.Instance.Inventory.Items[_index].Status.hp.ToString();
            itemMpText.text = GameProgressManager.Instance.Inventory.Items[_index].Status.mp.ToString();
            itemSpeedText.text = GameProgressManager.Instance.Inventory.Items[_index].Status.speed.ToString();

            itemDescriptionUI.SetActive(true);
        }
        else
        {
            Debug.Log("�������� ȣ��");
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

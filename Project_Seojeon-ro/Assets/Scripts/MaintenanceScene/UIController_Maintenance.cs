using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
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
    [SerializeField] Image[] equipImage;
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
    [SerializeField] GameObject inventoryUI;
    [SerializeField, ReadOnly] Image[] inventoryImages;

    [Header("�� ��� ����")]
    [Tooltip("�� ��ǥ �̹���")]
    [SerializeField] Image[] enemyRepImages;
    [Tooltip("�� ���� �ؽ�Ʈ")]
    [SerializeField] TMP_Text[] enemyLevelTexts;

    [Tooltip("��ư ���ſ� ����")]
    GameObject lastSelect;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData _event = new PointerEventData(EventSystem.current);
            _event.position = Input.mousePosition;
            List<RaycastResult> _ray = new List<RaycastResult>();
            EventSystem.current.RaycastAll(_event, _ray);

            foreach (RaycastResult ray in _ray)
            {
                if (ray.gameObject.name != "ItemIcon")
                    continue;

                for (int i = 0; i < inventoryImages.Length; i++)
                {
                    if (ray.gameObject == inventoryImages[i].gameObject)
                    {
                        Inventory.Instance.SwitchItem(i);
                        break;
                    }
                }
            }

        }

        //���õ� ������Ʈ�� ���ٸ� ���������� ���õ� ������Ʈ�� ����
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelect);
        }
        else//���õ� ������Ʈ�� �ִٸ� ���������� ���õ� ������Ʈ�� ����
        {
            lastSelect = EventSystem.current.currentSelectedGameObject;
        }
        //�� ������ ���� ���콺�� ���õ� ������Ʈ�� ���� ��, ���������� ���õ� ������Ʈ�� �����ϰ� ��
    }

    void OnEnable()
    {
        //���� ������ ǥ��
        floorCountUI.text = GameProgressManager.Instance.CurrentStage.ToString();

        //ĳ���� ���� UI ����
        for (int i = 0; i < GameProgressManager.Instance.PlayerCharacter.CharacterGroup.Length; i++)
        {
            charaRepImages[i].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].RepImage;
            charaNameTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].CharacterName;
            charaLevelTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].Level.ToString();
        }

        //ĳ���� ��ư�� �̺�Ʈ �߰�
        charaButton[0].Select();
        UpdateCharaInfoUI();

        inventoryImages = new Image[30];

        Transform[] _object = inventoryUI.GetComponentsInChildren<Transform>();//�κ��丮 UI�� ��� ������Ʈ�� ������
        List<Transform> _Items = new List<Transform>();

        foreach(Transform _item in _object)//���� ItemIcon�̶�� �̸��� ���� ������Ʈ�� ������
        {
            if (_item.name == "ItemIcon")
                _Items.Add(_item);
        }

        for(int i = 0; i< _Items.Count; i++)//�׷��� ������ ������Ʈ���� �ٽ� �迭�� �־���
        {
            inventoryImages[i] = _Items[i].GetComponent<Image>();
            inventoryImages[i].sprite = Inventory.Instance.Items[i].RepImage;
        }

        //�� ���� UI ����
        for (int i = 0; i < GameProgressManager.Instance.EnemyCharacter.CharacterGroup.Length; i++)
        {
            enemyRepImages[i].sprite = GameProgressManager.Instance.EnemyCharacter.CharacterGroup[i].RepImage;
            enemyLevelTexts[i].text = GameProgressManager.Instance.EnemyCharacter.CharacterGroup[i].Level.ToString();
        }
    }

    /// <summary>
    /// ĳ���� ���� UI�� �����ϴ� �Լ�
    /// </summary>
    public void UpdateCharaInfoUI()
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

        equipImage[0].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Weapon.RepImage;
        equipImage[1].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Helmet.RepImage;
        equipImage[2].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Armor.RepImage;
        equipImage[3].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Gloves.RepImage;
        equipImage[4].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Shoes.RepImage;
        equipImage[5].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Ring.RepImage;

        detailStatusTexts[0].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].Level.ToString();
        detailStatusTexts[1].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.hp.ToString();
        detailStatusTexts[2].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.mp.ToString();
        detailStatusTexts[3].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.speed.ToString();
        detailStatusTexts[4].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.attack.ToString();
        detailStatusTexts[5].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.defense.ToString();
        detailStatusTexts[6].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.critical.ToString();
        detailStatusTexts[7].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FinalStatus.avoid.ToString();

        for(int i = 0; i < skillImages.Length; i++)
        {
            skillImages[i].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FirstSkill.RepImage;
            skillNameTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FirstSkill.SkillName;
            skillDescriptionTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FirstSkill.DescriptionForUI;
            skillUseManaTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FirstSkill.MpCost.ToString();
            skillCooldownTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[selectedCharaIndex].FirstSkill.Cooldown.ToString();
        }
    }
}

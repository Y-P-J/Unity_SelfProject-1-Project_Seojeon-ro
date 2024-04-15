using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    [Header("ĳ���� ����")]
    [Tooltip("�������� ��� �̹���")]//0:����, 1:���, 2:����, 3:�尩, 4:�Ź�, 5:����
    [SerializeField] Image[] equipImage;
    [Tooltip("���� ����")]//0:����, 1:ü��, 2:����, 3:�ӵ�, 4:���ݷ�, 5:����, 6:ġ���, 7:ȸ����
    [SerializeField] TMP_Text[] detailStatusTexts;


    [Header("�� ��� ����")]
    [Tooltip("�� ��ǥ �̹���")]
    [SerializeField] Image[] enemyRepImages;
    [Tooltip("�� ���� �ؽ�Ʈ")]
    [SerializeField] TMP_Text[] enemyLevelTexts;

    [Tooltip("��ư ���ſ� ����")]
    GameObject lastSelect;

    void Update()
    {
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
        int index = -1;

        for (int i = 0; i < charaButton.Length; i++)
        {
            if (charaButton[i].gameObject == EventSystem.current.currentSelectedGameObject)
                index = i;
        }

        if (index == -1)
        {
            LogHandler.WriteLog("�˸´� ��ư �ε����� �ƴϰų�, ã�� ���߽��ϴ�.", this.GetType().Name, LogType.Error, true);
            return;
        }

        UnityEngine.Debug.Log(index + "����");

        equipImage[0].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].Weapon.RepImage;
        equipImage[1].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].Helmet.RepImage;
        equipImage[2].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].Armor.RepImage;
        equipImage[3].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].Gloves.RepImage;
        equipImage[4].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].Shoes.RepImage;
        equipImage[5].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].Ring.RepImage;

        detailStatusTexts[0].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].Level.ToString();
        detailStatusTexts[1].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].FinalStatus.hp.ToString();
        detailStatusTexts[2].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].FinalStatus.mp.ToString();
        detailStatusTexts[3].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].FinalStatus.speed.ToString();
        detailStatusTexts[4].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].FinalStatus.attack.ToString();
        detailStatusTexts[5].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].FinalStatus.defense.ToString();
        detailStatusTexts[6].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].FinalStatus.critical.ToString();
        detailStatusTexts[7].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[index].FinalStatus.avoid.ToString();
    }
}

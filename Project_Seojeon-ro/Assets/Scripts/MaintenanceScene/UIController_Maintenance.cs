using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//메인테넌스 씬의 UI를 관리하는 클래스
public class UIController_Maintenance : MonoBehaviour
{
    [Tooltip("현재 층수를 표시하는 UI")]
    [SerializeField] TMP_Text floorCountUI;

    [Header("캐릭터 요약 정보 및 버튼")]
    [Tooltip("캐릭터 버튼들")]
    [SerializeField] Button[] charaButton;
    [Tooltip("캐릭터 대표 이미지")]
    [SerializeField] Image[] charaRepImages;
    [Tooltip("캐릭터 이름 텍스트")]
    [SerializeField] TMP_Text[] charaNameTexts;
    [Tooltip("캐릭터 HP 텍스트")]
    [SerializeField] TMP_Text[] charaLevelTexts;

    [Header("캐릭터 정보")]
    [Tooltip("장착중인 장비 이미지")]//0:무기, 1:헬멧, 2:갑옷, 3:장갑, 4:신발, 5:반지
    [SerializeField] Image[] equipImage;
    [Tooltip("세부 스텟")]//0:레벨, 1:체력, 2:마력, 3:속도, 4:공격력, 5:방어력, 6:치명률, 7:회피율
    [SerializeField] TMP_Text[] detailStatusTexts;


    [Header("적 요약 정보")]
    [Tooltip("적 대표 이미지")]
    [SerializeField] Image[] enemyRepImages;
    [Tooltip("적 레벨 텍스트")]
    [SerializeField] TMP_Text[] enemyLevelTexts;

    [Tooltip("버튼 갱신용 변수")]
    GameObject lastSelect;

    void Update()
    {
        //선택된 오브젝트가 없다면 마지막으로 선택된 오브젝트를 선택
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelect);
        }
        else//선택된 오브젝트가 있다면 마지막으로 선택된 오브젝트를 갱신
        {
            lastSelect = EventSystem.current.currentSelectedGameObject;
        }
        //이 과정을 통해 마우스로 선택된 오브젝트가 없을 때, 마지막으로 선택된 오브젝트를 선택하게 함
    }

    void OnEnable()
    {
        //현재 층수를 표시
        floorCountUI.text = GameProgressManager.Instance.CurrentStage.ToString();

        //캐릭터 정보 UI 갱신
        for (int i = 0; i < GameProgressManager.Instance.PlayerCharacter.CharacterGroup.Length; i++)
        {
            charaRepImages[i].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].RepImage;
            charaNameTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].CharacterName;
            charaLevelTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].Level.ToString();
        }

        //캐릭터 버튼에 이벤트 추가
        charaButton[0].Select();
        UpdateCharaInfoUI();

        //적 정보 UI 갱신
        for (int i = 0; i < GameProgressManager.Instance.EnemyCharacter.CharacterGroup.Length; i++)
        {
            enemyRepImages[i].sprite = GameProgressManager.Instance.EnemyCharacter.CharacterGroup[i].RepImage;
            enemyLevelTexts[i].text = GameProgressManager.Instance.EnemyCharacter.CharacterGroup[i].Level.ToString();
        }
    }

    /// <summary>
    /// 캐릭터 정보 UI를 갱신하는 함수
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
            LogHandler.WriteLog("알맞는 버튼 인덱스가 아니거나, 찾지 못했습니다.", this.GetType().Name, LogType.Error, true);
            return;
        }

        UnityEngine.Debug.Log(index + "상태");

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

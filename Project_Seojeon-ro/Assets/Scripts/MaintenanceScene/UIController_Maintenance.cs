using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//메인테넌스 씬의 UI를 관리하는 클래스
public class UIController_Maintenance : MonoBehaviour
{
    [Tooltip("현재 층수를 표시하는 UI")]
    [SerializeField] TMP_Text floorCountUI;

    //버튼 넣고, 현재 버튼상황 넣고, 이미지 톤 바꿔서 적용시키기

    [Tooltip("캐릭터 버튼 간편 정보")]
    [SerializeField] Image[] charaRepImages;
    [SerializeField] TMP_Text[] charaNameTexts;
    [SerializeField] TMP_Text[] CharaHPTexts;

    void OnEnable()
    {
        floorCountUI.text = GameProgressManager.Instance.CurrentStage.ToString();

        for (int i = 0; i < GameProgressManager.Instance.PlayerCharacter.CharacterGroup.Length; i++)
        {
            charaRepImages[i].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].RepImage;
            charaNameTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].CharacterName;
            CharaHPTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].CurrentStatus.hp.ToString() + " / " +
                GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].OriginStatus.hp.ToString();
        }
    }
}

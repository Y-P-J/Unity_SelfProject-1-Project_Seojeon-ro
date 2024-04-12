using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//�����׳ͽ� ���� UI�� �����ϴ� Ŭ����
public class UIController_Maintenance : MonoBehaviour
{
    [Tooltip("���� ������ ǥ���ϴ� UI")]
    [SerializeField] TMP_Text floorCountUI;

    //��ư �ְ�, ���� ��ư��Ȳ �ְ�, �̹��� �� �ٲ㼭 �����Ű��

    [Tooltip("ĳ���� ��ư ���� ����")]
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

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

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

    [Tooltip("현재 선택된 캐릭터")]
    [SerializeField, ReadOnly] int selectedCharaIndex;

    [Header("캐릭터 장비/스텟 정보")]
    [Tooltip("장착중인 장비 이미지")]//0:무기, 1:헬멧, 2:갑옷, 3:장갑, 4:신발, 5:반지
    [SerializeField] Image[] equipImage;
    [Tooltip("세부 스텟")]//0:레벨, 1:체력, 2:마력, 3:속도, 4:공격력, 5:방어력, 6:치명률, 7:회피율
    [SerializeField] TMP_Text[] detailStatusTexts;

    [Header("캐릭터 스킬 정보")]
    [Tooltip("스킬 정보 UI")]
    [SerializeField] Image[] skillImages;
    [Tooltip("스킬 이름 텍스트")]
    [SerializeField] TMP_Text[] skillNameTexts;
    [Tooltip("스킬 설명 텍스트")]
    [SerializeField] TMP_Text[] skillDescriptionTexts;
    [Tooltip("스킬 마나 소모량 텍스트")]
    [SerializeField] TMP_Text[] skillUseManaTexts;
    [Tooltip("스킬 쿨타임 텍스트")]
    [SerializeField] TMP_Text[] skillCooldownTexts;

    [Header("인벤토리")]
    [Tooltip("인벤토리 UI")]
    [SerializeField] GameObject inventoryUI;
    [Tooltip("인벤토리 이미지들")]
    [SerializeField, ReadOnly] Image[] inventoryImages;
    [Tooltip("아이템 설명 UI")]
    [SerializeField] GameObject itemDescriptionUI;
    

    [Header("적 요약 정보")]
    [Tooltip("적 대표 이미지")]
    [SerializeField] Image[] enemyRepImages;
    [Tooltip("적 레벨 텍스트")]
    [SerializeField] TMP_Text[] enemyLevelTexts;

    [Tooltip("버튼 갱신용 변수")]
    GameObject lastSelect;

    #region 람다식 프로퍼티
    public Image[] InventoryImages => inventoryImages;
    #endregion

    void Update()
    {
        //인벤토리 아이템 클릭시 아이템 변경
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData _event = new PointerEventData(EventSystem.current);
            _event.position = Input.mousePosition;
            List<RaycastResult> _ray = new List<RaycastResult>();
            EventSystem.current.RaycastAll(_event, _ray);

            if (_ray[0].gameObject.name != "ItemIcon")
                return;

            for (int i = 0; i < inventoryImages.Length; i++)
            {
                if (_ray[0].gameObject == inventoryImages[i].gameObject)
                {
                    Inventory.Instance.SwitchItem(i);
                    UpdateCharaInfoUI();
                    UpdateInventoryUI();
                    break;
                }
            }
        }

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

        #region 캐릭터 정보 UI 관련
        //캐릭터 정보 UI 갱신
        for (int i = 0; i < GameProgressManager.Instance.PlayerCharacter.CharacterGroup.Length; i++)
        {
            charaRepImages[i].sprite = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].RepImage;
            charaNameTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].CharacterName;
            charaLevelTexts[i].text = GameProgressManager.Instance.PlayerCharacter.CharacterGroup[i].Level.ToString();
        }

        //캐릭터 버튼에 이벤트 추가
        charaButton[0].Select();
        CheckCharaButtonClick();
        #endregion

        #region 인벤토리 UI 관련
        inventoryImages = new Image[30];
        //인벤토리 UI의 모든 오브젝트를 가져옴
        Transform[] _object = inventoryUI.GetComponentsInChildren<Transform>();
        List<Transform> _Items = new List<Transform>();

        foreach (Transform _item in _object)//그중 ItemIcon이라는 이름을 가진 오브젝트만 가져옴
        {
            if (_item.name == "ItemIcon")
                _Items.Add(_item);
        }

        for (int i = 0; i < _Items.Count; i++)//그렇게 가져온 오브젝트들을 다시 배열에 넣어줌
            inventoryImages[i] = _Items[i].GetComponent<Image>();

        UpdateInventoryUI();
        #endregion

        //적 정보 UI 갱신
        UpdateEnemyInfoUI();
    }

    /// <summary>
    /// 캐릭터버튼 클릭시 호출되는 함수
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
            LogHandler.WriteLog("알맞는 버튼 인덱스가 아니거나, 찾지 못했습니다.", this.GetType().Name, LogType.Error, true);
            return;
        }

        selectedCharaIndex = _index;

        Debug.Log(selectedCharaIndex + "번째 캐릭터 선택");

        UpdateCharaInfoUI();
    }

    /// <summary>
    /// 캐릭터 정보 UI를 갱신하는 함수
    /// </summary>
    public void UpdateCharaInfoUI()
    {
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

    /// <summary>
    /// 인벤토리 UI를 갱신하는 함수
    /// </summary>
    public void UpdateInventoryUI()
    {
        for (int i = 0; i < inventoryImages.Length; i++)
        {
            if (Inventory.Instance.Items[i].ID.EndsWith("0"))
                inventoryImages[i].gameObject.SetActive(false);
            else
                inventoryImages[i].sprite = Inventory.Instance.Items[i].RepImage;
        }
    }

    public void UpdateItemDescriptionUI(int _index, bool _b)
    {
        if (!_b)
        {
            itemDescriptionUI.SetActive(false);
        }
        else
        {
            RectTransform _description = itemDescriptionUI.GetComponent<RectTransform>();
            RectTransform _image = inventoryImages[_index].GetComponent<RectTransform>();

            _description.position = new Vector2(_image.position.x, _image.position.y - (_image.rect.height * 0.5f));
            itemDescriptionUI.SetActive(true);
        }
    }

    /// <summary>
    /// 적 정보 UI를 갱신하는 함수
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

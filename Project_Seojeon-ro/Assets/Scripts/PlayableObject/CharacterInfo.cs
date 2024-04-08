using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//캐릭터의 정보를 담는 스크립트에이블 오브젝트
[CreateAssetMenu(fileName = "CharacterInfo", menuName = "PlayableObject/CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    [Tooltip("캐릭터 이름")]
    [SerializeField] string characterName;
    [Tooltip("캐릭터 고유 숫자")]
    [SerializeField] int number;
    [Tooltip("캐릭터 ID")] //캐릭터 ID는 캐릭터 고유 숫자와 그 외의 정보를 토대로 IDGenerator에서 생성되어 지급받는다
    string id;

    [Space]

    [Tooltip("캐릭터 레벨")]
    [SerializeField] int level;
    [Tooltip("캐릭터 요구 경험치")]
    [SerializeField] int maxExp;
    [Tooltip("캐릭터 현재 경험치")]
    [SerializeField] int currentExp;

    [Space]

    [Tooltip("캐릭터 기존 스테이터스")]
    [SerializeField] Status originStatus;
    [Tooltip("캐릭터 현재 스테이터스")]
    [SerializeField] Status currentStatus;

    [Space]

    //각 하단의 EQUIP_TYPE[] 배열은 해당 장비를 장착할 수 있는 타입을 표시함
    [Tooltip("현재 장착 무기")]
    [SerializeField] EquipInfo weapon;
    [SerializeField] EQUIP_TYPE[] weaponTypes;
    [Tooltip("현재 장착 헬멧")]
    [SerializeField] EquipInfo helmet;
    [SerializeField] EQUIP_TYPE[] helmetTypes;
    [Tooltip("현재 장착 갑옷")]
    [SerializeField] EquipInfo armor;
    [SerializeField] EQUIP_TYPE[] armorTypes;
    [Tooltip("현재 장착 장갑")]
    [SerializeField] EquipInfo glove;
    [SerializeField] EQUIP_TYPE[] gloveTypes;
    [Tooltip("현재 장착 신발")]
    [SerializeField] EquipInfo shoes;
    [SerializeField] EQUIP_TYPE[] shoesTypes;
    [Tooltip("현재 장착 반지")]
    [SerializeField] EquipInfo ring;
    [SerializeField] EQUIP_TYPE[] ringTypes;

    [Tooltip("캐릭터 대표 이미지")]
    [SerializeField] Sprite repImage;
}

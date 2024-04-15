using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스킬 정보를 담는 ScriptableObject
[CreateAssetMenu(fileName = "SkillInfo", menuName = "PlayableObject/SkillInfo")]
public class SkillInfo : ScriptableObject
{
    [Tooltip("스킬 이름")]
    [SerializeField] protected string skillName;
    [Tooltip("스킬 고유 숫자")]//기본적으로 피아구분없이 사용하기 위해 같은 ScriptableObject를 사용하나
    [SerializeField] protected int number;//주로 적이 사용하는 스킬은 1001 이상의 숫자를 사용하길 권장
    [Tooltip("스킬 ID(스킬 ID는 스킬 고유 숫자와 그 외의 정보를 토대로 IDGenerator에서 생성되어 지급받는다)")]
    [SerializeField, ReadOnly] protected string id;

    [Space]

    [Tooltip("스킬 설명/[dmg]는 damage와 attackScale을 사용하여 표시함")]
    [SerializeField, TextArea(2, 3)] protected string description;
    [Tooltip("UI에 표시할 스킬 설명")]
    [SerializeField, ReadOnly] protected string descriptionForUI;

    [Space]

    [Tooltip("스킬 데미지")]
    [SerializeField] protected int damage;
    [Tooltip("공격력 계수")]
    [SerializeField] protected float attackScale;
    [Tooltip("마나 소모량")]
    [SerializeField] protected int mpCost;
    [Tooltip("스킬 쿨타임")]
    [SerializeField] protected int cooldown;

    [Space]

    [Tooltip("스킬 대표 이미지")]
    [SerializeField] protected Sprite repImage;

    #region 람다식 프로퍼티
    public string SkillName => skillName;
    public int Number => number;
    public string ID => id;
    public string Description => description;
    public string DescriptionForUI => descriptionForUI;
    public int Damage => damage;
    public float AttackScale => attackScale;
    public int MpCost => mpCost;
    public int Cooldown => cooldown;
    #endregion

    void OnEnable()
    {
        id = IDGenerator.GenerateID(this);

        descriptionForUI = description;

        if (descriptionForUI.Contains("[dmg]"))
            descriptionForUI = descriptionForUI.Replace("[dmg]", $"{damage.ToString()}(+{attackScale.ToString()} 공격력)");
    }
}

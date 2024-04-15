using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ų ������ ��� ScriptableObject
[CreateAssetMenu(fileName = "SkillInfo", menuName = "PlayableObject/SkillInfo")]
public class SkillInfo : ScriptableObject
{
    [Tooltip("��ų �̸�")]
    [SerializeField] protected string skillName;
    [Tooltip("��ų ���� ����")]//�⺻������ �ǾƱ��о��� ����ϱ� ���� ���� ScriptableObject�� ����ϳ�
    [SerializeField] protected int number;//�ַ� ���� ����ϴ� ��ų�� 1001 �̻��� ���ڸ� ����ϱ� ����
    [Tooltip("��ų ID(��ų ID�� ��ų ���� ���ڿ� �� ���� ������ ���� IDGenerator���� �����Ǿ� ���޹޴´�)")]
    [SerializeField, ReadOnly] protected string id;

    [Space]

    [Tooltip("��ų ����/[dmg]�� damage�� attackScale�� ����Ͽ� ǥ����")]
    [SerializeField, TextArea(2, 3)] protected string description;
    [Tooltip("UI�� ǥ���� ��ų ����")]
    [SerializeField, ReadOnly] protected string descriptionForUI;

    [Space]

    [Tooltip("��ų ������")]
    [SerializeField] protected int damage;
    [Tooltip("���ݷ� ���")]
    [SerializeField] protected float attackScale;
    [Tooltip("���� �Ҹ�")]
    [SerializeField] protected int mpCost;
    [Tooltip("��ų ��Ÿ��")]
    [SerializeField] protected int cooldown;

    [Space]

    [Tooltip("��ų ��ǥ �̹���")]
    [SerializeField] protected Sprite repImage;

    #region ���ٽ� ������Ƽ
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
            descriptionForUI = descriptionForUI.Replace("[dmg]", $"{damage.ToString()}(+{attackScale.ToString()} ���ݷ�)");
    }
}

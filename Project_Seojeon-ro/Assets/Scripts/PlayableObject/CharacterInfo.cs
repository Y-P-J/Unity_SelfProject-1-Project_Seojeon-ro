using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ĳ������ ������ ��� ��ũ��Ʈ���̺� ������Ʈ
[CreateAssetMenu(fileName = "CharacterInfo", menuName = "PlayableObject/CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    [Tooltip("ĳ���� �̸�")]
    [SerializeField] string characterName;
    [Tooltip("ĳ���� ���� ����")]
    [SerializeField] int number;
    [Tooltip("ĳ���� ID")] //ĳ���� ID�� ĳ���� ���� ���ڿ� �� ���� ������ ���� IDGenerator���� �����Ǿ� ���޹޴´�
    string id;

    [Space]

    [Tooltip("ĳ���� ����")]
    [SerializeField] int level;
    [Tooltip("ĳ���� �䱸 ����ġ")]
    [SerializeField] int maxExp;
    [Tooltip("ĳ���� ���� ����ġ")]
    [SerializeField] int currentExp;

    [Space]

    [Tooltip("ĳ���� ���� �������ͽ�")]
    [SerializeField] Status originStatus;
    [Tooltip("ĳ���� ���� �������ͽ�")]
    [SerializeField] Status currentStatus;

    [Space]

    //�� �ϴ��� EQUIP_TYPE[] �迭�� �ش� ��� ������ �� �ִ� Ÿ���� ǥ����
    [Tooltip("���� ���� ����")]
    [SerializeField] EquipInfo weapon;
    [SerializeField] EQUIP_TYPE[] weaponTypes;
    [Tooltip("���� ���� ���")]
    [SerializeField] EquipInfo helmet;
    [SerializeField] EQUIP_TYPE[] helmetTypes;
    [Tooltip("���� ���� ����")]
    [SerializeField] EquipInfo armor;
    [SerializeField] EQUIP_TYPE[] armorTypes;
    [Tooltip("���� ���� �尩")]
    [SerializeField] EquipInfo glove;
    [SerializeField] EQUIP_TYPE[] gloveTypes;
    [Tooltip("���� ���� �Ź�")]
    [SerializeField] EquipInfo shoes;
    [SerializeField] EQUIP_TYPE[] shoesTypes;
    [Tooltip("���� ���� ����")]
    [SerializeField] EquipInfo ring;
    [SerializeField] EQUIP_TYPE[] ringTypes;

    [Tooltip("ĳ���� ��ǥ �̹���")]
    [SerializeField] Sprite repImage;
}

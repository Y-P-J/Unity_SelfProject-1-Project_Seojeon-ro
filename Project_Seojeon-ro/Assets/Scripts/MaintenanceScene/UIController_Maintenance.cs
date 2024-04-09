using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//메인테넌스 씬의 UI를 관리하는 클래스
public class UIController_Maintenance : MonoBehaviour
{
    [Header("캐릭터 선택")]
    [Tooltip("첫번째 캐릭터 버튼")]
    [SerializeField] Button chara1;
    [Tooltip("두번째 캐릭터 버튼")]
    [SerializeField] Button chara2;
    [Tooltip("세번째 캐릭터 버튼")]
    [SerializeField] Button chara3;
}

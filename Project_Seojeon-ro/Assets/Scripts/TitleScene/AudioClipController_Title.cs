using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//타이틀 씬에서 사용되는 AudioClip 컨트롤러 클래스
public class AudioClipController_Title : AudioClipController
{
    [Header("BGM")]
    [Tooltip("타이틀 배경음")]
    [SerializeField] AudioClip titleBGMAudio;



    [Header("SE")]
    [Tooltip("UI버튼 클릭음")]
    [SerializeField] AudioClip uibuttonAudio;



    void Start()
    {
        BGMControl(titleBGMAudio, true);
    }

    public void TitleBGMAudio(bool _b) => BGMControl(titleBGMAudio, _b);
    public void UIButtonAudio(bool _b) => SEControl(uibuttonAudio, _b);
}

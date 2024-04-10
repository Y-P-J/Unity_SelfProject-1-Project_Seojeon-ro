using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Ÿ��Ʋ ������ ���Ǵ� AudioClip ��Ʈ�ѷ� Ŭ����
public class AudioClipController_Title : AudioClipController
{
    [Header("BGM")]
    [Tooltip("Ÿ��Ʋ �����")]
    [SerializeField] AudioClip titleBGMAudio;



    [Header("SE")]
    [Tooltip("UI��ư Ŭ����")]
    [SerializeField] AudioClip uibuttonAudio;



    void Start()
    {
        BGMControl(titleBGMAudio, true);
    }

    public void TitleBGMAudio(bool _b) => BGMControl(titleBGMAudio, _b);
    public void UIButtonAudio(bool _b) => SEControl(uibuttonAudio, _b);
}

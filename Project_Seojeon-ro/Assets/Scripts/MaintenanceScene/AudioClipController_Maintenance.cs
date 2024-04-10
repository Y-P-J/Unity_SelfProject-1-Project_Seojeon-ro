using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//메인테넌스 씬에서 사용되는 AudioClip 컨트롤러 클래스
public class AudioClipController_Maintenance : AudioClipController
{
    [Header("BGM")]
    [Tooltip("메인테넌스 배경음")]
    [SerializeField] AudioClip maintenanceBGMAudio;



    [Header("SE")]
    [Tooltip("UI버튼 클릭음")]
    [SerializeField] AudioClip uibuttonAudio;



    void Start()
    {
        BGMControl(maintenanceBGMAudio, true);
    }

    public void MaintenanceBGMAudio(bool _b) => BGMControl(maintenanceBGMAudio, _b);
    public void UIButtonAudio(bool _b) => SEControl(uibuttonAudio, _b);
}

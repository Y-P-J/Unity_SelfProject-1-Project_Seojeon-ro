using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//메인테넌스 씬에서 사용되는 AudioClip 컨트롤러 클래스
public class AudioClipController_Maintenance : MonoBehaviour
{
    [Header("BGM")]
    [Tooltip("메인테넌스 배경음")]
    [SerializeField] AudioClip maintenanceBGMAudio;



    [Header("SE")]
    [Tooltip("UI버튼 클릭음")]
    [SerializeField] AudioClip uibuttonAudio;



    void Start()
    {
        TitleBGMControl(true);
    }

    /// <summary>
    /// 배경음 컨트롤 함수
    /// </summary>
    public void TitleBGMControl(bool _b)
    {
        if (_b)
            VolumeManager.Instance.BgmSource.PlayOneShot(maintenanceBGMAudio);
        else
            VolumeManager.Instance.BgmSource.Stop();
    }

    /// <summary>
    /// UI버튼 컨트롤 함수
    /// </summary>
    public void UibuttonControl(bool _b)
    {
        if (_b)
            VolumeManager.Instance.SeSource.PlayOneShot(uibuttonAudio);
        else
            VolumeManager.Instance.SeSource.Stop();
    }
}

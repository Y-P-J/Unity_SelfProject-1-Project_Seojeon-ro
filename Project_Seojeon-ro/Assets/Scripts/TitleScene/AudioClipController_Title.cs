using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//타이틀 씬에서 사용되는 AudioClip 컨트롤러 클래스
public class AudioClipController_Title : MonoBehaviour
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

    /// <summary>
    /// 배경음 컨트롤 함수
    /// </summary>
    public void BGMControl(AudioClip _audio, bool _b)
    {
        if (_b)
            VolumeManager.Instance.BgmSource.PlayOneShot(_audio);
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

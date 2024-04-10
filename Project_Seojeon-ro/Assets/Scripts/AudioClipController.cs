using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AudioClip 컨트롤러 클래스
public class AudioClipController : MonoBehaviour
{
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
    /// 효과음 컨트롤 함수
    /// </summary>
    public void SEControl(AudioClip _audio, bool _b)
    {
        if (_b)
            VolumeManager.Instance.SeSource.PlayOneShot(_audio);
        else
            VolumeManager.Instance.SeSource.Stop();
    }
}

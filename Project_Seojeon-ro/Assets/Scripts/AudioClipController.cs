using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AudioClip 컨트롤러 클래스
public class AudioClipController : MonoBehaviour
{
    /// <summary>
    /// 배경음 컨트롤 함수
    /// </summary>
    public void BGMControl(AudioClip _audio, bool _isPlay)
    {
        if (_isPlay)
        {
            VolumeManager.Instance.BgmSource.clip = _audio;
            VolumeManager.Instance.BgmSource.Play();//BGM의 경우 하나만 실행하는 경우가 많기에 Play()를 사용
        }
        else
            VolumeManager.Instance.BgmSource.Stop();
    }

    /// <summary>
    /// 효과음 컨트롤 함수
    /// </summary>
    public void SEControl(AudioClip _audio, bool _isPlay)
    {
        if (_isPlay)
            VolumeManager.Instance.SeSource.PlayOneShot(_audio);//SE의 경우 여러개를 동시에 재생할 수 있기에 PlayOneShot()을 사용
        else                                                    //PlayOneShot()은 AudioSource로 동시에 여러 AudioClip을 사용할 수 있게 한다.
            VolumeManager.Instance.SeSource.Stop();
    }
}

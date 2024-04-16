using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AudioClip ��Ʈ�ѷ� Ŭ����
public class AudioClipController : MonoBehaviour
{
    /// <summary>
    /// ����� ��Ʈ�� �Լ�
    /// </summary>
    public void BGMControl(AudioClip _audio, bool _isPlay)
    {
        if (_isPlay)
        {
            VolumeManager.Instance.BgmSource.clip = _audio;
            VolumeManager.Instance.BgmSource.Play();//BGM�� ��� �ϳ��� �����ϴ� ��찡 ���⿡ Play()�� ���
        }
        else
            VolumeManager.Instance.BgmSource.Stop();
    }

    /// <summary>
    /// ȿ���� ��Ʈ�� �Լ�
    /// </summary>
    public void SEControl(AudioClip _audio, bool _isPlay)
    {
        if (_isPlay)
            VolumeManager.Instance.SeSource.PlayOneShot(_audio);//SE�� ��� �������� ���ÿ� ����� �� �ֱ⿡ PlayOneShot()�� ���
        else                                                    //PlayOneShot()�� AudioSource�� ���ÿ� ���� AudioClip�� ����� �� �ְ� �Ѵ�.
            VolumeManager.Instance.SeSource.Stop();
    }
}

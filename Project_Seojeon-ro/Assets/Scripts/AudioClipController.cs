using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AudioClip ��Ʈ�ѷ� Ŭ����
public class AudioClipController : MonoBehaviour
{
    /// <summary>
    /// ����� ��Ʈ�� �Լ�
    /// </summary>
    public void BGMControl(AudioClip _audio, bool _b)
    {
        if (_b)
            VolumeManager.Instance.BgmSource.PlayOneShot(_audio);
        else
            VolumeManager.Instance.BgmSource.Stop();
    }

    /// <summary>
    /// ȿ���� ��Ʈ�� �Լ�
    /// </summary>
    public void SEControl(AudioClip _audio, bool _b)
    {
        if (_b)
            VolumeManager.Instance.SeSource.PlayOneShot(_audio);
        else
            VolumeManager.Instance.SeSource.Stop();
    }
}

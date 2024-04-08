using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Ÿ��Ʋ ������ ���Ǵ� ����� Ŭ�� ��Ʈ�ѷ� Ŭ����
public class AudioClipController_Title : MonoBehaviour
{
    [Header("BGM")]
    [Tooltip("Ÿ��Ʋ �����")]
    [SerializeField] AudioClip titleBGMAudio;



    [Header("SE")]
    [Tooltip("UI��ư Ŭ����")]
    [SerializeField] AudioClip uibuttonAudio;



    void Start()
    {
        TitleBGMControl(true);
    }

    /// <summary>
    /// Ÿ��Ʋ ����� ��Ʈ�� �Լ�
    /// </summary>
    public void TitleBGMControl(bool _b)
    {
        if (_b)
            VolumeManager.Instance.BgmSource.PlayOneShot(titleBGMAudio);
        else
            VolumeManager.Instance.BgmSource.Stop();
    }

    /// <summary>
    /// UI��ư ��Ʈ�� �Լ�
    /// </summary>
    public void UibuttonControl(bool _b)
    {
        if (_b)
            VolumeManager.Instance.SeSource.PlayOneShot(uibuttonAudio);
        else
            VolumeManager.Instance.SeSource.Stop();
    }
}

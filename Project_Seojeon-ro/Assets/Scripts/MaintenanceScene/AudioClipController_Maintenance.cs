using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�����׳ͽ� ������ ���Ǵ� AudioClip ��Ʈ�ѷ� Ŭ����
public class AudioClipController_Maintenance : MonoBehaviour
{
    [Header("BGM")]
    [Tooltip("�����׳ͽ� �����")]
    [SerializeField] AudioClip maintenanceBGMAudio;



    [Header("SE")]
    [Tooltip("UI��ư Ŭ����")]
    [SerializeField] AudioClip uibuttonAudio;



    void Start()
    {
        TitleBGMControl(true);
    }

    /// <summary>
    /// ����� ��Ʈ�� �Լ�
    /// </summary>
    public void TitleBGMControl(bool _b)
    {
        if (_b)
            VolumeManager.Instance.BgmSource.PlayOneShot(maintenanceBGMAudio);
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

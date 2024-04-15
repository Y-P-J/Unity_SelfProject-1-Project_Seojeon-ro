using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//������ ���õ� ����� ����ϴ� Ŭ����
public class VolumeManager : Singleton<VolumeManager>
{
    [Header("������Ʈ")]
    [Tooltip("����� ������ҽ� ������Ʈ")]
    [SerializeField] AudioSource bgmSource;

    [Tooltip("ȿ���� ������ҽ� ������Ʈ")]
    [SerializeField] AudioSource seSource;



    [Header("��")]
    [Tooltip("������ ����")]
    float masterVolume = .3f;

    [Tooltip("����� ����")]
    float bgmVolume = .5f;

    [Tooltip("ȿ���� ����")]
    float seVolume = .5f;



    #region ���ٽ� ������Ƽ
    public AudioSource BgmSource => bgmSource;
    public AudioSource SeSource => seSource;
    public float MasterVolume => masterVolume;
    public float BGMVolume => bgmVolume;
    public float SEVolume => seVolume;
    #endregion

    /// <summary>
    /// ������ ������ �����ϴ� �Լ�
    /// </summary>
    public void ChangeMasterVolume(float _value)
    {
        masterVolume = _value;
        AudioListener.volume = masterVolume;
    }

    /// <summary>
    /// ����� ������ �����ϴ� �Լ�
    /// </summary>
    public void ChangeBGMVolume(float _value)
    {
        bgmVolume = _value;
        bgmSource.volume = bgmVolume;
    }

    /// <summary>
    /// ȿ���� ������ �����ϴ� �Լ�
    /// </summary>
    public void ChangeSEVolume(float _value)
    {
        seVolume = _value;
        seSource.volume = seVolume;
    }
}

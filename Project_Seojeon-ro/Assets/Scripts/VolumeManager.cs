using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//볼륨과 관련된 기능을 담당하는 클래스
public class VolumeManager : Singleton<VolumeManager>
{
    [Header("컴포넌트")]
    [Tooltip("배경음 오디오소스 컴포넌트")]
    [SerializeField] AudioSource bgmSource;

    [Tooltip("효과음 오디오소스 컴포넌트")]
    [SerializeField] AudioSource seSource;



    [Header("값")]
    [Tooltip("마스터 볼륨")]
    float masterVolume = .3f;

    [Tooltip("배경음 볼륨")]
    float bgmVolume = .5f;

    [Tooltip("효과음 볼륨")]
    float seVolume = .5f;



    #region 람다식 프로퍼티
    public AudioSource BgmSource => bgmSource;
    public AudioSource SeSource => seSource;
    public float MasterVolume => masterVolume;
    public float BGMVolume => bgmVolume;
    public float SEVolume => seVolume;
    #endregion

    /// <summary>
    /// 마스터 볼륨을 변경하는 함수
    /// </summary>
    public void ChangeMasterVolume(float _value)
    {
        masterVolume = _value;
        AudioListener.volume = masterVolume;
    }

    /// <summary>
    /// 배경음 볼륨을 변경하는 함수
    /// </summary>
    public void ChangeBGMVolume(float _value)
    {
        bgmVolume = _value;
        bgmSource.volume = bgmVolume;
    }

    /// <summary>
    /// 효과음 볼륨을 변경하는 함수
    /// </summary>
    public void ChangeSEVolume(float _value)
    {
        seVolume = _value;
        seSource.volume = seVolume;
    }
}

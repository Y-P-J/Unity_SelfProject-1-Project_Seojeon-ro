using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//타이틀 씬의 UI를 담당하는 클래스
public class SettingUIController : MonoBehaviour
{
    [Header("볼륨 슬라이더")]
    [Tooltip("마스터 볼륨 슬라이더")]
    [SerializeField] Slider masterVolumeSlider;
    [Tooltip("BGM 볼륨 슬라이더")]
    [SerializeField] Slider bgmVolumeSlider;
    [Tooltip("SE 볼륨 슬라이더")]
    [SerializeField] Slider seVolumeSlider;

    [Header("전체화면 관련 버튼")]
    [Tooltip("전체 화면 활성화 버튼")]
    [SerializeField] Button fullScreenEnableButton;
    [Tooltip("전체 화면 비활성화 버튼")]
    [SerializeField] Button fullScreenDisableButton;
    [Tooltip("창 화면 활성화 버튼")]
    [SerializeField] Button windowScreenEnableButton;
    [Tooltip("창 화면 비활성화 버튼")]
    [SerializeField] Button windowScreenDisableButton;

    void Start()
    {
        //슬라이더의 값을 볼륨매니저에서 가져와 설정
        masterVolumeSlider.value = VolumeManager.Instance.MasterVolume;
        bgmVolumeSlider.value = VolumeManager.Instance.BGMVolume;
        seVolumeSlider.value = VolumeManager.Instance.SEVolume;

        //전체화면 여부에 따라 버튼 활성화 설정
        if (Screen.fullScreen)
        {
            fullScreenEnableButton.gameObject.SetActive(true);
            fullScreenDisableButton.gameObject.SetActive(false);
            windowScreenEnableButton.gameObject.SetActive(false);
            windowScreenDisableButton.gameObject.SetActive(true);
        }
        else
        {
            fullScreenEnableButton.gameObject.SetActive(false);
            fullScreenDisableButton.gameObject.SetActive(true);
            windowScreenEnableButton.gameObject.SetActive(true);
            windowScreenDisableButton.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 마스터 볼륨 변경 함수
    /// </summary>
    public void ChangeMasterVolume()
    {
        VolumeManager.Instance.ChangeMasterVolume(masterVolumeSlider.value);
    }

    /// <summary>
    /// BGM 볼륨 변경 함수
    /// </summary>
    public void ChangeBGMVolume()
    {
        VolumeManager.Instance.ChangeBGMVolume(bgmVolumeSlider.value);
    }

    /// <summary>
    /// SE 볼륨 변경 함수
    /// </summary>
    public void ChangeSEVolume()
    {
        VolumeManager.Instance.ChangeSEVolume(seVolumeSlider.value);
    }

    /// <summary>
    /// 전체 화면 활성화 함수
    /// </summary>
    public void FullScreenEnable()
    {
        Screen.fullScreen = true;
    }

    /// <summary>
    /// 전체 화면 비활성화 함수
    /// </summary>
    public void FullScreenDisable()
    {
        Screen.fullScreen = false;
    }
}

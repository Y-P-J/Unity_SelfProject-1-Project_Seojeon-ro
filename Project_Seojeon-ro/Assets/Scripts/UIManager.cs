using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : Singleton<UIManager>
{
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider bgmVolumeSlider;
    [SerializeField] Slider seVolumeSlider;

    [SerializeField] Button fullScreenEnableButton;
    [SerializeField] Button fullScreenDisableButton;
    [SerializeField] Button windowScreenEnableButton;
    [SerializeField] Button windowScreenDisableButton;

    void Start()
    {
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

    public void Setup(float _master, float _bgm, float _se)
    {
        masterVolumeSlider.value = _master;
        bgmVolumeSlider.value = _bgm;
        seVolumeSlider.value = _se;
    }

    public void ChangeMasterVolume()
    {
        SoundManager.Instance.ChangeMasterVolume(masterVolumeSlider.value);
    }

    public void ChangeBGMVolume()
    {
        SoundManager.Instance.ChangeBGMVolume(bgmVolumeSlider.value);
    }

    public void ChangeSEVolume()
    {
        SoundManager.Instance.ChangeSEVolume(seVolumeSlider.value);
    }

    public void FullScreenEnable()
    {
        Screen.fullScreen = true;
        fullScreenEnableButton.gameObject.SetActive(true);
        fullScreenDisableButton.gameObject.SetActive(false);
        windowScreenEnableButton.gameObject.SetActive(false);
        windowScreenDisableButton.gameObject.SetActive(true);
    }

    public void FullScreenDisable()
    {
        Screen.fullScreen = false;
        fullScreenEnableButton.gameObject.SetActive(false);
        fullScreenDisableButton.gameObject.SetActive(true);
        windowScreenEnableButton.gameObject.SetActive(true);
        windowScreenDisableButton.gameObject.SetActive(false);
    }
}

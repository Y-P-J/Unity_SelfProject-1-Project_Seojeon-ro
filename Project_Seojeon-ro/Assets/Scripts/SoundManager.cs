using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    float masterVolume = .5f;
    float bgmVolume = .5f;
    float seVolume = .5f;

    void Start()
    {
        UIManager.Instance.Setup(masterVolume, bgmVolume, seVolume);
        SoundController.Instance.Setup(bgmVolume, seVolume);
        SoundController.Instance.TitleBGMPlay();
    }

    public void ChangeMasterVolume(float _value)
    {
        masterVolume = _value;
        AudioListener.volume = masterVolume;
    }

    public void ChangeBGMVolume(float _value)
    {
        bgmVolume = _value;
        SoundController.Instance.BGMSetup(bgmVolume);
    }

    public void ChangeSEVolume(float _value)
    {
        seVolume = _value;
        SoundController.Instance.SESetup(seVolume);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundController : Singleton<SoundController>
{
    [Header("ÄÄÆ÷³ÍÆ®")]
    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource seSource;



    [Header("BGM")]
    [SerializeField] AudioClip titleBGMAudio;



    [Header("SE")]
    [SerializeField] AudioClip uibuttonAudio;



    public void Setup(float _bgm, float _se)
    {
        BGMSetup(_bgm);
        SESetup(_se);
    }

    public void BGMSetup(float _bgm)
    {
        bgmSource.volume = _bgm;
    }

    public void SESetup(float _se)
    {
        seSource.volume = _se;
    }

    public void TitleBGMPlay() => bgmSource.PlayOneShot(titleBGMAudio);
    public void UibuttonPlay() => seSource.PlayOneShot(uibuttonAudio);
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Ÿ��Ʋ ���� UI�� ����ϴ� Ŭ����
public class SettingUIController : MonoBehaviour
{
    [Header("���� �����̴�")]
    [Tooltip("������ ���� �����̴�")]
    [SerializeField] Slider masterVolumeSlider;
    [Tooltip("BGM ���� �����̴�")]
    [SerializeField] Slider bgmVolumeSlider;
    [Tooltip("SE ���� �����̴�")]
    [SerializeField] Slider seVolumeSlider;

    [Header("��üȭ�� ���� ��ư")]
    [Tooltip("��ü ȭ�� Ȱ��ȭ ��ư")]
    [SerializeField] Button fullScreenEnableButton;
    [Tooltip("��ü ȭ�� ��Ȱ��ȭ ��ư")]
    [SerializeField] Button fullScreenDisableButton;
    [Tooltip("â ȭ�� Ȱ��ȭ ��ư")]
    [SerializeField] Button windowScreenEnableButton;
    [Tooltip("â ȭ�� ��Ȱ��ȭ ��ư")]
    [SerializeField] Button windowScreenDisableButton;

    void Start()
    {
        //�����̴��� ���� �����Ŵ������� ������ ����
        masterVolumeSlider.value = VolumeManager.Instance.MasterVolume;
        bgmVolumeSlider.value = VolumeManager.Instance.BGMVolume;
        seVolumeSlider.value = VolumeManager.Instance.SEVolume;

        //��üȭ�� ���ο� ���� ��ư Ȱ��ȭ ����
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
    /// ������ ���� ���� �Լ�
    /// </summary>
    public void ChangeMasterVolume()
    {
        VolumeManager.Instance.ChangeMasterVolume(masterVolumeSlider.value);
    }

    /// <summary>
    /// BGM ���� ���� �Լ�
    /// </summary>
    public void ChangeBGMVolume()
    {
        VolumeManager.Instance.ChangeBGMVolume(bgmVolumeSlider.value);
    }

    /// <summary>
    /// SE ���� ���� �Լ�
    /// </summary>
    public void ChangeSEVolume()
    {
        VolumeManager.Instance.ChangeSEVolume(seVolumeSlider.value);
    }

    /// <summary>
    /// ��ü ȭ�� Ȱ��ȭ �Լ�
    /// </summary>
    public void FullScreenEnable()
    {
        Screen.fullScreen = true;
    }

    /// <summary>
    /// ��ü ȭ�� ��Ȱ��ȭ �Լ�
    /// </summary>
    public void FullScreenDisable()
    {
        Screen.fullScreen = false;
    }
}

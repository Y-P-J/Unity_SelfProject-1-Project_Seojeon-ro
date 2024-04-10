using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�����׳ͽ� ������ ���Ǵ� AudioClip ��Ʈ�ѷ� Ŭ����
public class AudioClipController_Maintenance : AudioClipController
{
    [Header("BGM")]
    [Tooltip("�����׳ͽ� �����")]
    [SerializeField] AudioClip maintenanceBGMAudio;



    [Header("SE")]
    [Tooltip("UI��ư Ŭ����")]
    [SerializeField] AudioClip uibuttonAudio;



    void Start()
    {
        BGMControl(maintenanceBGMAudio, true);
    }

    public void MaintenanceBGMAudio(bool _b) => BGMControl(maintenanceBGMAudio, _b);
    public void UIButtonAudio(bool _b) => SEControl(uibuttonAudio, _b);
}

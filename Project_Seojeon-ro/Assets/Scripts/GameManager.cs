using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static SceneHandler;

//���� ��ü�� �۵��� ���õ� ����� ����ϴ� Ŭ����
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// �������� �Լ�
    /// </summary>
    public void ExitGame()
    {
        //�����Ϳ����� �����͸� �����ϰ�, ����� ���¿����� ������ �����Ѵ�.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
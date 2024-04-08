using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static SceneHandler;

//게임 자체의 작동과 관련된 기능을 담당하는 클래스
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// 게임종료 함수
    /// </summary>
    public void ExitGame()
    {
        //에디터에서는 에디터를 종료하고, 빌드된 상태에서는 게임을 종료한다.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
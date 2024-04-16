using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//씬과 관련된 기능을 담당하는 클래스
public static class SceneHandler
{
    [Tooltip("현재 씬 이름")]
    static string currentScene;

    #region 람다식 프로퍼티
    public static string CurrentScene => currentScene;
    #endregion

    static SceneHandler()
    {
        //현재 씬 이름을 저장
        currentScene = SceneManager.GetActiveScene().name;

        LogHandler.WriteLog("First LoadScene : " + currentScene, typeof(SceneHandler).Name, LogType.Log, true);
    }

    /// <summary>
    /// 씬 불러오기
    /// </summary>
    public static void LoadScene(string _id)
    {
        SceneManager.LoadScene(_id);

        currentScene = _id;

        LogHandler.WriteLog("LoadScene : " + _id, typeof(SceneHandler).Name, LogType.Log, true);
    }

    /// <summary>
    /// SceneHandler 초기화를 위한 더미 함수
    /// </summary>
    [RuntimeInitializeOnLoadMethod]
    static void MyNameIsKimSuHanMuIsVeryLongNameYouKnowAreIMean() { }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//씬과 관련된 기능을 담당하는 클래스
public static class SceneHandler
{
    [Header("값")]
    [Tooltip("현재 씬 이름")]
    static string currentScene;



    #region 람다식 프로퍼티
    public static string CurrentScene => currentScene;
    #endregion

    /// <summary>
    /// 정적 생성자
    /// </summary>
    static SceneHandler()
    {
        //현재 씬 이름을 저장
        currentScene = SceneManager.GetActiveScene().name;

        LogHandler.WriteLog("First LoadScene : " + currentScene, false, true);
    }

    /// <summary>
    /// 씬 불러오기
    /// </summary>
    /// <param name="id"></param>
    public static void LoadScene(string _id)
    {
        SceneManager.LoadScene(_id);

        currentScene = _id;

        LogHandler.WriteLog("LoadScene : " + currentScene, false, true);
    }
}
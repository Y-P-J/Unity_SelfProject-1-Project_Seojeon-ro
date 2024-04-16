using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//���� ���õ� ����� ����ϴ� Ŭ����
public static class SceneHandler
{
    [Tooltip("���� �� �̸�")]
    static string currentScene;

    #region ���ٽ� ������Ƽ
    public static string CurrentScene => currentScene;
    #endregion

    static SceneHandler()
    {
        //���� �� �̸��� ����
        currentScene = SceneManager.GetActiveScene().name;

        LogHandler.WriteLog("First LoadScene : " + currentScene, typeof(SceneHandler).Name, LogType.Log, true);
    }

    /// <summary>
    /// �� �ҷ�����
    /// </summary>
    public static void LoadScene(string _id)
    {
        SceneManager.LoadScene(_id);

        currentScene = _id;

        LogHandler.WriteLog("LoadScene : " + _id, typeof(SceneHandler).Name, LogType.Log, true);
    }

    /// <summary>
    /// SceneHandler �ʱ�ȭ�� ���� ���� �Լ�
    /// </summary>
    [RuntimeInitializeOnLoadMethod]
    static void MyNameIsKimSuHanMuIsVeryLongNameYouKnowAreIMean() { }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//���� ���õ� ����� ����ϴ� Ŭ����
public static class SceneHandler
{
    [Header("��")]
    [Tooltip("���� �� �̸�")]
    static string currentScene;



    #region ���ٽ� ������Ƽ
    public static string CurrentScene => currentScene;
    #endregion

    /// <summary>
    /// ���� ������
    /// </summary>
    static SceneHandler()
    {
        //���� �� �̸��� ����
        currentScene = SceneManager.GetActiveScene().name;

        LogHandler.WriteLog("First LoadScene : " + currentScene, false, true);
    }

    /// <summary>
    /// �� �ҷ�����
    /// </summary>
    /// <param name="id"></param>
    public static void LoadScene(string _id)
    {
        SceneManager.LoadScene(_id);

        currentScene = _id;

        LogHandler.WriteLog("LoadScene : " + currentScene, false, true);
    }
}
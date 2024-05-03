using UnityEngine;

//���� ��ü�� �۵��� ���õ� ����� ����ϴ� Ŭ����
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// ��üȭ�� ���� �Լ�
    /// </summary>
    public void SetFullScreen(bool _b)
    {
        if (_b)
            Screen.SetResolution(2560, 1440, true);
        else
        {
            float targetAspectRatio = 16f / 9f;
            int screenWidth = (int)(Display.main.systemWidth * 0.9f);
            int screenHeight = (int)(screenWidth / targetAspectRatio);
            Screen.SetResolution(screenWidth, screenHeight, false);
        }
    }

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
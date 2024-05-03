using UnityEngine;

//게임 자체의 작동과 관련된 기능을 담당하는 클래스
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// 전체화면 설정 함수
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//로그와 관련된 기능을 담당하는 클래스
public static class LogHandler
{
    /// <summary>
    /// 로그를 출력하는 함수
    /// </summary>
    public static void WriteLog(string _message, string _className, LogType _logtype, bool _saveLog)
    {
        switch (_logtype)
        {
            case LogType.Log:
                Debug.Log(_message);
                break;
            case LogType.Warning:
                Debug.LogWarning(_message);
                break;
            case LogType.Error:
                Debug.LogError(_message);
                break;
            case LogType.Exception:
                Debug.LogException(new System.Exception(_message));
                break;
            case LogType.Assert:
                Debug.LogAssertion(_message);
                break;
        }

        if (_saveLog)
        {
            //저장할 로그 메시지를 정리하여 작성
            string _logMessage = "[" + System.DateTime.Now + "]" + " " + _className + " / " + _logtype + " Error\n" + _message + "\n\n";

            string _directoryPath = "Logs/DeveloperLog";
            if (!System.IO.Directory.Exists(_directoryPath))
            {
                System.IO.Directory.CreateDirectory(_directoryPath);
            }

            System.IO.File.AppendAllText(_directoryPath + "/Log.txt", _logMessage);
        }
    }
}

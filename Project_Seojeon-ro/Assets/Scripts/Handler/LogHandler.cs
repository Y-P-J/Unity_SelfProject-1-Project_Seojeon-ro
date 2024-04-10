using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�α׿� ���õ� ����� ����ϴ� Ŭ����
public static class LogHandler
{
    /// <summary>
    /// �α׸� ����ϴ� �Լ�
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
            //������ �α� �޽����� �����Ͽ� �ۼ�
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

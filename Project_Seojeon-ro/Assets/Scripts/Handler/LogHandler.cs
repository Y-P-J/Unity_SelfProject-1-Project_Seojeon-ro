using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�α׿� ���õ� ����� ����ϴ� Ŭ����
public static class LogHandler
{
    /// <summary>
    /// �α׸� ����ϴ� �Լ�
    /// </summary>
    public static void WriteLog(string _message, bool _isError, bool _saveLog)
    {
        if (_isError)
            Debug.LogError(_message);
        else
            Debug.Log(_message);

        if (_saveLog)
        {
            //�α� �޽����� ��¥�� �Բ� ���
            string _logMessage = System.DateTime.Now + " / " + _message;

            //�α� ���Ͽ� ���
            if(_isError)
                System.IO.File.AppendAllText("errorLog.txt", _logMessage + "\n");
            else
                System.IO.File.AppendAllText("log.txt", _logMessage + "\n");
        }
    }
}

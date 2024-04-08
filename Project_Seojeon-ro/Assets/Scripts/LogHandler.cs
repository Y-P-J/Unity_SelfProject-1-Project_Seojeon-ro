using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�α׿� ���õ� ����� ����ϴ� Ŭ����
public static class LogHandler
{
    /// <summary>
    /// �α׸� ����ϴ� �Լ�
    /// </summary>
    /// <param name="_saveLog">�ܺο� ����� �� true</param>
    public static void WriteLog(string _message, bool _saveLog = false)
    {
        Debug.Log(_message);

        if (_saveLog)
        {
            //�α� �޽����� ��¥�� �Բ� ���
            string _logMessage = System.DateTime.Now + " / " + _message;

            //�α� ���Ͽ� ���
            System.IO.File.AppendAllText("log.txt", _logMessage + "\n");
        }
    }
}

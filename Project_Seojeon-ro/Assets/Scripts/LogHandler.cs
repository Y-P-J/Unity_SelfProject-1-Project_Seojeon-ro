using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//로그와 관련된 기능을 담당하는 클래스
public static class LogHandler
{
    /// <summary>
    /// 로그를 출력하는 함수
    /// </summary>
    /// <param name="_saveLog">외부에 기록할 시 true</param>
    public static void WriteLog(string _message, bool _saveLog = false)
    {
        Debug.Log(_message);

        if (_saveLog)
        {
            //로그 메시지를 날짜와 함께 기록
            string _logMessage = System.DateTime.Now + " / " + _message;

            //로그 파일에 기록
            System.IO.File.AppendAllText("log.txt", _logMessage + "\n");
        }
    }
}

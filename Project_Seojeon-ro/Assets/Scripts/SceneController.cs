using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//씬의 작동과 관련된 기능을 담당하는 클래스
public class SceneController : MonoBehaviour
{
    /// <summary>
    /// 씬을 로드하는 함수
    /// </summary>
    public void LoadScene(string _id) => SceneHandler.LoadScene(_id);
}
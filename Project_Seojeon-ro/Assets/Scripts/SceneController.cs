using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//씬의 작동과 관련된 기능을 담당하는 클래스 (싱글톤으로 제작시 각 씬에서 UI에서 참조해 사용할 수 없기 때문에 일반 클래스로 제작해 각각 씬에 추가해 사용)
public class SceneController : MonoBehaviour
{
    /// <summary>
    /// 씬을 로드하는 함수
    /// </summary>
    public void LoadScene(string _id) => SceneHandler.LoadScene(_id);
}
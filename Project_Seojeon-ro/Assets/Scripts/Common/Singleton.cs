using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//싱글톤 패턴 적용을 위한 클래스
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //싱글톤 인스턴스
    private static T _instance;
    
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //싱글톤 인스턴스가 없다면 씬에서 찾아서 가져온다.
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject singleton = new GameObject();
                    _instance = singleton.AddComponent<T>();

                    singleton.name = typeof(T).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        //이미 인스턴스가 있다면 이 인스턴스를 파괴하고 다른 인스턴스를 생성하지 않는다.
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this as T;
        }

        //다른 씬으로 넘어가도 파괴되지 않도록 설정
        DontDestroyOnLoad(this.gameObject);
    }
}
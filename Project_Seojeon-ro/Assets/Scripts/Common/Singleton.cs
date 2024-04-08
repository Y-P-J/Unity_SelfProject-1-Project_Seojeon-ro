using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�̱��� ���� ������ ���� Ŭ����
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //�̱��� �ν��Ͻ�
    private static T _instance;
    
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //�̱��� �ν��Ͻ��� ���ٸ� ������ ã�Ƽ� �����´�.
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
        //�̹� �ν��Ͻ��� �ִٸ� �� �ν��Ͻ��� �ı��ϰ� �ٸ� �ν��Ͻ��� �������� �ʴ´�.
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this as T;
        }

        //�ٸ� ������ �Ѿ�� �ı����� �ʵ��� ����
        DontDestroyOnLoad(this.gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �۵��� ���õ� ����� ����ϴ� Ŭ���� (�̱������� ���۽� �� ������ UI���� ������ ����� �� ���� ������ �Ϲ� Ŭ������ ������ ���� ���� �߰��� ���)
public class SceneController : MonoBehaviour
{
    /// <summary>
    /// ���� �ε��ϴ� �Լ�
    /// </summary>
    public void LoadScene(string _id) => SceneHandler.LoadScene(_id);
}
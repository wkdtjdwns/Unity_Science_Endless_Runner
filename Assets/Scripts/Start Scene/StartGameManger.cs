using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManger : MonoBehaviour
{
    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    // Hierarchy â�� ������Ʈ�� ��� ����Ǹ� ����� �� �ѹ��� ����Ǵ� �Ӽ���

    // BeforeSceneLoad -> Awake() �Լ����� ���� ����ǵ��� ��
    // ���� : AfterSceneLoad -> Awake() �Լ��� Start() �Լ��� ���̿��� ����ǵ��� ��
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void FirstLoad() { if (SceneManager.GetActiveScene().name.CompareTo("StartScene") != 0) { SceneManager.LoadScene("StartScene"); } }
    // ������ �����ϸ� � Scene�� ���� �־����� StartScene���� �����ϰ� ��

    public void GameStart() { SceneManager.LoadScene("HomeScene"); }
}
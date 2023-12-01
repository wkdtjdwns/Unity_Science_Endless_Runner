using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManger : MonoBehaviour
{
    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    // Hierarchy 창에 오브젝트가 없어도 실행되며 실행시 딱 한번만 실행되는 속성임

    // BeforeSceneLoad -> Awake() 함수보다 먼저 실행되도록 함
    // 참고 : AfterSceneLoad -> Awake() 함수와 Start() 함수의 사이에서 실행되도록 함
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void FirstLoad() { if (SceneManager.GetActiveScene().name.CompareTo("StartScene") != 0) { SceneManager.LoadScene("StartScene"); } }
    // 게임을 시작하면 어떤 Scene을 보고 있었더라도 StartScene에서 시작하게 함

    public void GameStart() { SceneManager.LoadScene("HomeScene"); }
}
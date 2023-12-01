using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunningButtonManager : GameManager
{
    [SerializeField]
    private GameObject option_obj;
    Option option;

    RunningGameManager game_manager;

    private void Awake()
    {
        option = option_obj.GetComponent<Option>();

        game_manager = GameObject.Find("GameManager").gameObject.GetComponent<RunningGameManager>();
    }

    public void ResulutCheck()
    {
        // 소지 용액의 총 수에 얻은 용액의 개수를 더해줌
        solution_num += game_manager.solution_cnt;

        // 달린 거리에 비례해서 돈을 얻게 함
        gold += (int)game_manager.run_distance * 50;

        SoundManager.instance.PlayBgm("home");
        SceneManager.LoadScene("HomeScene");
    }

    public void Resume() { SoundManager.instance.PlaySound("button"); option.OptionOnOff(); }

    public void SoundHear() { SoundManager.instance.PlaySound("sound hear"); }

    public void GameExit() { game_manager.is_tired = true; }
}

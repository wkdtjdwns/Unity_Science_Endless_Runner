using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButtonManager : ButtonManager
{
    HomeGameManager game_manager;
    Guide guide;

    private void Awake()
    {
        game_manager = GameObject.Find("GameManager").gameObject.GetComponent<HomeGameManager>();
        guide = GameObject.Find("Guide").gameObject.GetComponent<Guide>();
    }

    // 해당 오브젝트를 켰다가 껐다가 하는 메소드 들
    public void OpenShop() { SoundManager.instance.PlaySound("button"); game_manager.shop.SetActive(true); }

    public void CloseShop() { SoundManager.instance.PlaySound("button"); game_manager.shop.SetActive(false); }

    public void OpenSell() { SoundManager.instance.PlaySound("button"); game_manager.is_sell = true; }

    public void CloseSell() { SoundManager.instance.PlaySound("button"); game_manager.is_sell = false; }

    public void OpenGuide() { SoundManager.instance.PlaySound("button"); game_manager.guide.SetActive(true); }

    public void CloseGuide() { SoundManager.instance.PlaySound("button"); game_manager.guide.SetActive(false); }

    // 다른 Scene으로 이동할지 결정하고 이동하는 메소드들
    // Go~~()      : 갈지 말지 결정
    // Go~~Check() : 해당 Scene 이동
    // NotGo~~()   : 이동하지 않음
    public void GoRunning() { SoundManager.instance.PlaySound("button"); game_manager.go_running_check_obj.SetActive(true); }

    public void GoRunningCheck() { SoundManager.instance.PlayBgm("running"); game_manager.ChangeScene("RunnigScene"); }

    public void NotGoRunning() { SoundManager.instance.PlaySound("button"); game_manager.go_running_check_obj.SetActive(false); }

    public void GoExperiment() { SoundManager.instance.PlaySound("button"); game_manager.go_experiment_check_obj.SetActive(true); }

    public void GoExperimentCheck() { SoundManager.instance.PlayBgm("experiment"); ; game_manager.ChangeScene("ExperimentScene"); }

    public void NotGoExperiment() { SoundManager.instance.PlaySound("button"); game_manager.go_experiment_check_obj.SetActive(false); }

    public void PageUp()
    {
        // 마지막 페이지에서 실행하려하면 실행하지 않음
        if (game_manager.page >= 2) { return; }

        // "먼저" 도감의 페이지를 증가시킴
        ++game_manager.page;

        // 페이지를 바꿈
        ChangePage();
    }

    public void PageDown()
    {
        // 첫번째 페이지에서 실행하려하면 실행하지 않음
        if (game_manager.page <= 0) { return; }

        // "먼저" 도감의 페이지를 감소시킴
        --game_manager.page;

        // 페이지를 바꿈
        ChangePage();
    }

    private void ChangePage()
    {
        SoundManager.instance.PlaySound("button");

        // 언락되어 있지 않은 페이지는 잠궈둠
        game_manager.lock_solution_group.SetActive(!guide.solution_unlock_list[game_manager.page]);

        // 페이지 텍스트를 갱신함
        game_manager.page_text.text = string.Format("#{0:00}", (game_manager.page + 1));

        // 만약 해당 페이지가 잠겨있다면 용액의 이미지만 바꿔줌
        if (game_manager.lock_solution_group.activeSelf) { game_manager.lock_group_solution_img.sprite = game_manager.solution_sprite_list[game_manager.page]; }

        // 해당 페이지가 언락되어 있다면
        else
        {
            // 용액 이미지와 용액의 이름을 바꿔주고
            game_manager.unlock_group_solution_img.sprite = game_manager.solution_sprite_list[game_manager.page];
            game_manager.unlock_group_solution_name_text.text = game_manager.solution_name_list[game_manager.page];

            // 해당 용액에 대한 설명 또한 바꿔줌
            switch (game_manager.page)
            {
                case 0:
                    game_manager.solution_result_color_text.text = string.Format("산성 : {0}\n중성 : {1}\n염기성 : {2}", game_manager.btb_result_color_list[0], game_manager.btb_result_color_list[1], game_manager.btb_result_color_list[2]);
                    break;

                case 1:
                    game_manager.solution_result_color_text.text = string.Format("산성 : {0}\n중성 : {1}\n염기성 : {2}", game_manager.methyl_result_color_list[0], game_manager.methyl_result_color_list[1], game_manager.methyl_result_color_list[2]);
                    break;

                case 2:
                    game_manager.solution_result_color_text.text = string.Format("산성 : {0}\n중성 : {1}\n염기성 : {2}", game_manager.phenol_result_color_list[0], game_manager.phenol_result_color_list[1], game_manager.phenol_result_color_list[2]);
                    break;
            }
        }
    }
}

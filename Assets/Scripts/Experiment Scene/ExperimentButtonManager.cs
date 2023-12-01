using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExperimentButtonManager : GameManager
{
    ExperimentGameManager game_manager;
    Guide guide;
    Animator goods_anim;
    Animator solutions_anim;
    Image image;

    [SerializeField]
    private Sprite normal_sprite;

    [SerializeField]
    private Sprite[] goods_sprites;
    [SerializeField]
    private Sprite[] btb_results;
    [SerializeField]
    private Sprite[] methyl_results;
    [SerializeField]
    private Sprite[] phenol_results;

    [SerializeField]
    private Button acid_button;
    [SerializeField]
    private Button neutrality_button;
    [SerializeField]
    private Button basic_button;

    [SerializeField]
    private Text question_text;

    [SerializeField]
    private bool is_water;
    [SerializeField]
    private bool is_vinegar;
    [SerializeField]
    private bool is_orange_juice;
    [SerializeField]
    private bool is_baking_soda;
    [SerializeField]
    private bool is_sparkling_water;

    private void Awake()
    {
        is_water = false;
        is_vinegar = false;
        is_orange_juice = false;
        is_baking_soda = false;
        is_sparkling_water = false;

        game_manager = GameObject.Find("GameManager").gameObject.GetComponent<ExperimentGameManager>();
        guide = GameObject.Find("Guide").gameObject.GetComponent<Guide>();
        goods_anim = game_manager.need_goods_obj.GetComponent<Animator>();
        solutions_anim = game_manager.need_solutions_obj.GetComponent<Animator>();
        image = game_manager.background.GetComponent<Image>();
    }

    public void BackHome() { SoundManager.instance.PlayBgm("home"); SceneManager.LoadScene("HomeScene"); }

    public void SoundHear() { SoundManager.instance.PlaySound("sound hear"); }

    public void UseGoods(string type)
    {
        switch (type)
        {
            // 1. 먼저 아이템을 가지고 있는지 판단함
            // 2-1. 만약 아이템을 가지고 있으면 해당 아이템을 넣었다는 신호 (bool)을 주고 용액을 넣을 수 있도록 (is_goods)함
            // 2-2. 그 다음 해당 아이템의 개수를 줄이고 해당 아이템을 넣는 (이미지 적용) 메소드를 실행함
            // 3. 만약 아이템을 가지고 있지 않다면 아이템이 필요하다는 애니매이션을 실행함

            case "water":
                if (water_num > 0)
                {
                    is_water = true;
                    game_manager.is_goods = true;

                    water_num--;
                    PutGoods(type);
                }

                else { StartCoroutine(NeedAnim("goods")); }
                break;

            case "vinegar":
                if (vinegar_num > 0)
                {
                    is_vinegar = true;
                    game_manager.is_goods = true;

                    vinegar_num--;
                    PutGoods(type);
                }

                else { StartCoroutine(NeedAnim("goods")); }
                break;

            case "orange juice":
                if (orange_juice_num > 0)
                {
                    is_orange_juice = true;
                    game_manager.is_goods = true;

                    orange_juice_num--;
                    PutGoods(type);
                }

                else { StartCoroutine(NeedAnim("goods")); }
                break;

            case "baking soda":
                if (baking_soda_num > 0)
                {
                    is_baking_soda = true;
                    game_manager.is_goods = true;

                    baking_soda_num--;
                    PutGoods(type);
                }

                else { StartCoroutine(NeedAnim("goods")); }
                break;

            case "sparkling water":
                if (sparkling_water_num > 0)
                {
                    is_sparkling_water = true;
                    game_manager.is_goods = true;

                    sparkling_water_num--;
                    PutGoods(type);
                }

                else { StartCoroutine(NeedAnim("goods")); }
                break;
        }
    }

    public void UseSolutions(string type)
    {
        // 1. 먼저 용액을 가지고 있는지 판단함
        // 2-1. 만약 용액을 가지고 있으면 해당 용액을 넣었다는 신호 (bool)을 줌
        // 2-2. 그 다음 해당 용액의 개수를 줄이고 전체 용액의 개수도 줄이며 해당 용액을 넣는 (이미지 적용) 메소드를 실행함
        // 3. 만약 용액을 가지고 있지 않다면 용액이 필요하다는 애니매이션을 실행함

        switch (type)
        {
            case "btb":
                if (btb_num > 0)
                {
                    btb_num--;
                    solution_num--;
                    PutSolutions(type);
                }

                else { StartCoroutine(NeedAnim("solutions")); }
                break;

            case "methyl":
                if (methyl_num > 0)
                {
                    methyl_num--;
                    solution_num--;
                    PutSolutions(type);
                }

                else { StartCoroutine(NeedAnim("solutions")); }
                break;

            case "phenol":
                if (phenol_num > 0)
                {
                    phenol_num--;
                    solution_num--;
                    PutSolutions(type);
                }

                else { StartCoroutine(NeedAnim("solutions")); }
                break;
        }
    }

    private IEnumerator NeedAnim(string type)
    {
        SoundManager.instance.PlaySound("need");

        // 무엇이 필요한지에 따라서 다른 애니매이션을 실행함
        switch (type)
        {
            case "goods":
                goods_anim.SetBool("is_need", true);

                yield return new WaitForSeconds(0.25f);

                goods_anim.SetBool("is_need", false);
                break;

            case "solutions":

                solutions_anim.SetBool("is_need", true);

                yield return new WaitForSeconds(0.25f);

                solutions_anim.SetBool("is_need", false);
                break;
        }
    }

    private void PutGoods(string type)
    {
        SoundManager.instance.PlaySound("put goods");

        // 넣은 아이템에 따라서 이미지를 바꿈
        switch (type)
        {
            case "water":
                image.sprite = goods_sprites[0];
                break;

            case "vinegar":
                image.sprite = goods_sprites[1];
                break;

            case "orange juice":
                image.sprite = goods_sprites[2];
                break;

            case "baking soda":
                image.sprite = goods_sprites[3];
                break;

            case "sparkling water":
                image.sprite = goods_sprites[4];
                break;
        }
    }

    private void PutSolutions(string type)
    {
        SoundManager.instance.PlaySound("put solution");

        // 이전에 넣은 아이템의 성질 (산성, 중성, 염기성)과 넣은 용액에 따라서 이미지를 바꿈

        // 염기성 : 베이킹 소다             -> result[0]
        // 중성 : 물                        -> result[1]
        // 산성 : 식초, 오렌지 주스. 탄산수 -> result[2]

        // 각 용액의 산 -> 중 -> 염 순서의 색깔 변화
        // BTB 용액          -> 노랑, 초록, 파랑
        // 메틸 오렌지 용액  -> 빨, 주(노), 주(노)
        // 페놀프탈레인 용액 -> 무, 무, 빨

        // 또한 어떤 용액을 넣었는지 신호 (bool)을 줌
        switch (type)
        {
            case "btb":
                if (is_baking_soda) { image.sprite = btb_results[0]; }
                else if (is_water) { image.sprite = btb_results[1]; }
                else { image.sprite = btb_results[2]; }
                guide.is_btb = true;
                break;

            case "methyl":
                if (is_baking_soda) { image.sprite = methyl_results[0]; }
                else if (is_water) { image.sprite = methyl_results[1]; }
                else { image.sprite = methyl_results[2]; }
                guide.is_methyl = true;
                break;

            case "phenol":
                if (is_baking_soda) { image.sprite = phenol_results[0]; }
                else if (is_water) { image.sprite = phenol_results[1]; }
                else { image.sprite = phenol_results[2]; }
                break;
        }

        // 용액을 넣었다는 신호를 줌
        game_manager.is_solution = true;

        // 해당 용액의 성질을 묻는 질문 메소드 실행
        AskQuestion();
    }

    private void AskQuestion()
    {
        Invoke("PlayMixSolutionSound", 0.25f);

        game_manager.question_obj.SetActive(true);

        // 모든 버튼을 누를 수 있게 활성화 시켜줌
        acid_button.interactable = true;
        basic_button.interactable = true;
        neutrality_button.interactable = true;

        // 넣은 아이템에 따라서 텍스트를 바꿔줌
        if (is_water) { question_text.text = "물의 성질은?"; }
        else if (is_vinegar) { question_text.text = "식초의 성질은?"; }
        else if (is_orange_juice) { question_text.text = "오렌지 주스의 성질은?"; }
        else if (is_baking_soda) { question_text.text = "베이킹 소다의 성질은?"; }
        else if (is_sparkling_water) { question_text.text = "탄산수의 성질은?"; }
    }

    private void PlayMixSolutionSound() { SoundManager.instance.PlaySound("mix solution"); }

    public void Answer(string type)
    {
        // 넣었던 아이템의 성질에 따라서 눌렀을 때 정답인 경우가 달라짐

        // 정답일 경우에는 정답이라는 신호 (is_correct)를 주고
        // 오답일 경우에는 IsWrong() 메소드 실행
        if (is_vinegar || is_orange_juice || is_sparkling_water)
        {
            if (type.Equals("acid")) { game_manager.is_correct = true; }
            else if (type.Equals("basic")) { IsWrong(basic_button); }
            else { IsWrong(neutrality_button); }
        }

        else if (is_water)
        {
            if (type.Equals("neutrality")) { game_manager.is_correct = true; }
            else if (type.Equals("acid")) { IsWrong(acid_button); }
            else { IsWrong(basic_button); }
        }

        else if (is_baking_soda)
        {
            if (type.Equals("basic")) { game_manager.is_correct = true; }
            else if (type.Equals("acid")) { IsWrong(acid_button); }
            else { IsWrong(neutrality_button); }
        }

        CheckAnswer();
    }

    private void IsWrong(Button bnt)
    {
        // 해당 버튼을 비활성화하고 틀렸다는 신호(is_wrong)을 줌
        bnt.interactable = false;
        game_manager.is_wrong = true;
    }

    private void CheckAnswer()
    {
        if (game_manager.is_correct)
        {
            SoundManager.instance.PlaySound("correct");

            game_manager.correct_obj.SetActive(true);
            Invoke("OffCorrectObj", 0.5f);

            // 도감 언락
            guide.Unlock();

            // 모든 bool 변수 초기화
            is_water = false;
            is_vinegar = false;
            is_orange_juice = false;
            is_baking_soda = false;
            is_sparkling_water = false;

            guide.is_btb = false;
            guide.is_methyl = false;
        }

        else
        {
            SoundManager.instance.PlaySound("wrong");

            game_manager.wrong_obj.SetActive(true);
            Invoke("OffWrongObj", 0.5f);
            game_manager.is_wrong = false;
        }
    }

    // 정답 또는 오답 표시를 지우는 메소드
    private void OffCorrectObj() { game_manager.correct_obj.SetActive(false); image.sprite = normal_sprite; }

    private void OffWrongObj() { game_manager.wrong_obj.SetActive(false); }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : GameManager
{
    [SerializeField]
    private Text remaining_btb_text;
    [SerializeField]
    private Text remaining_methyl_text;
    [SerializeField]
    private Text remaining_phenol_text;

    [SerializeField]
    private GameObject shop_keeper_obj;

    ShopKeeper shop_keeper;
    HomeGameManager game_manager;
    Animator gold_anim;
    Animator solution_anim;

    private void Awake()
    {
        shop_keeper = shop_keeper_obj.GetComponent<ShopKeeper>();
        game_manager = GameObject.Find("GameManager").gameObject.GetComponent<HomeGameManager>();
        gold_anim = game_manager.need_money_obj.GetComponent<Animator>();
        solution_anim = game_manager.need_solution_obj.GetComponent<Animator>();
    }

    // 남아있는 용액의 수를 계속해서 갱신해줌
    private void Update() { SetRemainingNumber(); }

    private void OnEnable() { shop_keeper.OnTalk("purchase"); }

    private void SetRemainingNumber()
    {
        remaining_btb_text.text = string.Format("{0}개", btb_num);
        remaining_methyl_text.text = string.Format("{0}개", methyl_num);
        remaining_phenol_text.text = string.Format("{0}개", phenol_num);
    }
    
    public void PurchaseGoods(string type)
    {
        // 1. 먼저 해당 아이템을 살만큼의 가격 (원가 + 추가 금액)만큼의 돈을 가지고 있는지 판단함
        // 2-1. 만약 가지고 있다면 해당 아이템의 가격만큼 돈을 감소시키고
        // 2-2. 해당 아이템의 효과를 적용하거나 아이템의 개수를 1개 늘려줌
        // 3. 만약 가지고 있지 않다면 돈이 필요하다는 애니매이션을 실행함

        switch (type)
        {
            case "health":
                if (gold >= game_manager.add_health_price + game_manager.add_prices[0])
                {
                    SoundManager.instance.PlaySound("purchase");

                    gold -= game_manager.add_health_price + game_manager.add_prices[0];
                    add_health += 5.0f;
                }

                else
                {
                    SoundManager.instance.PlaySound("need");

                    gold_anim.SetBool("is_need", true);
                    Invoke("StopGoldAnim", 0.25f);
                }
                break;

            case "water":
                if (gold >= game_manager.water_price + game_manager.add_prices[1])
                {
                    SoundManager.instance.PlaySound("purchase");

                    gold -= game_manager.water_price + game_manager.add_prices[1];
                    water_num++;
                }

                else
                {
                    SoundManager.instance.PlaySound("need");

                    gold_anim.SetBool("is_need", true);
                    Invoke("StopGoldAnim", 0.25f);
                }
                break;

            case "vinegar":
                if (gold >= game_manager.vinegar_price + game_manager.add_prices[2])
                {
                    SoundManager.instance.PlaySound("purchase");

                    gold -= game_manager.vinegar_price + game_manager.add_prices[2];
                    vinegar_num++;
                }

                else
                {
                    SoundManager.instance.PlaySound("need");

                    gold_anim.SetBool("is_need", true);
                    Invoke("StopGoldAnim", 0.25f);
                }
                break;

            case "orange juice":
                if (gold >= game_manager.orange_juice_price + game_manager.add_prices[3])
                {
                    SoundManager.instance.PlaySound("purchase");

                    gold -= game_manager.orange_juice_price + game_manager.add_prices[3];
                    orange_juice_num++;
                }

                else
                {
                    SoundManager.instance.PlaySound("need");

                    gold_anim.SetBool("is_need", true);
                    Invoke("StopGoldAnim", 0.25f);
                }
                break;

            case "baking soda":
                if (gold >= game_manager.baking_soda_price + game_manager.add_prices[4])
                {
                    SoundManager.instance.PlaySound("purchase");

                    gold -= game_manager.baking_soda_price + game_manager.add_prices[4];
                    baking_soda_num++;
                }

                else
                {
                    SoundManager.instance.PlaySound("need");

                    gold_anim.SetBool("is_need", true);
                    Invoke("StopGoldAnim", 0.25f);
                }
                break;

            case "sparkling water":
                if (gold >= game_manager.sparkling_water_price + game_manager.add_prices[5])
                {
                    SoundManager.instance.PlaySound("purchase");

                    gold -= game_manager.sparkling_water_price + game_manager.add_prices[5];
                    sparkling_water_num++;
                }

                else
                {
                    SoundManager.instance.PlaySound("need");

                    gold_anim.SetBool("is_need", true);
                    Invoke("StopGoldAnim", 0.25f);
                }
                break;
        }
    }

    private void StopGoldAnim() { gold_anim.SetBool("is_need", false); }

    public void SellSolution(string type)
    {
        // 1. 먼저 해당 용액을 가지고 있는지 판단함
        // 2-1. 만약 가지고 있다면 해당 용액의 개수와 전체 용액의 개수를 줄이고
        // 2-2. 해당 용액의 금액만큼 소지 금액을 늘려줌
        // 3. 만약 가지고 있지 않다면 용액이 필요하다는 애니매이션을 실행함

        switch (type)
        {
            case "btb":
                if (btb_num > 0)
                {
                    gold += game_manager.btb_price + game_manager.add_prices[6];
                    btb_num--;
                    solution_num--;

                    SoundManager.instance.PlaySound("sell");
                }

                else
                {
                    SoundManager.instance.PlaySound("need");

                    solution_anim.SetBool("is_need", true);
                    Invoke("StopSolutionAnim", 0.25f);
                }
                break;

            case "methyl":
                if (methyl_num > 0)
                {
                    gold += game_manager.methyl_price + game_manager.add_prices[7];
                    methyl_num--;
                    solution_num--;

                    SoundManager.instance.PlaySound("sell");
                }

                else
                {
                    SoundManager.instance.PlaySound("need");

                    solution_anim.SetBool("is_need", true);
                    Invoke("StopSolutionAnim", 0.25f);
                }
                break;

            case "phenol":
                if (phenol_num > 0)
                {
                    gold += game_manager.phenol_price + game_manager.add_prices[8];
                    phenol_num--;
                    solution_num--;

                    SoundManager.instance.PlaySound("sell");
                }

                else
                {
                    SoundManager.instance.PlaySound("need");

                    solution_anim.SetBool("is_need", true);
                    Invoke("StopSolutionAnim", 0.25f);
                }
                break;
        }
    }

    private void StopSolutionAnim() { solution_anim.SetBool("is_need", false); }
}

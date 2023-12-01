using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]
    private Text shop_keeper_text;

    [SerializeField]
    private string[] purchase_texts;
    [SerializeField]
    private string[] sell_texts;
    [SerializeField]
    private string[] chat_texts;

    [SerializeField]
    private Sprite[] shop_keeper_sprites;
    Image img;

    public bool is_talk;

    private void Awake() { img = GetComponent<Image>(); }

    public void OnTalk(string type)
    {
        // 모든 Coroutine 함수를 중지시켜서 오류가 생기지 않게 함
        StopAllCoroutines();

        // 말하고 있다는 신호 (is_talk)를 주고 상황에 맞는 얘기를 시작하면서 말을 하는 애니매이션을 실행함
        is_talk = true;
        ShopKeeperTalk(type);
        StartCoroutine(KeeperAnim());
    }

    private void ShopKeeperTalk(string type)
    {
        // 상황에 맞는 얘기들 중에서 랜덤으로 골라서 얘기함
        switch (type)
        {
            case "purchase":
                int ran_purchase_index = Random.Range(0, purchase_texts.Length);
                StartCoroutine(TypingCoroutine(purchase_texts[ran_purchase_index], 0.05f));
                break;

            case "sell":
                int ran_sell_index = Random.Range(0, sell_texts.Length);
                StartCoroutine(TypingCoroutine(sell_texts[ran_sell_index], 0.05f));
                break;

            case "chat":
                int ran_chat_index = Random.Range(0, chat_texts.Length);
                StartCoroutine(TypingCoroutine(chat_texts[ran_chat_index], 0.05f));
                break;
        }
    }

    private IEnumerator TypingCoroutine(string str, float next_typing_time)
    {
        // 타이핑할 문자의 수를 셈
        int typing_length = str.GetTypingLength();

        // Hierarchy 창에서 적은 \n(줄바꿈 표시)가 작동하도록 함
        str = str.Replace("\\n", "\n");

        // 타이핑할 문자의 수만큼 반복함
        for (int index = 0; index <= typing_length; index++)
        {
            SoundManager.instance.PlaySound("talk");

            // 텍스트를 타이핑함
            shop_keeper_text.text = str.Typing(index);
            yield return new WaitForSeconds(next_typing_time);
        }

        // 모든 타이핑이 끝나면 말을 종료했다는 신호를 줌
        is_talk = false;
    }

    private IEnumerator KeeperAnim()
    {
        int index = 0;

        // 말을 하고 있는 동안 실행함
        while (is_talk)
        {
            // 만약 인덱스가 얘기하는 이미지의 개수 (0부터 시작)보다 작으면 증가시키지만
            // 얘기하는 이미지의 개수 (0부터 시작)보다 크거나 작으면 다시 0으로 만듦
            index = index < (shop_keeper_sprites.Length - 1) ? (index + 1) : 0;

            // 해당 인덱스의 이미지를 적용시킴
            img.sprite = shop_keeper_sprites[index];

            yield return new WaitForSeconds(0.1f);
        }

        // 모든 말이 끝나면 다시 원상태의 이미지를 적용하고
        img.sprite = shop_keeper_sprites[0];

        // 혹시 모를 상황에 대비해 모든 Coroutine 함수를 중지시킴
        StopAllCoroutines();
    }
}

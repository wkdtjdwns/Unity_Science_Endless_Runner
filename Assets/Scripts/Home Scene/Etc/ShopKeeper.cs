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
        // ��� Coroutine �Լ��� �������Ѽ� ������ ������ �ʰ� ��
        StopAllCoroutines();

        // ���ϰ� �ִٴ� ��ȣ (is_talk)�� �ְ� ��Ȳ�� �´� ��⸦ �����ϸ鼭 ���� �ϴ� �ִϸ��̼��� ������
        is_talk = true;
        ShopKeeperTalk(type);
        StartCoroutine(KeeperAnim());
    }

    private void ShopKeeperTalk(string type)
    {
        // ��Ȳ�� �´� ���� �߿��� �������� ��� �����
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
        // Ÿ������ ������ ���� ��
        int typing_length = str.GetTypingLength();

        // Hierarchy â���� ���� \n(�ٹٲ� ǥ��)�� �۵��ϵ��� ��
        str = str.Replace("\\n", "\n");

        // Ÿ������ ������ ����ŭ �ݺ���
        for (int index = 0; index <= typing_length; index++)
        {
            SoundManager.instance.PlaySound("talk");

            // �ؽ�Ʈ�� Ÿ������
            shop_keeper_text.text = str.Typing(index);
            yield return new WaitForSeconds(next_typing_time);
        }

        // ��� Ÿ������ ������ ���� �����ߴٴ� ��ȣ�� ��
        is_talk = false;
    }

    private IEnumerator KeeperAnim()
    {
        int index = 0;

        // ���� �ϰ� �ִ� ���� ������
        while (is_talk)
        {
            // ���� �ε����� ����ϴ� �̹����� ���� (0���� ����)���� ������ ������Ű����
            // ����ϴ� �̹����� ���� (0���� ����)���� ũ�ų� ������ �ٽ� 0���� ����
            index = index < (shop_keeper_sprites.Length - 1) ? (index + 1) : 0;

            // �ش� �ε����� �̹����� �����Ŵ
            img.sprite = shop_keeper_sprites[index];

            yield return new WaitForSeconds(0.1f);
        }

        // ��� ���� ������ �ٽ� �������� �̹����� �����ϰ�
        img.sprite = shop_keeper_sprites[0];

        // Ȥ�� �� ��Ȳ�� ����� ��� Coroutine �Լ��� ������Ŵ
        StopAllCoroutines();
    }
}

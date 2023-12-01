using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : GameManager
{
    [SerializeField]
    private string type;
    [SerializeField]
    private float speed;

    RunningGameManager game_manager;

    private void Awake() { game_manager = GameObject.Find("GameManager").gameObject.GetComponent<RunningGameManager>(); }

    private void Update() { Move(); }

    private void Move()
    {
        // �������� �����̰��ϰ�
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        // ������� �ָ����� �����ǵ��� ��
        if (transform.position.x <= -25f) { Destroy(gameObject); }
    }

    // �ٸ� ������Ʈ�� ����� ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ش� ������Ʈ�� �±׸� �˻��ؼ� "Player" ���� ������
        if (collision.gameObject.tag == "Player")
        {
            // ���� Ÿ�Կ� ���� ����� ���� ������Ŵ
            switch (type)
            {
                case "btb":
                    btb_num++;
                    break;

                case "methyl":
                    methyl_num++;
                    break;

                case "penol":
                    phenol_num++;
                    break;
            }

            // ��ü ����� ���� ������Ŵ
            game_manager.solution_cnt++;

            SoundManager.instance.PlaySound("get solution");

            // �� �ڽ��� �����ϵ��� ��
            Destroy(gameObject);
        }
    }

}

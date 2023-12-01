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
        // 왼쪽으로 움직이게하고
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        // 어느정도 멀리가면 삭제되도록 함
        if (transform.position.x <= -25f) { Destroy(gameObject); }
    }

    // 다른 오브젝트에 닿았을 때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 해당 오브젝트의 태그를 검색해서 "Player" 값이 나오면
        if (collision.gameObject.tag == "Player")
        {
            // 나의 타입에 따라서 용액의 수를 증가시킴
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

            // 전체 용액의 수를 증가시킴
            game_manager.solution_cnt++;

            SoundManager.instance.PlaySound("get solution");

            // 나 자신을 삭제하도록 함
            Destroy(gameObject);
        }
    }

}

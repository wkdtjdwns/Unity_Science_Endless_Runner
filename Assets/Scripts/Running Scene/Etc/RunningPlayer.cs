using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningPlayer : GameManager
{
    [SerializeField]
    private int jump_cnt;
    private bool is_jumping;

    public int max_jump_cnt;
    public float jump_power;

    public float health;

    [SerializeField]
    private GameObject option_obj;
    Option option;

    Rigidbody2D rigid;
    Animator anim;

    RunningGameManager game_manager;

    private void Awake()
    {
        // 각종 값 초기화
        Setting();

        option = option_obj.GetComponent<Option>();

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        game_manager = GameObject.Find("GameManager").gameObject.GetComponent<RunningGameManager>();
    }

    private void Setting()
    {
        jump_cnt = 0;
        max_jump_cnt = 2;
        jump_power = 850f;
        health = 10f + add_health;
    }

    private void OnDisable() { anim.SetBool("is_running", false); }

    private void Update()
    {
        Move();

        Jump();

        CheatKey();
    }

    private void Move()
    {
        HealthDown();

        if (!is_jumping) { anim.SetBool("is_running", true); }
        else { anim.SetBool("is_running", false); }
    }

    private void HealthDown()
    {
        // 체력이 남아있으면 체력을 계속 줄이고
        if (health > 0) { health -= Time.deltaTime; }

        // 없으면 지쳤다는 신호를 줌
        else { game_manager.is_tired = true; }
    }

    private void Jump()
    {
        // 버튼을 눌렀을 때 점프를 많이 하지 않은 상태면서 옵션창이 활성화되어 있지 않으면
        if (Input.GetMouseButtonDown(0) && jump_cnt < max_jump_cnt && !option.is_option)
        {
            SoundManager.instance.PlaySound("jump");

            // 점프 횟수를 증가시키고
            jump_cnt++;

            rigid.velocity = Vector2.zero;

            // 점프시키고
            rigid.AddForce(new Vector2(0, jump_power));

            // 점프하고 있다는 신호를 줌
            is_jumping = true;
            anim.SetBool("is_jumping", true);
        }

        else if (Input.GetMouseButtonUp(0) && rigid.velocity.y > 0) { rigid.velocity = rigid.velocity * 0.5f; }

    }

    private void CheatKey()
    {
        if (Input.GetKeyDown(KeyCode.F1)) { health = 1f; }
    }

    // 다른 오브젝트에 닿았을 때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 해당 오브젝트의 태그를 검색해서 "Platform" 값이 나오면
        if (collision.gameObject.tag == "Platform")
        {
            // 점프 횟수를 초기화 하고
            jump_cnt = 0;

            // 점프하고 있다는 신호를 끔
            is_jumping = false;
            anim.SetBool("is_jumping", false);
        }
    }
}

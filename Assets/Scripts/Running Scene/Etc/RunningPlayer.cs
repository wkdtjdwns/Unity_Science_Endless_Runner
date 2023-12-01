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
        // ���� �� �ʱ�ȭ
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
        // ü���� ���������� ü���� ��� ���̰�
        if (health > 0) { health -= Time.deltaTime; }

        // ������ ���ƴٴ� ��ȣ�� ��
        else { game_manager.is_tired = true; }
    }

    private void Jump()
    {
        // ��ư�� ������ �� ������ ���� ���� ���� ���¸鼭 �ɼ�â�� Ȱ��ȭ�Ǿ� ���� ������
        if (Input.GetMouseButtonDown(0) && jump_cnt < max_jump_cnt && !option.is_option)
        {
            SoundManager.instance.PlaySound("jump");

            // ���� Ƚ���� ������Ű��
            jump_cnt++;

            rigid.velocity = Vector2.zero;

            // ������Ű��
            rigid.AddForce(new Vector2(0, jump_power));

            // �����ϰ� �ִٴ� ��ȣ�� ��
            is_jumping = true;
            anim.SetBool("is_jumping", true);
        }

        else if (Input.GetMouseButtonUp(0) && rigid.velocity.y > 0) { rigid.velocity = rigid.velocity * 0.5f; }

    }

    private void CheatKey()
    {
        if (Input.GetKeyDown(KeyCode.F1)) { health = 1f; }
    }

    // �ٸ� ������Ʈ�� ����� ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ش� ������Ʈ�� �±׸� �˻��ؼ� "Platform" ���� ������
        if (collision.gameObject.tag == "Platform")
        {
            // ���� Ƚ���� �ʱ�ȭ �ϰ�
            jump_cnt = 0;

            // �����ϰ� �ִٴ� ��ȣ�� ��
            is_jumping = false;
            anim.SetBool("is_jumping", false);
        }
    }
}

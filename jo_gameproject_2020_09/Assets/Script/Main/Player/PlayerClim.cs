using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClim : MonoBehaviour
{
    private PlayerInput input;
    private PlayerStatas statas;
    private Rigidbody2D rb;

    private float climSpeed;
    private bool dashInput;
    // 梯子移動が許可された状態
    private bool climingIdle = false;

    // 掴まっている梯子
    private Ladder ladder;
    // 移動方向
    private Vector2 direction { get { return ladder?.LadderVect ?? Vector2.zero; } }


    private bool Is_Dash { get { return statas.is_Dash; } set { statas.is_Dash = value; } }

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        statas = GetComponent<PlayerStatas>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dashInput = input.DashKey;
        // 床に足がついていれば梯子状態ではない
        if (statas.is_Ground)
        {
            statas.is_Climbing = false;
        }
        // 梯子許可状態(梯子の近くかつジャンプしていない時)
        if (climingIdle && !statas.is_Jump && statas.is_Ground)
        {
            // 上下入力していれば梯子状態
            if (input.y_Axis < 0 && transform.position.y > ladder.sp.y)
            {
                statas.is_Climbing = true;
            }
            else if(input.y_Axis > 0 && transform.position.y < ladder.ep.y)
            {
                statas.is_Climbing = true;
            }
            else
            {

            }
        }
        if(statas.is_Climbing)
        {
            Climing();
        }
    }
    private void Climing()
    {
        float speed;
        if (dashInput && statas.Stamina > 0)
        {
            climSpeed = statas.ClimingDashSpeed;
            Is_Dash = true;
        }
        else
        {
            climSpeed = statas.ClimingSpeed;
            Is_Dash = false;
        }

        if (input.y_Axis > 0 && transform.position.y < ladder.ep.y)
        {
            speed = climSpeed;
        }
        else if (input.y_Axis < 0 && transform.position.y > ladder.sp.y)
        {
            speed = -climSpeed;
        }
        else
        {
            speed = 0;
            Is_Dash = false;
        }
        rb.velocity = direction * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            climingIdle = true;
            ladder = collision.transform.parent.GetComponent<Ladder>();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            climingIdle = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            climingIdle = false;
        }
    }
}

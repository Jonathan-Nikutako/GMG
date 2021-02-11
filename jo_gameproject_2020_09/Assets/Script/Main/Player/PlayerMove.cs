using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerStatas m_PlayerStatas;
    private PlayerInput input;
    private Rigidbody2D rb;

    // 実際に移動する速度
    private float moveSpeed;
    private bool dashInput;

    private bool Is_Dash { get { return m_PlayerStatas.is_Dash; } set { m_PlayerStatas.is_Dash = value; } }
    // Start is called before the first frame update
    void Start()
    {
        m_PlayerStatas = GetComponent<PlayerStatas>();
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = m_PlayerStatas.Speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dashInput = input.DashKey;
        // 地上のみ操作可能
        if (m_PlayerStatas.is_Ground)
        {
            Move();
        }
        // 足場に乗るための空中制御
        else if (!m_PlayerStatas.is_Climbing)
        {
            AirMove();
        }
    }
    private void Move()
    {
        float velcity_x;
        if (dashInput && m_PlayerStatas.Stamina > 0)
        {
            moveSpeed = m_PlayerStatas.DashSpeed;
            Is_Dash = true;
        }
        else
        {
            moveSpeed = m_PlayerStatas.Speed;
            Is_Dash = false;
        }

        if (input.x_Axis > 0)
        {
            velcity_x = 1;
        }
        else if(input.x_Axis < 0)
        {
            velcity_x = -1;
        }
        else 
        {
            velcity_x = 0;
            Is_Dash = false;
        }
        rb.velocity = new Vector2(velcity_x * moveSpeed, rb.velocity.y);
    }
    private void AirMove()
    {
        float velcity_x;

        if (input.x_Axis > 0)
        {
            velcity_x = 0.1f;
        }
        else if (input.x_Axis < 0)
        {
            velcity_x = -0.1f;
        }
        else
        {
            velcity_x = 0;
        }
        rb.velocity = new Vector2(rb.velocity.x + velcity_x, rb.velocity.y);
    }
}


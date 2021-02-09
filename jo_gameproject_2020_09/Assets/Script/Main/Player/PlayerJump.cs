using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerStatas m_statas;
    private PlayerInput input;
    private Rigidbody2D rb;
    private bool jumpKeyInput;
    private float jumpTimer = 0;

    private float jumpTime { get { return m_statas.JumpHeight / m_statas.JumpSpeed; } }

    private bool Is_Dash { get { return m_statas.is_Dash; } set { m_statas.is_Dash = value; } }
    private bool Is_Jump { get { return m_statas.is_Jump; } set { m_statas.is_Jump = value; } }

    void Start()
    {
        m_statas = GetComponent<PlayerStatas>();
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ジャンプするか
        jumpKeyInput = input.JumpKey;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // 地上にいるときジャンプをする
        if (m_statas.is_Ground && !Is_Jump)
        {
            if (jumpKeyInput)
            {
                Is_Jump = true;
            }
        }

        // ジャンプ中処理
        if (Is_Jump)
        {
            jumpTimer += Time.deltaTime;
            // 通常時
            // ジャンプ時間制限
            if (jumpTimer > jumpTime)
            {
                Is_Jump = false;
            }
            // 頭ぶつけた！
            if (m_statas.is_HitHead)
            {
                Is_Jump = false;
            }
            // 上昇速度0以下
            if (rb.velocity.y < 0 && !m_statas.is_Ground)
            {
                Is_Jump = false;
            }

            var y_velocity = m_statas.JumpSpeed;
            rb.velocity = new Vector2(rb.velocity.x, y_velocity);
        }
        else if (!m_statas.is_Ground)
        {
            var y_velocity = m_statas.JumpSpeed;
            rb.velocity = new Vector2(rb.velocity.x, -y_velocity);
            jumpTimer = 0;
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            jumpTimer = 0;
        }
    }
}

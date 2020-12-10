using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatas : MonoBehaviour
{
    [SerializeField, Tooltip("頭判定用空オブジェクト")]
    private GameObject headPoint = null;

    [SerializeField, Tooltip("地面判定用空オブジェクト")]
    private GameObject groundPoint = null;


    // アクション設定項目
    [SerializeField, Tooltip("通常移動速度")]
    private float speed;
    public float Speed { get { return speed; } }

    [SerializeField, Tooltip("ダッシュ移動速度")]
    private float dashSpeed;
    public float DashSpeed { get { return dashSpeed; } }

    [SerializeField, Tooltip("ジャンプ高度")]
    private float jumpHeight;
    public float JumpHeight { get { return jumpHeight; } }

    [SerializeField, Tooltip("ジャンプ速度")]
    private float jumpSpeed;
    public float JumpSpeed { get { return jumpSpeed; } }


    // ステータス設定項目
    [SerializeField, Range(0, 100), Tooltip("スタミナ")]
    private float stamina = 100;
    public float Stamina { get { return stamina; } set { stamina = Mathf.Clamp(value, 0, 100); } }

    [Range(0, 99), Tooltip("冷静")]
    public float calm = 99;
    public float Calm { get { return calm; } set { calm = Mathf.Clamp(value, 0, 99); } }

    [SerializeField, Tooltip("ダッシュ秒間スタミナ消費量")]
    private float dashStamina = 4;
    public float DashStamina { get { return dashStamina; } }

    [SerializeField, Tooltip("秒間スタミナ回復量")]
    private float generateStamina = 1;
    public float GenerateStamina { get { return generateStamina; } }

    [SerializeField, Tooltip("スタミナクールタイム")]
    private float staminaCoolTime = 3;
    public float StaminaCoolTime { get { return staminaCoolTime; } }


    // 状態

    [Tooltip("走っているか")]
    public bool is_Dash;

    [Tooltip("ジャンプしているか")]
    public bool is_Jump;

    // 接地しているか
    public bool is_Ground { get { return groundPoint.GetComponent<CheckGround>().is_Ground; } }

    // 頭をぶつけているか
    public bool is_HitHead { get { return headPoint.GetComponent<CheckGround>().is_Ground; } }

    public float staminaCoolTimer;
}

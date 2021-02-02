using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class Player : MonoBehaviour
{
    private PlayerStatas statas;
    // Start is called before the first frame update
    void Start()
    {
        statas = GetComponent<PlayerStatas>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // ゲージ管理
        // スタミナ
        // ダッシュ中
        if (statas.is_Dash)
        {
            statas.Stamina -= Time.deltaTime * statas.DashStamina;
            statas.staminaCoolTimer = statas.StaminaCoolTime;
        }
        else
        {
            statas.staminaCoolTimer -= Time.deltaTime;
            if (statas.staminaCoolTimer < 0)
            {
                statas.Stamina += Time.deltaTime * statas.GenerateStamina;
            }
        }
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 400, 100), "スタミナ :" + statas.Stamina.ToString());
        GUI.Label(new Rect(20, 40, 400, 100), "冷静 :" + statas.Calm.ToString());
    }
}

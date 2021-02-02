using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
/// <summary> フェードインフェードアウトをするようになる
/// </summary>
public class Fade : MonoBehaviour
{
    private enum InOut
    {
        FadeIn,
        fadeOut
    }
    private Image m_Image;
    private float timer;

    [SerializeField,Tooltip("終了時処理")]
    private UnityEvent endEvent;

    [SerializeField, Tooltip("フェード時間")]
    public float fadeTime = 1;
    [SerializeField, Tooltip("遷移方向")]
    private InOut inout;
    [SerializeField, Tooltip("フェードアウトする")]
    private bool FedeOut = false;
    [SerializeField, Tooltip("終了時消滅するか")]
    public bool EndDestroy;

    // Start is called before the first frame update
    void Start()
    {
        m_Image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < fadeTime)
        {
            FadeSprite(!Convert.ToBoolean(inout), timer / fadeTime);
        }
        else
        {
            if (EndDestroy)
            {
                Destroy(this.gameObject);
            }
            else {
                endEvent.Invoke();
            }
        }
    }
    /// <summary>フェード処理
    /// </summary>
    /// <param name="revers">Trueフェードイン,falseフェードアウト</param>
    /// <param name="radius">時間の割合</param>
    private void FadeSprite(bool revers, float radius)
    {
        float alpha;
        if (!revers)
        {
            alpha = radius;
        }
        else
        {
            alpha = 1f - radius;
        }
        Color color = m_Image.color;
        m_Image.color = new Color(color.r, color.g, color.b, alpha);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary> 時限式非アクティブ
/// </summary>
public class TimeDisable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Tooltip("生存時間")]
    private float LiveTime;

    private float defLiveTime;
    // Start is called before the first frame update
    void Start()
    {
        defLiveTime = LiveTime;
    }

    // Update is called once per frame
    void Update()
    {
        LiveTime -= Time.deltaTime;
        if (LiveTime < 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void SetLiveTime(float value)
    {
        LiveTime = value;
        defLiveTime = LiveTime;
    }
    private void OnDisable()
    {
        if (gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
        LiveTime = defLiveTime;
    }
}

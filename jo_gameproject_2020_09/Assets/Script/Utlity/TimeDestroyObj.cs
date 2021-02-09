using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary> 時限式死亡
/// </summary>
public class TimeDestroyObj : MonoBehaviour
{
    [SerializeField, Tooltip("生存時間")]
    private float LiveTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LiveTime -= Time.deltaTime;
        if (LiveTime < 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetLiveTime(float value)
    {
        LiveTime = value;
    }
}

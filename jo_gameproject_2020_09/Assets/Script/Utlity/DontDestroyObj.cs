using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> このスクリプトをつけると死ななくなる
/// </summary>
public class DontDestroyObj : MonoBehaviour
{
    [Tooltip("不可壊")]
    public bool DontDestroyEnabled = true;

    private static DontDestroyObj instance;

    // Use this for initialization
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

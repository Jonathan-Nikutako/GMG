﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTest : MonoBehaviour
{
    [SerializeField] MessageScript message;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            message.Message("test1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            message.Message("test2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            message.Message("test3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            message.Message("test4");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            message.Message("test5");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            message.Message("test6");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            message.Message("test7");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            message.Message("test8");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            message.Message("test9");
        }
    }
}

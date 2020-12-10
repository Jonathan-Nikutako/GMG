using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float x_Axis { private set; get; }
    public float y_Axis { private set; get; }

    public bool DashKey { private set; get; }

    public bool JumpKey { private set; get; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DashKey = Input.GetAxis("Dash") > 0;
        JumpKey = Input.GetAxisRaw("Jump") > 0;
    }
    private void FixedUpdate()
    {
        x_Axis = Input.GetAxis("Horizontal");
        y_Axis = Input.GetAxis("Vertical");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool is_Ground;

    [SerializeField, Header("すり抜け床を有効とするか")]
    private bool CheckPlatform;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            is_Ground = true;
        }
        else if (collision.CompareTag("GroundPlatform") && CheckPlatform)
        {
            is_Ground = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            is_Ground = true;
        }
        else if (collision.CompareTag("GroundPlatform") && CheckPlatform)
        {
            is_Ground = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            is_Ground = false;
        }
        else if (collision.CompareTag("GroundPlatform") && CheckPlatform)
        {
            is_Ground = false;
        }
    }
}

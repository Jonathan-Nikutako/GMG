using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool is_Ground;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        is_Ground = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        is_Ground = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        is_Ground = false;
    }
}

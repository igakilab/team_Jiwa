using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class searchPlayer : MonoBehaviour
{
    private bool isPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            isPlayer = false;
        }
    }

    public bool getIsPlayer()
    {
        return isPlayer;
    }
}

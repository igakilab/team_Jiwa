using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPlayer : MonoBehaviour
{
    private bool isPlayerInAttackRange;

    public void setIsPlayer(bool tf)
    {
        isPlayerInAttackRange = false;
    }

    public bool getisPlayer()
    {
        return isPlayerInAttackRange;
    }

    //ÉvÉåÉCÉÑÅ[Ç™ì¸Ç¡ÇΩÇÁ
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            isPlayerInAttackRange = true;
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInAttackRange = false;
        }
    }
}

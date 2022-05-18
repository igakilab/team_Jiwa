using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{

    private string groundTag = "ground";
    private bool isGround;

    Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    public bool getIsGround()
    {
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag==groundTag)
        {
            //Debug.Log("ê⁄ín");
            isGround = true;
            anim.SetBool("jump", false);
            anim.SetBool("fall", false);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            //Debug.Log("ó£ÇÍÇ‹ÇµÇΩ");
            isGround = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGround = true;

        }

    }
}

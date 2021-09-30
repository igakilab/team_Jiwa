using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : CharacterController
{
    // Start is called before the first frame update
    void Start()
    {
        //コンポーネント
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!anim.GetBool("death"))
        {
            move();

            Jump();

            attack();
        }

        death();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samurai : CharacterController
{

    protected override void attack()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
            move();

            Jump();

            attack();

    }

}

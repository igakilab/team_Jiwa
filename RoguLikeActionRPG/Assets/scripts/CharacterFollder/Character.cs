using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected Rigidbody2D rb2d = null;
    protected Animator anim = null;
    protected SpriteRenderer spRen;

    [SerializeField]private groundCheck ground;//接地確認クラス
    [SerializeField]private float jumpPower; //ジャンプ力

    //攻撃当たり判定
    protected Transform checkAttack;//攻撃判定オブジェクトのトランスフォーム
    protected float attackRadius=0.7f;//攻撃判定の半径

    protected void Jump()
    {
        if (ground.getIsGround())
        {
            rb2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
    }

    /*落下モーション*/
    private void fall()
    {
        float velY = rb2d.velocity.y;
        if (velY < 0.5f && !ground.getIsGround())
        {
            anim.SetBool("fall", true);
        }
    }

    protected abstract void death();

    protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        checkAttack = transform.Find("checkAttack").GetComponent<Transform>(); //攻撃判定オブジェクトを子オブジェクトより入手

    }

    protected virtual void Update()
    {
        fall();
    }

}

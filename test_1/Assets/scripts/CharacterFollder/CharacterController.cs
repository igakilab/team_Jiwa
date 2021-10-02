using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{

    protected Rigidbody2D rb2d = null;
    protected Animator anim = null;
    protected SpriteRenderer spRen;
    public groundCheck ground;

    public float jumpPower; //ジャンプ力
    public float speed; //移動スピード

    //攻撃当たり判定
    protected Transform checkAttack;
    protected float attackRadius = 0.7f;

    bool damage=false;//ダメージが与えられるか

    protected void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ground.getIsGround())
            {
                rb2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("jump", true);
            }

        }

        /*落下モーション*/
        float velY = rb2d.velocity.y;
        if (velY < 0.5f && !ground.getIsGround())
        {
            anim.SetBool("fall", true);
        }

    }

    protected void move()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        checkAttack = transform.Find("checkAttack").GetComponent<Transform>(); //攻撃判定オブジェクトを子オブジェクトより探す


        /*移動*/
        //右
        if (horizontalKey > 0)
        {
            spRen.flipX = false; //向き

            checkAttack.transform.localPosition = new Vector3(0.16f, 0, 0);           

            //ダッシュ
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("dash", true);
                xSpeed = speed * 1.2f;
            }
            //通常の走り
            else
            {
                anim.SetBool("run", true);
                xSpeed = speed;
            }
        }

        //左
        else if (horizontalKey < 0)
        {
            spRen.flipX = true;

            checkAttack.transform.localPosition = new Vector3(-0.16f, 0, 0);

            //ダッシュ
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("dash", true);
                xSpeed = -speed * 1.2f;
            }
            //通常の走り
            else
            {
                anim.SetBool("run", true);
                xSpeed = -speed;
            }
        }
        else
        {
            xSpeed = 0.0f;
            anim.SetBool("run", false);
            anim.SetBool("dash", false);
        }
        rb2d.velocity = new Vector2(xSpeed, rb2d.velocity.y);
    }

    protected abstract void attack();


    protected void death()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("death", true);
        }
    }

   protected virtual void Start()
    {
        //コンポーネント
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();
    }


}

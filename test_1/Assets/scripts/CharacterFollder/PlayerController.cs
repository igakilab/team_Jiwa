using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キャラクターの動きについてのスクリプト
public abstract class PlayerController : MonoBehaviour
{

    public PlayerStatus status; //ステータス

    // <コンポーネント>
    protected Rigidbody2D rb2d = null;
    protected Animator anim = null;
    protected SpriteRenderer spRen;
    public groundCheck ground;
    //</コンポーネント>


    public float jumpPower; //ジャンプ力
    public float speed; //移動スピード

    //攻撃当たり判定
    protected Transform checkAttack;
    protected float attackRadius = 0.7f;

    private void Jump()
    {
        if (ground.getIsGround())
        {
            rb2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
    }

    private void move()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;


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

    /*落下モーション*/
    private void fall()
    {
        float velY = rb2d.velocity.y;
        if (velY < 0.5f && !ground.getIsGround())
        {
            anim.SetBool("fall", true);
        }
    }

    protected abstract void attack();

    protected void death()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("death", true);
        }
    }

    public void onDamage(int enemyAtk)
    {
        int damage;//実際に与えるダメージ
        damage = enemyAtk - this.status.getDef(); //ダメージ=敵の攻撃力-自身の防御力
        if (damage < 0) damage = 0;//ダメージが負である場合は0ダメージ
        status.setHP(status.getHP() - damage); //残りの体力をHPにセット
    }

    protected void getItem()
    {

    }

   protected virtual void Start()
    {
        //コンポーネント
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();
        checkAttack = transform.Find("checkAttack").GetComponent<Transform>(); //攻撃判定オブジェクトを子オブジェクトより入手

        //ステータス処理
        status.setHP(status.getMaxHP());//HPを最大HPにする
    }

    protected virtual void Update()
    {
        if (!anim.GetBool("death"))
        {
            move();

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            
            fall();//落下モーション

            if (Input.GetKeyDown(KeyCode.V))
            {
                attack();

            }


        }

        death();
    }


}

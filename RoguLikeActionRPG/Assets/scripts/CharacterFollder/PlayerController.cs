using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キャラクターの動きについてのスクリプト
public abstract class PlayerController : MonoBehaviour
{

    

    // <コンポーネント>
    protected Rigidbody2D rb2d = null;
    protected Animator anim = null;
    protected SpriteRenderer spRen;
    public groundCheck ground;
    //</コンポーネント>

    //プレイヤー情報
    public PlayerStatusData status; //ステータス
    public float jumpPower; //ジャンプ力
    public float speed; //移動スピード
    protected Vector2 angle; //プレイヤーの向き

    //攻撃当たり判定
    protected Transform checkAttack;
    protected float attackRadius = 0.7f;

    //実装に必要な変数
    bool isOnce = false;//コルーチンを一度のみ呼び出す変数

    private void changeAngle(string angle) //引数-1 : 左, 1:   右
    {
        if (angle=="left")
        {
            this.angle = Vector2.left;
            spRen.flipX = true;
            checkAttack.transform.localPosition = new Vector3(-0.16f, 0, 0);
        }
        else if(angle=="right")
        {
            this.angle = Vector2.right;
            spRen.flipX = false; //向き
            checkAttack.transform.localPosition = new Vector3(0.16f, 0, 0);
        }

    }

    protected bool isControll()
    {
        if (!anim.GetBool("death") & GameManager.instance.isGame()) return true;
        return false;
    }

    private IEnumerator Condition()
    {
        //無敵時間
        if (status.isInvicible())
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            spRen.color = new Color(1f, 1f, 1f, level);

            //１回のみコルーチンを
            if (!isOnce)
            {
                isOnce = true;
                yield return new WaitForSeconds(3.0f);

                status.setInvicible(false);
                spRen.color = new Color(1f, 1f, 1f, 1f);
                isOnce = false;
            }
        }
    }


    private void init()
    {
        //ステータス処理
        status.initialize();
        status.setHP(status.getInitMaxHP());

        angle = Vector2.right;//スタート時点のプレイヤーの向き
    }

    // <PlayerMotion>
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
            changeAngle("right");

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

            changeAngle("left");

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
        if (status.getHP() < 0)
        {
            status.setHP(0);
            anim.SetBool("death", true);
            GameManager.instance.MessageLog.enqueueMessage("死んでしまった！");
        }
    }

    public void OnDamage(int enemyAtk)
    {
        //ダメージ計算
        int damage;//実際に与えるダメージ
        damage = enemyAtk - this.status.getDef(); //ダメージ=敵の攻撃力-自身の防御力
        if (damage < 0) damage = 0;//ダメージが負である場合は0ダメージ

        if (!(damage == 0))
        {
            //無敵時間以外のときに
            if (!status.isInvicible())
            {
                status.setHP(status.getHP() - damage);
                GameManager.instance.MessageLog.enqueueMessage(damage + "ダメージくらった");//メッセージログ

                status.setInvicible(true);//無敵時間ON

            }
        }
        else
        {
            GameManager.instance.MessageLog.enqueueMessage("ダメージを与えれなかった！");
        }
    }

    protected void getItem()
    {

    }
    // </PlayerMotion>




   protected virtual void Start()
    {
        //コンポーネント
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();
        checkAttack = transform.Find("checkAttack").GetComponent<Transform>(); //攻撃判定オブジェクトを子オブジェクトより入手

        init();//初期化


    }

    protected virtual void Update()
    {
        if (isControll())//プレイヤー操作条件
        {
            move();

            StartCoroutine(Condition());

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            
            fall();//落下モーション

            if (Input.GetKeyDown(KeyCode.V))
            {
                attack();

            }

            //レベルアップ必要経験値を所持経験値が超えたとき

            if (status.getExp()>=status.getNeedExp())
            {
                status.levelup();
                
            }



        }

        death();

        //テスト用コマンド
        if(Input.GetKeyDown(KeyCode.L))
        {
            status.levelup();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            status.showStatus();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            status.addExp(15);
        }
    }


}

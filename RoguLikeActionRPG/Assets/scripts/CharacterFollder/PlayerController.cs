using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

//キャラクターの動きについてのスクリプト
public abstract class PlayerController : Character
{

    // <コンポーネント>
    protected AudioSource audioSource;

    //</コンポーネント>

    //sound
    public AudioClip healSound;
    public AudioClip damageSound;
    public AudioClip attackSound;
    public AudioClip missAttackSound;
    public AudioClip levelUpSound;

    private GameObject levelUpText;

    //プレイヤー情報
    public PlayerStatusData playerStatusData; //初期ステータス
    public PlayerStatus status; //ステータス
    public float speed; //移動スピード
    protected Vector2 angle; //プレイヤーの向き

    //実装に必要な変数
    bool isOnce = false;//コルーチンを一度のみ呼び出す変数

    [System.NonSerialized]public bool isRecover;//回復できるかどうか

    //向きの変更
    private void changeAngle(string angle)
    {
        if (angle=="left")
        {
            this.angle = Vector2.left;
            spRen.flipX = true;
            checkAttack.transform.localPosition = new Vector3(-0.16f, 0, 0);//攻撃の当たり判定を左側に
        }
        else if(angle=="right")
        {
            this.angle = Vector2.right;
            spRen.flipX = false; //向き
            checkAttack.transform.localPosition = new Vector3(0.16f, 0, 0);//攻撃の当たり判定を右側に
        }

    }

    protected override void Jump()
    {
        if (ground.getIsGround())
        {
            rb2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
            audioSource.PlayOneShot(jumpSound);
        }
    }

    protected bool isControll()
    {
        if (!status.isDeath() && GameManager.instance.isGame()) return true;
        return false;
    }

    public bool getRecover()
    {
        return isRecover;
    }

    public void setRecover(bool tf)
    {
        this.isRecover = tf;
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
                yield return new WaitForSeconds(CO.PLAYER_INVICIBLE_TIME);

                status.setInvicible(false);
                spRen.color = new Color(1f, 1f, 1f, 1f);
                isOnce = false;
            }
        }
    }

    private void init()
    {
        angle = Vector2.right;//スタート時点のプレイヤーの向き
        isRecover = true;//回復ON
    }

    // <PlayerMotion>
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
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey("joystick button 8"))
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
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey("joystick button 8"))
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

    protected override void death()
    {
            status.setInvicible(false);//無敵状態を解除
            spRen.color = new Color(1f, 1f, 1f, 1f);//透明を消す
            status.setHP(0);//体力を0に
            anim.SetTrigger("death");
            status.setDeath(true);//ステータスのパラメータ状態をtrueに
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;//オブジェクトを固定
            rb2d.velocity = new Vector2(0, 0);//物体の移動速度を0に
            GameManager.instance.MessageLog.enqueueMessage("死んでしまった！");
    }

    public void OnDamage(int enemyAtk)
    {
        if(isControll())
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
                    audioSource.PlayOneShot(damageSound);

                    status.setInvicible(true);//無敵時間ON

                }
            }
            else GameManager.instance.MessageLog.enqueueMessage("ダメージをくらわなかった！");



        }

    }

    protected void getItem()
    {

    }
    // </PlayerMotion>

    private void recovery()
    {
        if(isRecover && !(status.getHP()==status.getMaxHP()))//
        {
            isRecover = false;
            audioSource.PlayOneShot(healSound);
            status.addHP((int)(status.getMaxHP() / 3));//回復

            //回復時、最大HPを越したら
            if (status.getHP() > status.getMaxHP())
                status.setHP(status.getMaxHP());
        }
    }

   protected override void Start()
    {
        base.Start();
        //コンポーネント
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        init();//初期化

        status = new PlayerStatus(playerStatusData);


    }

    protected override void Update()
    {
        if (isControll())//プレイヤー操作条件
        {
            base.Update();
            move();

            StartCoroutine(Condition());

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.V) || Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 2"))
            {
                attack();

            }

            //レベルアップ必要経験値を所持経験値が超えたとき

            if (status.getExp()>=status.getNeedExp())
            {
                audioSource.PlayOneShot(levelUpSound);
                status.levelup();
                
            }

        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        
        if(status.getHP()<=0 && !status.isDeath())   death();

        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown("joystick button 1")) recovery(); //回復

        if(Input.GetKeyDown(KeyCode.I))
        {
            OnDamage(20);
        }


    }


}

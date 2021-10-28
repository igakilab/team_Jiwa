using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class Enemy : Character
{
    //固定ステータス
    protected EnemyStatusData enemyStatus;

    //動的ステータス
    protected int hp; //敵の現在のHP

    // <UI>
    Slider HPvar; /*体力バー*/
    Text NameText;
    Text damageText;　//ダメージの表示
    // </UI>

    //コンポーネント
    Rigidbody2D rb2d;
    SpriteRenderer spRen;
    searchPlayer searchPlayer;
    Animator anim;

    GameObject monsteObject;

    //攻撃当たり判定
    protected Transform checkAttack;//攻撃判定オブジェクトのトランスフォーム
    public float attackRadius;//攻撃判定の半径

    private bool moveEnebled;//動けるか
    private bool isAttack;//攻撃できるか
    private bool isOnce = false;

    private bool attackDelay;

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(checkAttack.position, attackRadius); 
    }
     */


    //攻撃予備動作に入る
    private IEnumerator Attack()
    {

        if (!isOnce)
        {
            attackDelay = true;
            Debug.Log("攻撃予備動作に入ります");
            isOnce = true;
            yield return new WaitForSeconds(CO.ATTACK_DELAY_TIME);//予備動作の秒数
            Debug.Log("攻撃!!");

            anim.SetBool("attack", true);
            attackCollisionDetection();//攻撃
            attackDelay = false;
            spRen.color = new Color(1f, 1f, 1f, 1f);//点滅をとめる
            yield return new WaitForSeconds(0.5f);//攻撃後の硬直
            
            isOnce = false;
            moveEnebled = true;//動けるようにする

        }
        
    }



    //攻撃の判定
    public void attackCollisionDetection()
    {

        Collider2D hitPlayer = Physics2D.OverlapCircle(checkAttack.position, attackRadius, LayerMask.GetMask("Player"));//攻撃当たり判定内の敵オブジェクトを入手
        if(hitPlayer!=null)
        {
            int addDamage; //敵に与える攻撃力 ※実際にダメージを与える数値は敵の防御力の差分
            addDamage = (int)(enemyStatus.getInitAtk() * Random.Range(0.8f, 1.2f));
            hitPlayer.gameObject.GetComponent<Warrior>().OnDamage(addDamage); //ダメージを与える
        }


    }



    private void EnemyUICtrl()
    {
        HPvar.value = (float)this.hp / (float)enemyStatus.getInitMaxHP(); //HPバーの更新
        NameText.text = enemyStatus.getName();//名前

    }

    private void changeAngle(string angle)
    {
        if (angle == "left")
        {
            spRen.flipX = true;
            checkAttack.transform.localPosition = new Vector3(-1, 0, 0);//攻撃の当たり判定を右側に
        }
        else if (angle == "right")
        {
            spRen.flipX = false; //向き
            checkAttack.transform.localPosition = new Vector3(1, 0, 0);//攻撃の当たり判定を左側に
        }

    }

    private void chasePlayer()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        float speedx=0;
        Vector3 destination = Player.transform.position; //敵の目的地
        Vector3 direction = (destination - transform.position).normalized; //プレイヤーの方向

        //Debug.Log(string.Format("方向{0:#}",direction.x));
        // Debug.Log(string.Format("{0:#},{1:#},{2:#}",Player.transform.position.x, Player.transform.position.y, Player.transform.position.z));

        if (direction.x>0)//プレイヤーの方向が自分から右側
        {
            changeAngle("right");//敵の向き変更
            speedx = enemyStatus.getSpeed();
        }
        else if(direction.x<0)//プレイヤーの方向が自分から左側
        {
            changeAngle("left");
            speedx = -enemyStatus.getSpeed();
        }

        anim.SetBool("walk", true);//歩くアニメーション
        rb2d.velocity = new Vector2(speedx, rb2d.velocity.y);
    }

    public void onDamage(int enemyAtk)
    {
        int damage;//実際に与えるダメージ
        damage = enemyAtk - this.enemyStatus.getInitDef(); //ダメージ=敵の攻撃力-自身の防御力
        if (damage < 0) damage = 0;//ダメージが負である場合は0ダメージ
        this.hp=this.hp - damage; //残りの体力をHPにセット

        //log
        GameManager.instance.MessageLog.enqueueMessage(enemyStatus.getName() + "に" + damage + "ダメージ与えた！");

    }

    protected virtual void death()
    {
        hp=0;
        //アニメーション、挙動;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Warrior>().status.addExp(enemyStatus.getExp());//ウォーリアーのみ経験値を与える;
        GameManager.instance.addKillEnemy();
        //log
        GameManager.instance.MessageLog.enqueueMessage(enemyStatus.getName() + "を倒した！");
        GameManager.instance.MessageLog.enqueueMessage(enemyStatus.getExp() + "の経験値を入手した!");

        Destroy(this.gameObject);
    }

    protected virtual void Start()
    {
        monsteObject = transform.Find("MonsterObject").gameObject;//モンスターオブジェクト入手

        hp = enemyStatus.getInitMaxHP();
        HPvar = transform.Find("Canvas/HPBar").gameObject.GetComponent<Slider>();
        NameText = transform.Find("Canvas/Name").gameObject.GetComponent<Text>();
        searchPlayer = transform.Find("SearchArea").gameObject.GetComponent<searchPlayer>();
        rb2d = GetComponent<Rigidbody2D>();
        spRen = monsteObject.GetComponent<SpriteRenderer>();
        anim = monsteObject.GetComponent<Animator>();

        moveEnebled = true;
        attackDelay = false;
        checkAttack = transform.Find("checkAttack").GetComponent<Transform>();//当たり判定オブジェクト子オブジェクトより入手
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        EnemyUICtrl();

        if (hp <= 0)
        {
            death();

        }

        //感知範囲内
        if(searchPlayer.getIsPlayer()&&moveEnebled)
        {
            chasePlayer();
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            anim.SetBool("walk", false);
        }

        //攻撃範囲内にプレイヤーが入ったら
        if(checkAttack.gameObject.GetComponent<isPlayer>().getisPlayer())
        {
            moveEnebled = false;//止める
            StartCoroutine(Attack());//攻撃の開始
            
        }
        
        //攻撃予備動作中
        if(attackDelay)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            spRen.color = new Color(1f, 1f, 1f, level);
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<Warrior>().OnDamage(enemyStatus.getInitAtk());

        }
    }


}

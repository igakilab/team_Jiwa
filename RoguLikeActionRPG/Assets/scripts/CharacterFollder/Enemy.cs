using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class Enemy : Character
{
    //固定ステータス
    protected EnemyStatusData enemyStatusData;//初期ステータス
    public EnemyStatus status;

    // <UI>
    Slider HPvar; /*体力バー*/
    Text NameText;
    Text damageText;　//ダメージの表示
    // </UI>

    //コンポーネント
    searchPlayer searchPlayer;
    

    GameObject monsteObject;

    private bool moveEnebled;//動けるか
    private bool isAttack;//攻撃できるか
    private bool isOnce = false;

    private bool attackDelay;//攻撃予備動作中か

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
            addDamage = (int)Mathf.Ceil(status.getAtk() * Random.Range(0.8f, 1.2f));
            hitPlayer.gameObject.GetComponent<PlayerController>().OnDamage(addDamage); //ダメージを与える
        }


    }



    private void EnemyUICtrl()
    {
        HPvar.value = (float)status.getHP() / (float)status.getMaxHP(); //HPバーの更新
        NameText.text = enemyStatusData.getName();//名前

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
            speedx = enemyStatusData.getSpeed();
        }
        else if(direction.x<0)//プレイヤーの方向が自分から左側
        {
            changeAngle("left");
            speedx = -enemyStatusData.getSpeed();
        }

        anim.SetBool("walk", true);//歩くアニメーション
        rb2d.velocity = new Vector2(speedx, rb2d.velocity.y);
    }

    public void onDamage(int enemyAtk)
    {
        int damage;//実際に与えるダメージ
        damage = enemyAtk - this.status.getDef(); //ダメージ=敵の攻撃力-自身の防御力
        if (damage < 0) damage = 0;//ダメージが負である場合は0ダメージ
        this.status.setHP(status.getHP()-damage); //残りの体力をHPにセット

        //log
        GameManager.instance.MessageLog.enqueueMessage(enemyStatusData.getName() + "に" + damage + "ダメージ与えた！");

    }

    protected override void death()
    {
        status.setHP(0);
        //アニメーション、挙動;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().status.addExp(enemyStatusData.getExp());//ウォーリアーのみ経験値を与える;
        GameManager.instance.addKillEnemy();
        GameManager.instance.score += enemyStatusData.getPoint();
        //log
        GameManager.instance.MessageLog.enqueueMessage(enemyStatusData.getName() + "を倒した！");
        GameManager.instance.MessageLog.enqueueMessage(enemyStatusData.getExp() + "の経験値を入手した!");

        Destroy(this.gameObject);
    }

    protected override void Start()
    {
        base.Start();
        monsteObject = transform.Find("MonsterObject").gameObject;//モンスターオブジェクト入手

        HPvar = transform.Find("Canvas/HPBar").gameObject.GetComponent<Slider>();
        NameText = transform.Find("Canvas/Name").gameObject.GetComponent<Text>();
        searchPlayer = transform.Find("SearchArea").gameObject.GetComponent<searchPlayer>();

        spRen = monsteObject.GetComponent<SpriteRenderer>();
        anim = monsteObject.GetComponent<Animator>();

        status = new EnemyStatus(enemyStatusData);

        moveEnebled = true;
        attackDelay = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        int jumpNum = Random.Range(1, 11);

   
        EnemyUICtrl();

        if (status.getHP() <= 0)
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


}

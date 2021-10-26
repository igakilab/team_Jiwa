using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

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

    Rigidbody2D rb2d;
    SpriteRenderer spRen;
    searchPlayer searchPlayer;
 

    private void EnemyUICtrl()
    {
        HPvar.value = (float)this.hp / (float)enemyStatus.getInitMaxHP(); //HPバーの更新
        NameText.text = enemyStatus.getName();//名前

    }

    private void chasePlayer()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        float speedx=0;
        Vector3 destination = Player.transform.position; //敵の目的地
        Vector3 direction = (destination - transform.position).normalized; //プレイヤーの方向

        //Debug.Log(string.Format("方向{0:#}",direction.x));
        // Debug.Log(string.Format("{0:#},{1:#},{2:#}",Player.transform.position.x, Player.transform.position.y, Player.transform.position.z));

        if (direction.x>0)
        {
            spRen.flipX = false;
            speedx = enemyStatus.getSpeed();
        }
        else if(direction.x<0)
        {
            spRen.flipX = true;
            speedx = -enemyStatus.getSpeed();
        }

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

    public void death()
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
        hp = enemyStatus.getInitMaxHP();
        HPvar = transform.Find("Canvas/HPBar").gameObject.GetComponent<Slider>();
        NameText = transform.Find("Canvas/Name").gameObject.GetComponent<Text>();
        searchPlayer = transform.Find("SearchArea").gameObject.GetComponent<searchPlayer>();
        rb2d = GetComponent<Rigidbody2D>();
        spRen = transform.Find("MonsterObject").gameObject.GetComponent<SpriteRenderer>();
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
        if(searchPlayer.getIsPlayer())
        {
            chasePlayer();
        }
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Warrior>().OnDamage(enemyStatus.getInitAtk());

        }
    }


}

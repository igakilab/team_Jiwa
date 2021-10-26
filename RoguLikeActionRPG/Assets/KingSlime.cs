using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlime : Enemy
{
    // Start is called before the first frame update

    private const int SPAWN_SLIME = 4;

    protected override void death()
    {
        hp = 0;
        //アニメーション、挙動;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Warrior>().status.addExp(enemyStatus.getExp());//ウォーリアーのみ経験値を与える;
        GameManager.instance.addKillEnemy();

        //分裂
        GameObject Slime= (GameObject)Resources.Load("Prefab/Enemy/suraimu");
        float localX = this.transform.localPosition.x; //キングスライムのローカル座標

         for(int i=0;i<SPAWN_SLIME;i++)
        {
            Instantiate(Slime, new Vector2(localX + i -1, 0), Quaternion.identity).transform.parent = GameObject.Find("Enemys").transform;
        }

        //log
        GameManager.instance.MessageLog.enqueueMessage(enemyStatus.getName() + "を倒した！");
        GameManager.instance.MessageLog.enqueueMessage(enemyStatus.getExp() + "の経験値を入手した!");
        GameManager.instance.MessageLog.enqueueMessage("なんとキングスライムは分裂してしまった！！");


        Destroy(this.gameObject);

        
    }
    protected override void Start()
    {
        enemyStatus = Resources.Load<EnemyStatusData>("StatusData/Enemy/KingSlime");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}

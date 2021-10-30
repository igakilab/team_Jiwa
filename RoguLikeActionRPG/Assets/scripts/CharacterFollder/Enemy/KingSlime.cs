using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class KingSlime : Enemy
{
    // Start is called before the first frame update

    private const int SPAWN_SLIME = 4;

    protected override void death()
    {
        status.setHP(0);
        //アニメーション、挙動;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().status.addExp(enemyStatusData.getExp());//ウォーリアーのみ経験値を与える;
        GameManager.instance.addKillEnemy();

        //分裂
        GameObject Slime= (GameObject)Resources.Load(CO.ENEMY_PREFAB_PATH+"suraimu");
        float localX = this.transform.localPosition.x; //キングスライムのローカル座標

         for(int i=0;i<CO.SPAWN_SLIME;i++)
        {
            Instantiate(Slime, new Vector2(localX + i -1, 0), Quaternion.identity).transform.parent = GameObject.Find("Enemys").transform;
        }

        //log
        GameManager.instance.MessageLog.enqueueMessage(enemyStatusData.getName() + "を倒した！");
        GameManager.instance.MessageLog.enqueueMessage(enemyStatusData.getExp() + "の経験値を入手した!");
        GameManager.instance.MessageLog.enqueueMessage("なんとキングスライムは分裂してしまった！！");


        Destroy(this.gameObject);

        
    }
    protected override void Start()
    {
        enemyStatusData = Resources.Load<EnemyStatusData>(CO.ENEMY_STATUS_PATH+"KingSlime");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}

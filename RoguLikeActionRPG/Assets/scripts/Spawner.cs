using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class Spawner : MonoBehaviour
{
    private int EnemyNum;//シーン内の敵の数
    private GameObject Enemys;//敵の親オブジェクト

    private const int MAX_ENEMY_NUM= 4;
    private const int spawnTime = 2;//スポーン時間

    bool spawnEnabled;//スポーンできるか

    //次にスポーンができるまでの時間
    private IEnumerator spawnDelay(int spawnTime)
    {
        spawnEnabled = false;

        yield return new WaitForSeconds(spawnTime);

        spawnEnabled = true;
    }


    private void spawnEnemy()
    {
        GameObject Enemy;//スポーンする敵
        float SpawnX; //スポーンする座標
        int num;

        SpawnX = Random.Range(-10f, 10f);//スポーンする座標を指定した範囲内でランダムで入手

        num = Random.Range(1, 100);

        if (num <= 45)
        {
            Enemy = (GameObject)Resources.Load(CO.ENEMY_PREFAB_PATH+"suraimu");//スポーン対象のプレハブを読み込む
        }
        else if (num <= 90)
        {
            Enemy = (GameObject)Resources.Load(CO.ENEMY_PREFAB_PATH + "goburin");//スポーン対象のプレハブを読み込む
        }
        else
        {
            Enemy = (GameObject)Resources.Load(CO.ENEMY_PREFAB_PATH + "gaikotu");//スポーン対象のプレハブを読み込む
        }

        Instantiate(Enemy, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//Enemysの子オブジェクトにプレハブを生成
    }

    private void spawnEnemy(int SpawnEnemyNum)
    {
        for(int i=0;i<SpawnEnemyNum;i++)
        {
            spawnEnemy();
        }
    }

    private void spawnBoss()
    {
        GameObject Enemy=null;//スポーンする敵
        float SpawnX; //スポーンする座標
        int num = Random.Range(1, 3);

        SpawnX = Random.Range(-10f, 10f);//スポーンする座標を指定した範囲内でランダムで入手

        switch (num)
        {
            case 1:
                Enemy = (GameObject)Resources.Load(CO.BOSS_PREFAB_PATH+"KingGoburin");
                break;
            case 2:
                Enemy = (GameObject)Resources.Load(CO.BOSS_PREFAB_PATH+"KingSlime");
                break;
        }

        

        Instantiate(Enemy, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//Enemysの子オブジェクトにプレハブを生成

    }


    // Start is called before the first frame update
    void Start()
    {
        Enemys=new GameObject("Enemys");//敵を格納する親オブジェクトの作成
        spawnEnabled=true;

        spawnEnemy(CO.MAX_ENEMY_NUM);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyNum = Enemys.transform.childCount;//敵の数を数える

        if(EnemyNum<CO.MAX_ENEMY_NUM && spawnEnabled)
        {
            spawnEnemy();
            StartCoroutine(spawnDelay(CO.SPAWN_TIME));
        }
        if (GameManager.instance.GetKillEnemy() % CO.BOSS_APPEARANCE_CON == 0 && !(GameManager.instance.GetKillEnemy() == 0))
        {
            if (GameObject.FindGameObjectWithTag("Boss") == null) spawnBoss();//ボスがいなかったらスポーン 
        }
    }
}

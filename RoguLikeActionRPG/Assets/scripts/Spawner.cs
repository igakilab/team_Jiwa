using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int EnemyNum;//シーン内の敵の数
    private GameObject Enemys;//敵の親オブジェクト


    private void spawnEnemy()
    {
        GameObject Enemy;//スポーンする敵
        float SpawnX; //スポーンする座標
        int num;

        SpawnX = Random.Range(-10f, 10f);//スポーンする座標を指定した範囲内でランダムで入手

        num = Random.Range(1, 100);

        if (num <= 45)
        {
            Enemy = (GameObject)Resources.Load("Prefab/Enemy/suraimu");//スポーン対象のプレハブを読み込む
        }
        else if (num <= 90)
        {
            Enemy = (GameObject)Resources.Load("Prefab/Enemy/goburin");//スポーン対象のプレハブを読み込む
        }
        else
        {
            Enemy = (GameObject)Resources.Load("Prefab/Enemy/gaikotu");//スポーン対象のプレハブを読み込む
        }

        Instantiate(Enemy, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//Enemysの子オブジェクトにプレハブを生成
    }

    private void spawnBoss()
    {
        GameObject Enemy;//スポーンする敵
        float SpawnX; //スポーンする座標

        SpawnX = Random.Range(-10f, 10f);//スポーンする座標を指定した範囲内でランダムで入手

        Enemy = (GameObject)Resources.Load("Prefab/Enemy/KingGoburin");

        Instantiate(Enemy, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//Enemysの子オブジェクトにプレハブを生成
    }


    // Start is called before the first frame update
    void Start()
    {
        Enemys = GameObject.Find("Enemys");//敵が出現する親オブジェクトを探す
    }

    // Update is called once per frame
    void Update()
    {
        EnemyNum = Enemys.transform.childCount;//敵の数を数える

        if(EnemyNum<4)
        {
            spawnEnemy();
        }
        if (GameManager.instance.GetKillEnemy() % 10 == 0 && !(GameManager.instance.GetKillEnemy() == 0))
        {
            if (GameObject.FindGameObjectWithTag("Boss") == null) spawnBoss();
        }
    }
}

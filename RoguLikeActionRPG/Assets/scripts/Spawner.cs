using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int EnemyNum;//�V�[�����̓G�̐�
    private GameObject Enemys;//�G�̐e�I�u�W�F�N�g


    private void spawnEnemy()
    {
        GameObject Enemy;//�X�|�[������G
        float SpawnX; //�X�|�[��������W
        int num;

        SpawnX = Random.Range(-10f, 10f);//�X�|�[��������W���w�肵���͈͓��Ń����_���œ���

        num = Random.Range(1, 100);

        if (num <= 45)
        {
            Enemy = (GameObject)Resources.Load("Prefab/Enemy/suraimu");//�X�|�[���Ώۂ̃v���n�u��ǂݍ���
        }
        else if (num <= 90)
        {
            Enemy = (GameObject)Resources.Load("Prefab/Enemy/goburin");//�X�|�[���Ώۂ̃v���n�u��ǂݍ���
        }
        else
        {
            Enemy = (GameObject)Resources.Load("Prefab/Enemy/gaikotu");//�X�|�[���Ώۂ̃v���n�u��ǂݍ���
        }

        Instantiate(Enemy, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//Enemys�̎q�I�u�W�F�N�g�Ƀv���n�u�𐶐�
    }

    private void spawnBoss()
    {
        GameObject Enemy;//�X�|�[������G
        float SpawnX; //�X�|�[��������W

        SpawnX = Random.Range(-10f, 10f);//�X�|�[��������W���w�肵���͈͓��Ń����_���œ���

        Enemy = (GameObject)Resources.Load("Prefab/Enemy/KingGoburin");

        Instantiate(Enemy, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//Enemys�̎q�I�u�W�F�N�g�Ƀv���n�u�𐶐�
    }


    // Start is called before the first frame update
    void Start()
    {
        Enemys = GameObject.Find("Enemys");//�G���o������e�I�u�W�F�N�g��T��
    }

    // Update is called once per frame
    void Update()
    {
        EnemyNum = Enemys.transform.childCount;//�G�̐��𐔂���

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

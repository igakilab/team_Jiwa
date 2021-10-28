using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class Spawner : MonoBehaviour
{
    private int EnemyNum;//�V�[�����̓G�̐�
    private GameObject Enemys;//�G�̐e�I�u�W�F�N�g

    private const int MAX_ENEMY_NUM= 4;
    private const int spawnTime = 2;//�X�|�[������

    bool spawnEnabled;//�X�|�[���ł��邩

    //���ɃX�|�[�����ł���܂ł̎���
    private IEnumerator spawnDelay(int spawnTime)
    {
        spawnEnabled = false;

        yield return new WaitForSeconds(spawnTime);

        spawnEnabled = true;
    }


    private void spawnEnemy()
    {
        GameObject Enemy;//�X�|�[������G
        float SpawnX; //�X�|�[��������W
        int num;

        SpawnX = Random.Range(-10f, 10f);//�X�|�[��������W���w�肵���͈͓��Ń����_���œ���

        num = Random.Range(1, 100);

        if (num <= 30)
        {
            Enemy = (GameObject)Resources.Load(CO.ENEMY_PREFAB_PATH+"suraimu");//�X�|�[���Ώۂ̃v���n�u��ǂݍ���
        }
        else if (num <= 60)
        {
            Enemy = (GameObject)Resources.Load(CO.ENEMY_PREFAB_PATH + "goburin");//�X�|�[���Ώۂ̃v���n�u��ǂݍ���
        }
        else if(num<=90)
        {
            Enemy = (GameObject)Resources.Load(CO.ENEMY_PREFAB_PATH + "Mushroom");//�X�|�[���Ώۂ̃v���n�u��ǂݍ���
        }
        else
        {
            Enemy = (GameObject)Resources.Load(CO.ENEMY_PREFAB_PATH + "gaikotu");//�X�|�[���Ώۂ̃v���n�u��ǂݍ���
        }

        Instantiate(Enemy, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//Enemys�̎q�I�u�W�F�N�g�Ƀv���n�u�𐶐�
    }

    private void spawnEnemy(int SpawnEnemyNum)
    {
        for(int i=0;i<SpawnEnemyNum;i++)
        {
            spawnEnemy();
        }
    }

    //�w�肵�������X�^�[�������_���̍��W�ŃX�|�[��
    private void spawnEnemy(GameObject spawnObject)
    {
        float SpawnX = Random.Range(-10f, 10f);//�X�|�[��������W���w�肵���͈͓��Ń����_���œ�
        Instantiate(spawnObject, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//�X�|�[���Ώۂ̃v���n�u�𐶐�
    }

    //�����X�^�[�ƍ��W���w�肵�ăX�|�[��
    private void spawnEnemy(GameObject spawnObject,Vector3 point)
    {
        Instantiate(spawnObject, point, Quaternion.identity).transform.parent = Enemys.transform;
    }


    private void spawnBoss()
    {
        GameObject Boss=null;//�X�|�[������G
        float SpawnX; //�X�|�[��������W
        int num = Random.Range(1, 4);

        SpawnX = Random.Range(-10f, 10f);//�X�|�[��������W���w�肵���͈͓��Ń����_���œ���

        switch (num)
        {
            case 1:
                Boss = (GameObject)Resources.Load(CO.BOSS_PREFAB_PATH+"KingGoburin"); 
                break;
            case 2:
                Boss = (GameObject)Resources.Load(CO.BOSS_PREFAB_PATH+"KingSlime");
                break;
            case 3:
                Boss = (GameObject)Resources.Load(CO.BOSS_PREFAB_PATH + "EvliWizard");
                break;
        }

        

        Instantiate(Boss, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//Enemys�̎q�I�u�W�F�N�g�Ƀv���n�u�𐶐�

    }


    // Start is called before the first frame update
    void Start()
    {
        Enemys=new GameObject("Enemys");//�G���i�[����e�I�u�W�F�N�g�̍쐬
        spawnEnabled=true;

        spawnEnemy(CO.MAX_ENEMY_NUM);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyNum = Enemys.transform.childCount;//�G�̐��𐔂���

        if(EnemyNum<CO.MAX_ENEMY_NUM && spawnEnabled)
        {
            spawnEnemy();
            StartCoroutine(spawnDelay(CO.SPAWN_TIME));
        }
        if (GameManager.instance.GetKillEnemy() % CO.BOSS_APPEARANCE_CON == 0 && !(GameManager.instance.GetKillEnemy() == 0))
        {
            if (GameObject.FindGameObjectWithTag("Boss") == null) spawnBoss();//�{�X�����Ȃ�������X�|�[�� 
        }
    }
}

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
        //�A�j���[�V�����A����;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Warrior>().status.addExp(enemyStatus.getExp());//�E�H�[���A�[�̂݌o���l��^����;
        GameManager.instance.addKillEnemy();

        //����
        GameObject Slime= (GameObject)Resources.Load("Prefab/Enemy/suraimu");
        float localX = this.transform.localPosition.x; //�L���O�X���C���̃��[�J�����W

         for(int i=0;i<SPAWN_SLIME;i++)
        {
            Instantiate(Slime, new Vector2(localX + i -1, 0), Quaternion.identity).transform.parent = GameObject.Find("Enemys").transform;
        }

        //log
        GameManager.instance.MessageLog.enqueueMessage(enemyStatus.getName() + "��|�����I");
        GameManager.instance.MessageLog.enqueueMessage(enemyStatus.getExp() + "�̌o���l����肵��!");
        GameManager.instance.MessageLog.enqueueMessage("�Ȃ�ƃL���O�X���C���͕��􂵂Ă��܂����I�I");


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

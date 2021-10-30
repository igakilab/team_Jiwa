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
        //�A�j���[�V�����A����;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().status.addExp(enemyStatusData.getExp());//�E�H�[���A�[�̂݌o���l��^����;
        GameManager.instance.addKillEnemy();

        //����
        GameObject Slime= (GameObject)Resources.Load(CO.ENEMY_PREFAB_PATH+"suraimu");
        float localX = this.transform.localPosition.x; //�L���O�X���C���̃��[�J�����W

         for(int i=0;i<CO.SPAWN_SLIME;i++)
        {
            Instantiate(Slime, new Vector2(localX + i -1, 0), Quaternion.identity).transform.parent = GameObject.Find("Enemys").transform;
        }

        //log
        GameManager.instance.MessageLog.enqueueMessage(enemyStatusData.getName() + "��|�����I");
        GameManager.instance.MessageLog.enqueueMessage(enemyStatusData.getExp() + "�̌o���l����肵��!");
        GameManager.instance.MessageLog.enqueueMessage("�Ȃ�ƃL���O�X���C���͕��􂵂Ă��܂����I�I");


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

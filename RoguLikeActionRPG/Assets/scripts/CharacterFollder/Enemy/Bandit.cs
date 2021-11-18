using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class Bandit : Enemy
{
    protected override void changeAngle(string angle)
    {
        if (angle == "left")
        {
            spRen.flipX = false;
            checkAttack.transform.localPosition = EnemyAttackPosition_Left;//UŒ‚‚Ì“–‚½‚è”»’è‚ğ‰E‘¤‚É
        }
        else if (angle == "right")
        {
            spRen.flipX = true; //Œü‚«
            checkAttack.transform.localPosition = EnemyAttackPosition_Right;//UŒ‚‚Ì“–‚½‚è”»’è‚ğ¶‘¤‚É
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        EnemyAttackPosition_Right = new Vector3(0.6f, 0, 0);
        EnemyAttackPosition_Left = new Vector3(-0.4f, 0, 0);
        enemyStatusData = Resources.Load<EnemyStatusData>(CO.ENEMY_STATUS_PATH + "Bandit");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}

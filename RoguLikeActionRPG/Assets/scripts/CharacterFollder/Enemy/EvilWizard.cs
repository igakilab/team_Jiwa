using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class EvilWizard : Enemy
{

    // Start is called before the first frame update
    protected override void Start()
    {
        EnemyAttackPosition_Right = new Vector3(1, -0.63f, 0);
        EnemyAttackPosition_Left = new Vector3(-1, -0.63f, 0);
        enemyStatusData = Resources.Load<EnemyStatusData>(CO.ENEMY_STATUS_PATH + "EvilWizard");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}

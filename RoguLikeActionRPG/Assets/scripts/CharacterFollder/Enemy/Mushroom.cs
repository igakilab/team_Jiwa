using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class Mushroom : Enemy
{
    protected override void Start()
    {
        EnemyAttackPosition_Right = new Vector3(1, 0, 0);
        EnemyAttackPosition_Left = new Vector3(-0.1f, 0, 0);
        enemyStatusData = Resources.Load<EnemyStatusData>(CO.ENEMY_STATUS_PATH + "mushroom");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}

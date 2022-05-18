using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class Samurai : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        EnemyAttackPosition_Right = new Vector3(2f, -0.8f, 0);
        EnemyAttackPosition_Left = new Vector3(-2f, -0.8f, 0);
        enemyStatusData = Resources.Load<EnemyStatusData>(CO.ENEMY_STATUS_PATH + "samurai");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}

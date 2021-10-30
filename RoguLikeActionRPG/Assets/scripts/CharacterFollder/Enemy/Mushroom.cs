using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class Mushroom : Enemy
{
    protected override void Start()
    {
        enemyStatusData = Resources.Load<EnemyStatusData>(CO.ENEMY_STATUS_PATH + "mushroom");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}

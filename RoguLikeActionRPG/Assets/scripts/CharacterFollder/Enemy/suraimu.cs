using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;
public class suraimu : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        enemyStatus = Resources.Load<EnemyStatusData>(CO.ENEMY_STATUS_PATH + "suraimu");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}

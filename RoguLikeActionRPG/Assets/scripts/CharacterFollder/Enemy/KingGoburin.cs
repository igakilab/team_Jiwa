using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingGoburin : Enemy
{
    protected override void Start()
    {
        enemyStatus = Resources.Load<EnemyStatusData>("StatusData/Enemy/KingGoburin");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}

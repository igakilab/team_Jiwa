using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goburin : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        enemyStatus = Resources.Load<EnemyStatusData>("StatusData/Enemy/goburin");
        hp = enemyStatus.getInitMaxHP();
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}

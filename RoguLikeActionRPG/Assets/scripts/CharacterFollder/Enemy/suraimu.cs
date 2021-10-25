using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suraimu : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        enemyStatus = Resources.Load<EnemyStatusData>("StatusData/Enemy/suraimu");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}

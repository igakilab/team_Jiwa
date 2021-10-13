using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerController
{

    protected override void attack()
    {
        //ジャンプ以外
        if (!anim.GetBool("jump"))
        {
            anim.SetBool("attack", true); //アタックアニメーション


            Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(checkAttack.position, attackRadius, LayerMask.GetMask("Enemy"));

            //攻撃iが当たった全ての敵に対して
            foreach (Collider2D hitEnemy in hitEnemys)
            {
                hitEnemy.gameObject.GetComponent<Enemy>().onDamage(status.getAtk()); //ダメージを与える

            }


        }

    }

    private void testDamage()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            onDamage(10);
        }
    }
    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start(); //親のStartを実行

    }

    // Update is called once per frame
    protected override void Update()
    {

        base.Update();

        testDamage();
    }
}

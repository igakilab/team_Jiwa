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
            messageLog.enqueueMessage("攻撃！");
            anim.SetBool("attack", true); //アタックアニメーション
        }

    }

    //攻撃アニメーション時に呼び出される
    public void attackCollisionDetection()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(checkAttack.position, attackRadius, LayerMask.GetMask("Enemy"));

        //攻撃iが当たった全ての敵に対して
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            int addDamage;
            addDamage = status.getAtk();
            hitEnemy.gameObject.GetComponent<Enemy>().onDamage(addDamage); //ダメージを与える

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : CharacterController
{
    //攻撃当たり判定
    private Transform checkAttack;
    private float attackRadius = 0.7f;

    protected override void attack()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            //ジャンプ以外
            if (!anim.GetBool("jump"))
            {
                anim.SetBool("attack", true); //アタックアニメーション


                checkAttack = transform.Find("checkAttack").GetComponent<Transform>(); //攻撃判定オブジェクトを子オブジェクトより探す
                Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(checkAttack.position, attackRadius, LayerMask.GetMask("Enemy"));

                //攻撃iが当たった全ての敵に対して
                foreach (Collider2D hitEnemy in hitEnemys)
                {
                    hitEnemy.gameObject.GetComponent<Enemy>().onDamage(1); //ダメージを与える

                }


            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start(); //親のStartを実行

    }

    // Update is called once per frame
    void Update()
    {

        if (!anim.GetBool("death"))
        {
            move();

            Jump();

            attack();
        }

        death();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerController
{
    public AudioClip CriticalAttackSound;
    protected override void attack()
    {
        //ジャンプ以外
        if (!anim.GetBool("jump"))
        {
            
            anim.SetBool("attack", true); //アタックアニメーション
        }

    }

    //攻撃アニメーション時に呼び出される
    public void attackCollisionDetection()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(checkAttack.position, attackRadius, LayerMask.GetMask("Enemy"));//攻撃当たり判定内の敵オブジェクトを入手

        if (hitEnemys.Length == 0)
        {
            audioSource.PlayOneShot(missAttackSound);
        }
        else
        {
            //攻撃iが当たった全ての敵に対して
            foreach (Collider2D hitEnemy in hitEnemys)
            {
                int addDamage; //敵に与える攻撃力 ※実際にダメージを与える数値は敵の防御力の差分
                bool critical=false;
                addDamage = (int)(status.getAtk() * Random.Range(0.8f, 1.2f));
                if (Random.Range(1, 34) == 1)
                {
                    addDamage = addDamage * 2;//クリティカルヒット;
                    critical = true;
                }
                    
                hitEnemy.gameObject.GetComponent<Enemy>().onDamage(addDamage); //ダメージを与える
                hitEnemy.gameObject.GetComponent<Rigidbody2D>().AddForce(angle * 3f, ForceMode2D.Impulse);//ノックバック
                if (critical) audioSource.PlayOneShot(CriticalAttackSound);
                else audioSource.PlayOneShot(attackSound);

            }
        }



    }

    private void testDamage()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            OnDamage(60);
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

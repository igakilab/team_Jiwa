using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerController
{

    protected override void attack()
    {
        //�W�����v�ȊO
        if (!anim.GetBool("jump"))
        {
            anim.SetBool("attack", true); //�A�^�b�N�A�j���[�V����


            Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(checkAttack.position, attackRadius, LayerMask.GetMask("Enemy"));

            //�U��i�����������S�Ă̓G�ɑ΂���
            foreach (Collider2D hitEnemy in hitEnemys)
            {
                hitEnemy.gameObject.GetComponent<Enemy>().onDamage(status.getAtk()); //�_���[�W��^����

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
        base.Start(); //�e��Start�����s

    }

    // Update is called once per frame
    protected override void Update()
    {

        base.Update();

        testDamage();
    }
}

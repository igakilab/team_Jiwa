using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : CharacterController
{
    //�U�������蔻��
    private Transform checkAttack;
    private float attackRadius = 0.7f;

    protected override void attack()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            //�W�����v�ȊO
            if (!anim.GetBool("jump"))
            {
                anim.SetBool("attack", true); //�A�^�b�N�A�j���[�V����


                checkAttack = transform.Find("checkAttack").GetComponent<Transform>(); //�U������I�u�W�F�N�g���q�I�u�W�F�N�g���T��
                Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(checkAttack.position, attackRadius, LayerMask.GetMask("Enemy"));

                //�U��i�����������S�Ă̓G�ɑ΂���
                foreach (Collider2D hitEnemy in hitEnemys)
                {
                    hitEnemy.gameObject.GetComponent<Enemy>().onDamage(1); //�_���[�W��^����

                }


            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start(); //�e��Start�����s

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

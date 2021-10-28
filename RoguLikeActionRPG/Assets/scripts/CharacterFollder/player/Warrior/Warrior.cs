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
        }

    }

    //�U���A�j���[�V�������ɌĂяo�����
    public void attackCollisionDetection()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(checkAttack.position, attackRadius, LayerMask.GetMask("Enemy"));//�U�������蔻����̓G�I�u�W�F�N�g�����

        //�U��i�����������S�Ă̓G�ɑ΂���
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            int addDamage; //�G�ɗ^����U���� �����ۂɃ_���[�W��^���鐔�l�͓G�̖h��͂̍���
            addDamage = (int)(status.getAtk() * Random.Range(0.8f, 1.2f));
            hitEnemy.gameObject.GetComponent<Enemy>().onDamage(addDamage); //�_���[�W��^����
            hitEnemy.gameObject.GetComponent<Rigidbody2D>().AddForce(angle * 3f,ForceMode2D.Impulse);//�m�b�N�o�b�N

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
        base.Start(); //�e��Start�����s

    }

    // Update is called once per frame
    protected override void Update()
    {

        base.Update();

        testDamage();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Enemy enemy; //�G�l�~�[�X�N���v�g
    private float attackRadius;
    private Transform checkAttack;
    private EnemyStatus status;
    public void attackCollisionDetection()
    {
        attackRadius = enemy.getAttackRadius();

        Collider2D hitPlayer = Physics2D.OverlapCircle(checkAttack.position, attackRadius, LayerMask.GetMask("Player"));//�U�������蔻����̓G�I�u�W�F�N�g�����
        if (hitPlayer != null)
        {
            int addDamage; //�G�ɗ^����U���� �����ۂɃ_���[�W��^���鐔�l�͓G�̖h��͂̍���
            addDamage = (int)Mathf.Ceil(status.getAtk() * Random.Range(0.8f, 1.2f));
            hitPlayer.gameObject.GetComponent<PlayerController>().OnDamage(addDamage); //�_���[�W��^����
        }


    }

    public void Start()
    {
        enemy = transform.parent.gameObject.GetComponent<Enemy>();
        
        
    }

    public void Update()
    {
        checkAttack = enemy.getCheckAttack();
        status = enemy.status;

    }
}

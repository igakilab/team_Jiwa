using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Enemy enemy; //エネミースクリプト
    private float attackRadius;
    private Transform checkAttack;
    private EnemyStatus status;
    public void attackCollisionDetection()
    {
        attackRadius = enemy.getAttackRadius();

        Collider2D hitPlayer = Physics2D.OverlapCircle(checkAttack.position, attackRadius, LayerMask.GetMask("Player"));//攻撃当たり判定内の敵オブジェクトを入手
        if (hitPlayer != null)
        {
            int addDamage; //敵に与える攻撃力 ※実際にダメージを与える数値は敵の防御力の差分
            addDamage = (int)Mathf.Ceil(status.getAtk() * Random.Range(0.8f, 1.2f));
            hitPlayer.gameObject.GetComponent<PlayerController>().OnDamage(addDamage); //ダメージを与える
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

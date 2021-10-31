using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Enemy enemy;
    private float attackRadius;
    private Transform checkAttack;
    private EnemyStatus status;
    public void attackCollisionDetection()
    {

        Collider2D hitPlayer = Physics2D.OverlapCircle(checkAttack.position, attackRadius, LayerMask.GetMask("Player"));//UŒ‚“–‚½‚è”»’è“à‚Ì“GƒIƒuƒWƒFƒNƒg‚ğ“üè
        if (hitPlayer != null)
        {
            int addDamage; //“G‚É—^‚¦‚éUŒ‚—Í ¦ÀÛ‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é”’l‚Í“G‚Ì–hŒä—Í‚Ì·•ª
            addDamage = (int)Mathf.Ceil(status.getAtk() * Random.Range(0.8f, 1.2f));
            hitPlayer.gameObject.GetComponent<PlayerController>().OnDamage(addDamage); //ƒ_ƒ[ƒW‚ğ—^‚¦‚é
        }


    }

    public void Start()
    {
        enemy = transform.parent.gameObject.GetComponent<Enemy>();
        attackRadius = enemy.getAttackRadius();
        checkAttack = enemy.getCheckAttack();
        status = enemy.status;
    }
}

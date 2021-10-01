using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : Character
{
    // Start is called before the first frame update
    public EnemyStatusData enemyStatus;

    Slider HPvar; /*体力バー*/
    Text NameText;

    private NavMeshAgent agent;


    public override void attack()
    {
        Debug.Log("攻撃");
    }
 

    private void UICtrl()
    {
        HPvar.value = (float)hp / (float)enemyStatus.getMaxHP();
        NameText.text = enemyStatus.getName();

    }

    private void moveToPlayer()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");

        if(target)
        {
            agent.destination = target.transform.position;
        }


    }

    void Start()
    {
        hp = enemyStatus.getMaxHP();/*hpにmaxHPを代入*/
        agent = GetComponent<NavMeshAgent>();

        

        HPvar = transform.Find("Canvas/HPBar").gameObject.GetComponent<Slider>();
        NameText = transform.Find("Canvas/Name").gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();

        death();
    }
}

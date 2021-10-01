using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : Character
{
    // Start is called before the first frame update
    public EnemyStatusData enemyStatus;

    Slider HPvar; /*�̗̓o�[*/
    Text NameText;


    public override void attack()
    {
        Debug.Log("�U��");
    }
 

    private void UICtrl()
    {
        HPvar.value = (float)hp / (float)enemyStatus.getMaxHP();
        NameText.text = enemyStatus.getName();

    }

    private void moveToPlayer()
    {

    }

    void Start()
    {
        hp = enemyStatus.getMaxHP();/*hp��maxHP����*/
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

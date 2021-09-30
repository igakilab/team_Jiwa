using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Enemy : Character
{
    // Start is called before the first frame update
    public EnemyStatusData enemyStatus;

    Slider HPvar; /*体力バー*/
    Text NameText;


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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 PlayerPostion;
        Vector3 EnemyPostion;

        PlayerPostion = player.transform.position;
        EnemyPostion = this.transform.position;

        
    }

    void Start()
    {
        hp = enemyStatus.getMaxHP();/*hpにmaxHPを代入*/

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

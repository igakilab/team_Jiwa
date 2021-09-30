using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Enemy : Character
{
    // Start is called before the first frame update
    public EnemyStatusData enemyStatus;

    Slider HPvar; /*ëÃóÕÉoÅ[*/
    Text NameText;


    public override void attack()
    {
        Debug.Log("çUåÇ");
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
        hp = enemyStatus.getMaxHP();/*hpÇ…maxHPÇë„ì¸*/

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

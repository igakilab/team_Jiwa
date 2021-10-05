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

    Rigidbody2D rb2d;


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
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        float speed=0;
        Vector3 destination = Player.transform.position; //�G�̖ړI�n
        Vector3 direction = (destination - transform.position).normalized; //�v���C���[�̕���

        Debug.Log(string.Format("����{0:#}",direction.x));
        // Debug.Log(string.Format("{0:#},{1:#},{2:#}",Player.transform.position.x, Player.transform.position.y, Player.transform.position.z));

        if (direction.x>0)
        {
            speed = 7f;
        }
        else if(direction.x<0)
        {
            speed = -7f;
        }



        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }

    void Start()
    {
        hp = enemyStatus.getMaxHP();/*hp��maxHP����*/
        HPvar = transform.Find("Canvas/HPBar").gameObject.GetComponent<Slider>();
        NameText = transform.Find("Canvas/Name").gameObject.GetComponent<Text>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();

        death();

        moveToPlayer();
    }
}

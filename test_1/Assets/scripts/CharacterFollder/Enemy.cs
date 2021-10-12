using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : Character
{
    
    public EnemyStatusData enemyStatus;//�X�e�[�^�X

    // <UI>
    Slider HPvar; /*�̗̓o�[*/
    Text NameText;
    Text damageText;�@//�_���[�W�̕\��
    // </UI>

    Rigidbody2D rb2d;
    searchPlayer searchPlayer;
 

    private void UICtrl()
    {
        HPvar.value = (float)enemyStatus.getHP() / (float)enemyStatus.getMaxHP(); //HP�o�[�̍X�V
        NameText.text = enemyStatus.getName();//���O

    }


    private void chasePlayer()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        float speedx=0;
        Vector3 destination = Player.transform.position; //�G�̖ړI�n
        Vector3 direction = (destination - transform.position).normalized; //�v���C���[�̕���

        //Debug.Log(string.Format("����{0:#}",direction.x));
        // Debug.Log(string.Format("{0:#},{1:#},{2:#}",Player.transform.position.x, Player.transform.position.y, Player.transform.position.z));

        if (direction.x>0)
        {
            speedx = enemyStatus.getSpeed();
        }
        else if(direction.x<0)
        {
            speedx = -enemyStatus.getSpeed();
        }

        rb2d.velocity = new Vector2(speedx, rb2d.velocity.y);
    }

    public void onDamage(int enemyAtk)
    {
        int damage;//���ۂɗ^����_���[�W
        damage = enemyAtk - this.enemyStatus.getDef(); //�_���[�W=�G�̍U����-���g�̖h���
        if (damage < 0) damage = 0;//�_���[�W�����ł���ꍇ��0�_���[�W
        enemyStatus.setHP(enemyStatus.getHP() - damage); //�c��̗̑͂�HP�ɃZ�b�g

        Debug.Log(damage + "�_���[�W�^����");
    }

    public void death()
    {
        if (enemyStatus.getHP() <= 0)
        {
            enemyStatus.setHP(0);

            /*
             �A�j���[�V�����A����;
             */

            Destroy(this.gameObject);
        }
    }

    void Start()
    {

        enemyStatus.setHP(enemyStatus.getMaxHP());

        HPvar = transform.Find("Canvas/HPBar").gameObject.GetComponent<Slider>();
        NameText = transform.Find("Canvas/Name").gameObject.GetComponent<Text>();
        searchPlayer = transform.Find("SearchArea").gameObject.GetComponent<searchPlayer>();
        damageText = transform.Find("Canvas/damageText").gameObject.GetComponent<Text>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();

        death();

        //���m�͈͓�
        if(searchPlayer.getIsPlayer())
        {
            chasePlayer();
        }
        
    }


}

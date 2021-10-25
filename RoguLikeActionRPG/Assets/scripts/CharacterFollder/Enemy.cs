using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : Character
{
    //�Œ�X�e�[�^�X
    protected EnemyStatusData enemyStatus;

    //���I�X�e�[�^�X
    protected int hp; //�G�̌��݂�HP

    // <UI>
    Slider HPvar; /*�̗̓o�[*/
    Text NameText;
    Text damageText;�@//�_���[�W�̕\��
    // </UI>

    Rigidbody2D rb2d;
    searchPlayer searchPlayer;
 

    private void EnemyUICtrl()
    {
        HPvar.value = (float)this.hp / (float)enemyStatus.getInitMaxHP(); //HP�o�[�̍X�V
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
        damage = enemyAtk - this.enemyStatus.getInitDef(); //�_���[�W=�G�̍U����-���g�̖h���
        if (damage < 0) damage = 0;//�_���[�W�����ł���ꍇ��0�_���[�W
        this.hp=this.hp - damage; //�c��̗̑͂�HP�ɃZ�b�g

        //log
        GameManager.instance.MessageLog.enqueueMessage(enemyStatus.getName() + "��" + damage + "�_���[�W�^�����I");

    }

    public void death()
    {
        hp=0;
        //�A�j���[�V�����A����;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Warrior>().status.addExp(enemyStatus.getExp());//�E�H�[���A�[�̂݌o���l��^����;
        //log
        GameManager.instance.MessageLog.enqueueMessage(enemyStatus.getName() + "��|�����I");
        GameManager.instance.MessageLog.enqueueMessage(enemyStatus.getExp() + "�̌o���l����肵��!");

        Destroy(this.gameObject);
    }

    protected virtual void Start()
    {
        hp = enemyStatus.getInitMaxHP();
        HPvar = transform.Find("Canvas/HPBar").gameObject.GetComponent<Slider>();
        NameText = transform.Find("Canvas/Name").gameObject.GetComponent<Text>();
        searchPlayer = transform.Find("SearchArea").gameObject.GetComponent<searchPlayer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        EnemyUICtrl();

        if (hp <= 0)
        {
            death();

        }

        //���m�͈͓�
        if(searchPlayer.getIsPlayer())
        {
            chasePlayer();
        }
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Warrior>().OnDamage(enemyStatus.getInitAtk());

        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class Enemy : Character
{
    //�Œ�X�e�[�^�X
    protected EnemyStatusData enemyStatusData;//�����X�e�[�^�X
    public EnemyStatus status;

    // <UI>
    Slider HPvar; /*�̗̓o�[*/
    Text NameText;
    Text damageText;�@//�_���[�W�̕\��
    // </UI>

    //�R���|�[�l���g
    searchPlayer searchPlayer;
    

    GameObject monsteObject;

    private bool moveEnebled;//�����邩
    private bool isAttack;//�U���ł��邩
    private bool isOnce = false;

    private bool attackDelay;//�U���\�����쒆��

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(checkAttack.position, attackRadius); 
    }
     */


    //�U���\������ɓ���
    private IEnumerator Attack()
    {

        if (!isOnce)
        {
            attackDelay = true;
            Debug.Log("�U���\������ɓ���܂�");
            isOnce = true;
            yield return new WaitForSeconds(CO.ATTACK_DELAY_TIME);//�\������̕b��
            Debug.Log("�U��!!");

            anim.SetBool("attack", true);
            attackCollisionDetection();//�U��
            attackDelay = false;
            spRen.color = new Color(1f, 1f, 1f, 1f);//�_�ł��Ƃ߂�
            yield return new WaitForSeconds(0.5f);//�U����̍d��
            
            isOnce = false;
            moveEnebled = true;//������悤�ɂ���

        }
        
    }
    //�U���̔���
    public void attackCollisionDetection()
    {

        Collider2D hitPlayer = Physics2D.OverlapCircle(checkAttack.position, attackRadius, LayerMask.GetMask("Player"));//�U�������蔻����̓G�I�u�W�F�N�g�����
        if(hitPlayer!=null)
        {
            int addDamage; //�G�ɗ^����U���� �����ۂɃ_���[�W��^���鐔�l�͓G�̖h��͂̍���
            addDamage = (int)Mathf.Ceil(status.getAtk() * Random.Range(0.8f, 1.2f));
            hitPlayer.gameObject.GetComponent<PlayerController>().OnDamage(addDamage); //�_���[�W��^����
        }


    }



    private void EnemyUICtrl()
    {
        HPvar.value = (float)status.getHP() / (float)status.getMaxHP(); //HP�o�[�̍X�V
        NameText.text = enemyStatusData.getName();//���O

    }

    private void changeAngle(string angle)
    {
        if (angle == "left")
        {
            spRen.flipX = true;
            checkAttack.transform.localPosition = new Vector3(-1, 0, 0);//�U���̓����蔻����E����
        }
        else if (angle == "right")
        {
            spRen.flipX = false; //����
            checkAttack.transform.localPosition = new Vector3(1, 0, 0);//�U���̓����蔻���������
        }

    }

    private void chasePlayer()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        float speedx=0;
        Vector3 destination = Player.transform.position; //�G�̖ړI�n
        Vector3 direction = (destination - transform.position).normalized; //�v���C���[�̕���

        //Debug.Log(string.Format("����{0:#}",direction.x));
        // Debug.Log(string.Format("{0:#},{1:#},{2:#}",Player.transform.position.x, Player.transform.position.y, Player.transform.position.z));

        if (direction.x>0)//�v���C���[�̕�������������E��
        {
            changeAngle("right");//�G�̌����ύX
            speedx = enemyStatusData.getSpeed();
        }
        else if(direction.x<0)//�v���C���[�̕������������獶��
        {
            changeAngle("left");
            speedx = -enemyStatusData.getSpeed();
        }

        anim.SetBool("walk", true);//�����A�j���[�V����
        rb2d.velocity = new Vector2(speedx, rb2d.velocity.y);
    }

    public void onDamage(int enemyAtk)
    {
        int damage;//���ۂɗ^����_���[�W
        damage = enemyAtk - this.status.getDef(); //�_���[�W=�G�̍U����-���g�̖h���
        if (damage < 0) damage = 0;//�_���[�W�����ł���ꍇ��0�_���[�W
        this.status.setHP(status.getHP()-damage); //�c��̗̑͂�HP�ɃZ�b�g

        //log
        GameManager.instance.MessageLog.enqueueMessage(enemyStatusData.getName() + "��" + damage + "�_���[�W�^�����I");

    }

    protected override void death()
    {
        status.setHP(0);
        //�A�j���[�V�����A����;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().status.addExp(enemyStatusData.getExp());//�E�H�[���A�[�̂݌o���l��^����;
        GameManager.instance.addKillEnemy();
        GameManager.instance.score += enemyStatusData.getPoint();
        //log
        GameManager.instance.MessageLog.enqueueMessage(enemyStatusData.getName() + "��|�����I");
        GameManager.instance.MessageLog.enqueueMessage(enemyStatusData.getExp() + "�̌o���l����肵��!");

        Destroy(this.gameObject);
    }

    protected override void Start()
    {
        base.Start();
        monsteObject = transform.Find("MonsterObject").gameObject;//�����X�^�[�I�u�W�F�N�g����

        HPvar = transform.Find("Canvas/HPBar").gameObject.GetComponent<Slider>();
        NameText = transform.Find("Canvas/Name").gameObject.GetComponent<Text>();
        searchPlayer = transform.Find("SearchArea").gameObject.GetComponent<searchPlayer>();

        spRen = monsteObject.GetComponent<SpriteRenderer>();
        anim = monsteObject.GetComponent<Animator>();

        status = new EnemyStatus(enemyStatusData);

        moveEnebled = true;
        attackDelay = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        int jumpNum = Random.Range(1, 11);

   
        EnemyUICtrl();

        if (status.getHP() <= 0)
        {
            death();

        }

        //���m�͈͓�
        if(searchPlayer.getIsPlayer()&&moveEnebled)
        {
            chasePlayer();
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            anim.SetBool("walk", false);
        }

        //�U���͈͓��Ƀv���C���[����������
        if(checkAttack.gameObject.GetComponent<isPlayer>().getisPlayer())
        {
            moveEnebled = false;//�~�߂�
            StartCoroutine(Attack());//�U���̊J�n
            
        }
        
        //�U���\�����쒆
        if(attackDelay)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            spRen.color = new Color(1f, 1f, 1f, level);
        }
    }


}

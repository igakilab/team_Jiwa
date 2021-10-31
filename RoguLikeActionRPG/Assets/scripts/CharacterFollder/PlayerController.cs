using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

//�L�����N�^�[�̓����ɂ��ẴX�N���v�g
public abstract class PlayerController : Character
{

    // <�R���|�[�l���g>
    
    
    //</�R���|�[�l���g>

    //�v���C���[���
    public PlayerStatusData playerStatusData; //�����X�e�[�^�X
    public PlayerStatus status; //�X�e�[�^�X
    public float speed; //�ړ��X�s�[�h
    protected Vector2 angle; //�v���C���[�̌���

    //�����ɕK�v�ȕϐ�
    bool isOnce = false;//�R���[�`������x�̂݌Ăяo���ϐ�

    //�����̕ύX
    private void changeAngle(string angle)
    {
        if (angle=="left")
        {
            this.angle = Vector2.left;
            spRen.flipX = true;
            checkAttack.transform.localPosition = new Vector3(-0.16f, 0, 0);//�U���̓����蔻���������
        }
        else if(angle=="right")
        {
            this.angle = Vector2.right;
            spRen.flipX = false; //����
            checkAttack.transform.localPosition = new Vector3(0.16f, 0, 0);//�U���̓����蔻����E����
        }

    }

    protected bool isControll()
    {
        if (!status.isDeath() && GameManager.instance.isGame()) return true;
        return false;
    }

    private IEnumerator Condition()
    {
        //���G����
        if (status.isInvicible())
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            spRen.color = new Color(1f, 1f, 1f, level);

            //�P��̂݃R���[�`����
            if (!isOnce)
            {
                isOnce = true;
                yield return new WaitForSeconds(CO.PLAYER_INVICIBLE_TIME);

                status.setInvicible(false);
                spRen.color = new Color(1f, 1f, 1f, 1f);
                isOnce = false;
            }
        }
    }

    private void init()
    {
        angle = Vector2.right;//�X�^�[�g���_�̃v���C���[�̌���
    }

    // <PlayerMotion>
    private void move()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;


        /*�ړ�*/
        //�E
        if (horizontalKey > 0)
        {
            changeAngle("right");

            //�_�b�V��
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("dash", true);
                xSpeed = speed * 1.2f;
            }
            //�ʏ�̑���
            else
            {
                anim.SetBool("run", true);
                xSpeed = speed;
            }
        }
        //��
        else if (horizontalKey < 0)
        {

            changeAngle("left");

            //�_�b�V��
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("dash", true);
                xSpeed = -speed * 1.2f;
            }
            //�ʏ�̑���
            else
            {
                anim.SetBool("run", true);
                xSpeed = -speed;
            }
        }
        else
        {
            xSpeed = 0.0f;
            anim.SetBool("run", false);
            anim.SetBool("dash", false);
        }
        rb2d.velocity = new Vector2(xSpeed, rb2d.velocity.y);
    }



    protected abstract void attack();

    protected override void death()
    {
            status.setInvicible(false);//���G��Ԃ�����
            spRen.color = new Color(1f, 1f, 1f, 1f);//����������
            status.setHP(0);//�̗͂�0��
            anim.SetTrigger("death");
            status.setDeath(true);//�X�e�[�^�X�̃p�����[�^��Ԃ�true��
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;//�I�u�W�F�N�g���Œ�
            rb2d.velocity = new Vector2(0, 0);//���̂̈ړ����x��0��
            GameManager.instance.MessageLog.enqueueMessage("����ł��܂����I");
    }

    public void OnDamage(int enemyAtk)
    {
        if(isControll())
        {
            //�_���[�W�v�Z
            int damage;//���ۂɗ^����_���[�W
            damage = enemyAtk - this.status.getDef(); //�_���[�W=�G�̍U����-���g�̖h���
            if (damage < 0) damage = 0;//�_���[�W�����ł���ꍇ��0�_���[�W

            if (!(damage == 0))
            {
                //���G���ԈȊO�̂Ƃ���
                if (!status.isInvicible())
                {
                    status.setHP(status.getHP() - damage);
                    GameManager.instance.MessageLog.enqueueMessage(damage + "�_���[�W�������");//���b�Z�[�W���O

                    status.setInvicible(true);//���G����ON

                }
            }
            else GameManager.instance.MessageLog.enqueueMessage("�_���[�W�������Ȃ������I");



        }

    }

    protected void getItem()
    {

    }
    // </PlayerMotion>

   protected override void Start()
    {
        base.Start();
        //�R���|�[�l���g
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();
        init();//������

        status = new PlayerStatus(playerStatusData);


    }

    protected override void Update()
    {
        if (isControll())//�v���C���[�������
        {
            base.Update();
            move();

            StartCoroutine(Condition());

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.V) || Input.GetMouseButtonDown(0))
            {
                attack();

            }

            //���x���A�b�v�K�v�o���l�������o���l���������Ƃ�

            if (status.getExp()>=status.getNeedExp())
            {
                status.levelup();
                
            }

        }

        
        if(status.getHP()<=0 && !status.isDeath())   death();

        if(Input.GetKeyDown(KeyCode.I))
        {
            OnDamage(0);
        }


    }


}

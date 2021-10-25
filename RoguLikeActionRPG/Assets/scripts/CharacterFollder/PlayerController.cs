using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�L�����N�^�[�̓����ɂ��ẴX�N���v�g
public abstract class PlayerController : MonoBehaviour
{

    

    // <�R���|�[�l���g>
    protected Rigidbody2D rb2d = null;
    protected Animator anim = null;
    protected SpriteRenderer spRen;
    public groundCheck ground;
    //</�R���|�[�l���g>

    //�v���C���[���
    public PlayerStatusData status; //�X�e�[�^�X
    public float jumpPower; //�W�����v��
    public float speed; //�ړ��X�s�[�h
    protected Vector2 angle; //�v���C���[�̌���

    //�U�������蔻��
    protected Transform checkAttack;
    protected float attackRadius = 0.7f;

    //�����ɕK�v�ȕϐ�
    bool isOnce = false;//�R���[�`������x�̂݌Ăяo���ϐ�

    private void changeAngle(string angle) //����-1 : ��, 1:   �E
    {
        if (angle=="left")
        {
            this.angle = Vector2.left;
            spRen.flipX = true;
            checkAttack.transform.localPosition = new Vector3(-0.16f, 0, 0);
        }
        else if(angle=="right")
        {
            this.angle = Vector2.right;
            spRen.flipX = false; //����
            checkAttack.transform.localPosition = new Vector3(0.16f, 0, 0);
        }

    }

    protected bool isControll()
    {
        if (!anim.GetBool("death") & GameManager.instance.isGame()) return true;
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
                yield return new WaitForSeconds(3.0f);

                status.setInvicible(false);
                spRen.color = new Color(1f, 1f, 1f, 1f);
                isOnce = false;
            }
        }
    }


    private void init()
    {
        //�X�e�[�^�X����
        status.initialize();
        status.setHP(status.getInitMaxHP());

        angle = Vector2.right;//�X�^�[�g���_�̃v���C���[�̌���
    }

    // <PlayerMotion>
    private void Jump()
    {
        if (ground.getIsGround())
        {
            rb2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
    }

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

    /*�������[�V����*/
    private void fall()
    {
        float velY = rb2d.velocity.y;
        if (velY < 0.5f && !ground.getIsGround())
        {
            anim.SetBool("fall", true);
        }
    }

    protected abstract void attack();

    protected void death()
    {
        if (status.getHP() < 0)
        {
            status.setHP(0);
            anim.SetBool("death", true);
            GameManager.instance.MessageLog.enqueueMessage("����ł��܂����I");
        }
    }

    public void OnDamage(int enemyAtk)
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
        else
        {
            GameManager.instance.MessageLog.enqueueMessage("�_���[�W��^����Ȃ������I");
        }
    }

    protected void getItem()
    {

    }
    // </PlayerMotion>




   protected virtual void Start()
    {
        //�R���|�[�l���g
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();
        checkAttack = transform.Find("checkAttack").GetComponent<Transform>(); //�U������I�u�W�F�N�g���q�I�u�W�F�N�g������

        init();//������


    }

    protected virtual void Update()
    {
        if (isControll())//�v���C���[�������
        {
            move();

            StartCoroutine(Condition());

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            
            fall();//�������[�V����

            if (Input.GetKeyDown(KeyCode.V))
            {
                attack();

            }

            //���x���A�b�v�K�v�o���l�������o���l���������Ƃ�

            if (status.getExp()>=status.getNeedExp())
            {
                status.levelup();
                
            }



        }

        death();

        //�e�X�g�p�R�}���h
        if(Input.GetKeyDown(KeyCode.L))
        {
            status.levelup();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            status.showStatus();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            status.addExp(15);
        }
    }


}

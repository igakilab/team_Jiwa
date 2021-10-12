using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�L�����N�^�[�̓����ɂ��ẴX�N���v�g
public abstract class PlayerController : MonoBehaviour
{

    public PlayerStatus status; //�X�e�[�^�X

    // <�R���|�[�l���g>
    protected Rigidbody2D rb2d = null;
    protected Animator anim = null;
    protected SpriteRenderer spRen;
    public groundCheck ground;
    //</�R���|�[�l���g>


    public float jumpPower; //�W�����v��
    public float speed; //�ړ��X�s�[�h

    //�U�������蔻��
    protected Transform checkAttack;
    protected float attackRadius = 0.7f;

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
            spRen.flipX = false; //����

            checkAttack.transform.localPosition = new Vector3(0.16f, 0, 0);           

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
            spRen.flipX = true;

            checkAttack.transform.localPosition = new Vector3(-0.16f, 0, 0);

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("death", true);
        }
    }

    public void onDamage(int enemyAtk)
    {
        int damage;//���ۂɗ^����_���[�W
        damage = enemyAtk - this.status.getDef(); //�_���[�W=�G�̍U����-���g�̖h���
        if (damage < 0) damage = 0;//�_���[�W�����ł���ꍇ��0�_���[�W
        status.setHP(status.getHP() - damage); //�c��̗̑͂�HP�ɃZ�b�g
    }

    protected void getItem()
    {

    }

   protected virtual void Start()
    {
        //�R���|�[�l���g
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();
        checkAttack = transform.Find("checkAttack").GetComponent<Transform>(); //�U������I�u�W�F�N�g���q�I�u�W�F�N�g������

        //�X�e�[�^�X����
        status.setHP(status.getMaxHP());//HP���ő�HP�ɂ���
    }

    protected virtual void Update()
    {
        if (!anim.GetBool("death"))
        {
            move();

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            
            fall();//�������[�V����

            if (Input.GetKeyDown(KeyCode.V))
            {
                attack();

            }


        }

        death();
    }


}

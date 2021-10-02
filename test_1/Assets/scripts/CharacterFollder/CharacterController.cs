using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{

    protected Rigidbody2D rb2d = null;
    protected Animator anim = null;
    protected SpriteRenderer spRen;
    public groundCheck ground;

    public float jumpPower; //�W�����v��
    public float speed; //�ړ��X�s�[�h

    //�U�������蔻��
    protected Transform checkAttack;
    protected float attackRadius = 0.7f;

    bool damage=false;//�_���[�W���^�����邩

    protected void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ground.getIsGround())
            {
                rb2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("jump", true);
            }

        }

        /*�������[�V����*/
        float velY = rb2d.velocity.y;
        if (velY < 0.5f && !ground.getIsGround())
        {
            anim.SetBool("fall", true);
        }

    }

    protected void move()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        checkAttack = transform.Find("checkAttack").GetComponent<Transform>(); //�U������I�u�W�F�N�g���q�I�u�W�F�N�g���T��


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

    protected abstract void attack();


    protected void death()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("death", true);
        }
    }

   protected virtual void Start()
    {
        //�R���|�[�l���g
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();
    }


}

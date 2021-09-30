using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    protected Rigidbody2D rb2d = null;
    protected Animator anim = null;
    protected SpriteRenderer spRen;
    public groundCheck ground;

    //�U�������蔻��
    private Transform checkAttack;
    private float attackRadius=0.7f;

    public float jumpPower; //�W�����v��
    public float speed; //�ړ��X�s�[�h

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

    protected void attack()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            //�W�����v�ȊO
            if(!anim.GetBool("jump"))
            {
                anim.SetBool("attack", true); //�A�^�b�N�A�j���[�V����

                
                checkAttack = transform.Find("checkAttack").GetComponent<Transform>(); //�U������I�u�W�F�N�g���q�I�u�W�F�N�g���T��
                Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(checkAttack.position,attackRadius,LayerMask.GetMask("Enemy"));

                //�U��i�����������S�Ă̓G�ɑ΂���
                foreach(Collider2D hitEnemy in hitEnemys)
                {
                    hitEnemy.gameObject.GetComponent<Enemy>().onDamage(1); //�_���[�W��^����

                }
                
                
            }
             
        }
    }


    protected void death()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("death", true);
        }
    }


}

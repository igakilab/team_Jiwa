using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected Rigidbody2D rb2d = null;
    protected Animator anim = null;
    protected SpriteRenderer spRen;

    [SerializeField]private groundCheck ground;//�ڒn�m�F�N���X
    [SerializeField]private float jumpPower; //�W�����v��

    //�U�������蔻��
    protected Transform checkAttack;//�U������I�u�W�F�N�g�̃g�����X�t�H�[��
    protected float attackRadius=0.7f;//�U������̔��a

    protected void Jump()
    {
        if (ground.getIsGround())
        {
            rb2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
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

    protected abstract void death();

    protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        checkAttack = transform.Find("checkAttack").GetComponent<Transform>(); //�U������I�u�W�F�N�g���q�I�u�W�F�N�g������

    }

    protected virtual void Update()
    {
        fall();
    }

}

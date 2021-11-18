using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : CharacterStatus
{

    private bool invincible = false;//���G
    

    private int level;
    private int exp; //���݂̏����o���l
    int needExp;//���̃��x���オ��̂ɕK�v�Ȍo���l

    //�R���X�g���N�^
    public PlayerStatus(PlayerStatusData data):base(data)
    {
        //�v���C���[�̌ŗL�X�e�[�^�X�̏�����
        level = 1;
        exp = 0;
        needExp = 20;


        setInvicible(false);
        setDeath(false);
    }

    //�����_���ŃX�e�[�^�X���グ��
    void RandomStatusUp()
    {
        int Statusup = Random.Range(0, 3);//�R�̃X�e�[�^�X�������_���I��

        int UpValue = Random.Range(1, 4);//�X�e�[�^�X�̏オ���b�l

        switch (Statusup)
        {
            //HP
            case 0:
                int addValueHP = UpValue * 4;//HP�̏ꍇ�͊�b�l����*4�����l���グ��
                GameManager.instance.MessageLog.enqueueMessage("HP��" + addValueHP + "�オ����!");
                addMaxHP(addValueHP);
                addHP(addValueHP);
                break;
            //Atk
            case 1:
                GameManager.instance.MessageLog.enqueueMessage("�U���͂�" + UpValue + "�オ�����I");
                addAtk(UpValue);
                break;
            //Def
            case 2:
                GameManager.instance.MessageLog.enqueueMessage("�h��͂�" + UpValue + "�オ�����I");
                addDef(UpValue);
                break;
        }
    }

    public void levelup()
    {
        GameManager.instance.MessageLog.enqueueMessage("���x�����オ�����I");
        level++;

        exp = exp - needExp;//�o���l���z������������
        needExp = (int)(needExp * 1.2f);

        RandomStatusUp();
    }

    public bool isInvicible()
    {
        return invincible;
    }

    public void setInvicible(bool tf)
    {
        invincible = tf;
    }

    //getter setter adder

    public int getExp()
    {
        return this.exp;
    }

    public int getNeedExp()
    {
        return this.needExp;
    }



    public void addExp(int value)
    {
        this.exp += value;
    }


}

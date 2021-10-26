using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatusData : CharacterStatus
{
    private bool invincible = false; //���G
    private bool death=false;

    private int MaxHP; //���݂̍ő�̗�
    private int atk; //���݂̍U����
    private int def; //���݂̖h���

    private int level=1;
    private int exp; //���݂̏����o���l
    int needExp;//���̃��x���オ��̂ɕK�v�Ȍo���l

    private int hp;


    public void showStatus()
    {

    }

    //�����_���ŃX�e�[�^�X���グ��
    void RandomStatusUp()
    {
        int Statusup = Random.Range(0, 3);//�R�̃X�e�[�^�X�������_���I��

        int UpValue = Random.Range(1, 4);//�X�e�[�^�X�̏オ���b�l

        switch(Statusup)
        {
            //HP
            case 0:
                int addValueHP=UpValue*4;//HP�̏ꍇ�͊�b�l����*4�����l���グ��
                GameManager.instance.MessageLog.enqueueMessage("HP��"+addValueHP+"�オ����!");
                addMaxHP(addValueHP);
                addHP(addValueHP);
                break;
            //Atk
            case 1:
                GameManager.instance.MessageLog.enqueueMessage("�U���͂�"+UpValue+"�オ�����I");
                addAtk(UpValue);
                break;
            //Def
            case 2:
                GameManager.instance.MessageLog.enqueueMessage("�h��͂�"+UpValue+"�オ�����I");
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

    public bool isDeath()
    {
        return death;
    }

    public void setDeath(bool tf)
    {
        this.death = tf;
    }

    public void initialize()
    {
        level = 1;
        MaxHP = getInitMaxHP();
        hp = getMaxHP();
        atk = getInitAtk();
        def = getInitDef();
        needExp = 20;
        exp = 0;

        setInvicible(false);
        setDeath(false); 
    }

    //getter setter adder
    public int getMaxHP()
    {
        return this.MaxHP;
    }

    public int getHP()
    {
        return hp;
    }


    public int getAtk()
    {
        return this.atk;
    }

    public int getDef()
    {
        return this.def;
    }

    public int getExp()
    {
        return this.exp;
    }

    public int getNeedExp()
    {
        return this.needExp;
    }

    public void setHP(int value)
    {
        this.hp = value;
    }

    public void addMaxHP(int value)
    {
        this.MaxHP += value;
    }

    public void addAtk(int value)
    {
        this.atk += value;
    }

    public void addDef(int value)
    {
        this.def += value;
    }

    public void addExp(int value)
    {
        this.exp += value;
    }

    public void addHP(int hp)
    {
        this.hp += hp;
    }

}

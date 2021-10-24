using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : ScriptableObject
{

    [SerializeField]
    private int initMaxHP;//�ő�̗�
    [SerializeField]
    private int initAtk; //�U����
    [SerializeField]
    private int initDef; //�h���


    private int HP; //���݂�HP;


    public int getInitMaxHP()
    {
        return initMaxHP;
    }

    public int getHP()
    {
        return HP;
    }

    public void setHP(int hp)
    {
        this.HP = hp;
    }

    public void addHP(int hp)
    {
        this.HP+=hp;
    }

    public int getInitAtk()
    {
        return this.initAtk;
    }


    public int getInitDef()
    {
        return this.initDef;
    }
}

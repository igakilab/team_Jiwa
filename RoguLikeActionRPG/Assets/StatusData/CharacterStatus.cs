using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : ScriptableObject
{

    [SerializeField]
    private int initMaxHP;//Å‘å‘Ì—Í
    [SerializeField]
    private int initAtk; //UŒ‚—Í
    [SerializeField]
    private int initDef; //–hŒä—Í


    private int HP; //Œ»İ‚ÌHP;


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

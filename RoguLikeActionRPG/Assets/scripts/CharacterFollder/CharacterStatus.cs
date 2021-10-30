using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus
{
    private int maxHP;
    private int hp;
    private int atk;
    private int def;

    private bool death = false;//死んだか

    public CharacterStatus(CharacterStatusData data)
    {
        maxHP = data.getInitMaxHP();
        hp = maxHP;
        atk = data.getInitAtk();
        def = data.getInitDef();

        
    }

    //ステータス初期化
    protected virtual void initialize(CharacterStatusData data)
    {

    }

    //getter setter adder
    public int getMaxHP()
    {
        return this.maxHP;
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

    public void setHP(int value)
    {
        this.hp = value;
    }

    public void addMaxHP(int value)
    {
        this.maxHP += value;
    }

    public void addAtk(int value)
    {
        this.atk += value;
    }

    public void addDef(int value)
    {
        this.def += value;
    }
    public void addHP(int hp)
    {
        this.hp += hp;
    }
    public bool isDeath()
    {
        return death;
    }

    public void setDeath(bool tf)
    {
        this.death = tf;
    }
}

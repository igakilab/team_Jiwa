using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : ScriptableObject
{

    [SerializeField]
    private int initMaxHP;//最大体力
    [SerializeField]
    private int initAtk; //攻撃力
    [SerializeField]
    private int initDef; //防御力


    private int HP; //現在のHP;


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

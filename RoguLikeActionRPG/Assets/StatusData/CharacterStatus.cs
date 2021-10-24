using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : ScriptableObject
{

    [SerializeField]
    private int maxHP;//最大体力
    [SerializeField]
    private int atk; //攻撃力
    [SerializeField]
    private int def; //防御力

    private int HP; //現在のHP;


    public int getMaxHP()
    {
        return maxHP;
    }

    public int getHP()
    {
        return HP;
    }

    public void setHP(int hp)
    {
        this.HP = hp;
    }

    public int getAtk()
    {
        return this.atk;
    }

    public int getDef()
    {
        return this.def;
    }
}

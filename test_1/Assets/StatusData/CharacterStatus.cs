using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : ScriptableObject
{

    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int atk; //UÍ
    [SerializeField]
    private int def; //häÍ

    private int HP; //»ÝÌHP;


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

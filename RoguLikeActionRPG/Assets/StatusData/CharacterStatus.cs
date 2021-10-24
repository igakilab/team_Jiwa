using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : ScriptableObject
{

    [SerializeField]
    private int maxHP;//Å‘å‘Ì—Í
    [SerializeField]
    private int atk; //UŒ‚—Í
    [SerializeField]
    private int def; //–hŒä—Í

    private int HP; //Œ»İ‚ÌHP;


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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : ScriptableObject
{
    // Start is called before the first frame update

    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int atk; //çUåÇóÕ
    [SerializeField]
    private int def; //ñhå‰óÕ

    private int HP; //åªç›ÇÃHP;


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

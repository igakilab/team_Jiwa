using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : ScriptableObject
{

    [SerializeField]
    private int maxHP;//�ő�̗�
    [SerializeField]
    private int atk; //�U����
    [SerializeField]
    private int def; //�h���

    private int HP; //���݂�HP;


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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusData : ScriptableObject
{

    [SerializeField]
    private int initMaxHP;//�ő�̗�
    [SerializeField]
    private int initAtk; //�U����
    [SerializeField]
    private int initDef; //�h���

    //getter,setter,adder
    public int getInitMaxHP()
    {
        return initMaxHP;
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

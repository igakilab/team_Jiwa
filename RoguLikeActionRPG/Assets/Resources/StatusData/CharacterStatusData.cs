using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusData : ScriptableObject
{

    [SerializeField]
    private int initMaxHP;//Å‘å‘Ì—Í
    [SerializeField]
    private int initAtk; //UŒ‚—Í
    [SerializeField]
    private int initDef; //–hŒä—Í

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

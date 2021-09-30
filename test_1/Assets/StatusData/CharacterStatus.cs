using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : ScriptableObject
{
    // Start is called before the first frame update

    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int atk; //UŒ‚—Í
    [SerializeField]
    private int def; //–hŒä—Í


    public int getMaxHP()
    {
        return maxHP;
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

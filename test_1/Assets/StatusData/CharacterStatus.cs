using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : ScriptableObject
{
    // Start is called before the first frame update

    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int atk; //�U����
    [SerializeField]
    private int def; //�h���


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

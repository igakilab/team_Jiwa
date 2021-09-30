using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStatusData : CharacterStatus
{
    [SerializeField]
    private string name; //–¼‘O
    [SerializeField]
    private int exp;//ŒoŒ±’l

    public int getExp()
    {
        return this.exp;
    }

    public string getName()
    {
        return this.name;
    }
}

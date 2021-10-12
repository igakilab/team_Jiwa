using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStatusData : CharacterStatus
{
    [SerializeField]
    private string EnemyID;
    [SerializeField]
    private string name; //ñºëO
    [SerializeField]
    private float speed; /*èrïqê´*/
    [SerializeField]
    private int exp;//åoå±íl

    public int getExp()
    {
        return this.exp;
    }

    public string getName()
    {
        return this.name;
    }
    public float getSpeed()
    {
        return this.speed;
    }
}

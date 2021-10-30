using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStatusData : CharacterStatusData
{
    [SerializeField]
    private string EnemyID;
    [SerializeField]
    private string Name; //ñºëO
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
        return this.Name;
    }
    public float getSpeed()
    {
        return this.speed;
    }
}

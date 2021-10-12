using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStatusData : CharacterStatus
{
    [SerializeField]
    private string EnemyID;
    [SerializeField]
    private string name; //���O
    [SerializeField]
    private float speed; /*�r�q��*/
    [SerializeField]
    private int exp;//�o���l

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

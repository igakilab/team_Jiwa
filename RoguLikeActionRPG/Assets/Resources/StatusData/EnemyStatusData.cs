using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStatusData : CharacterStatus
{
    [SerializeField]
    private string EnemyID;
    [SerializeField]
    private string Name; //���O
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
        return this.Name;
    }
    public float getSpeed()
    {
        return this.speed;
    }
}

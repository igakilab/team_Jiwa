using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    protected int hp; /*現在のHP*/

    public void onDamage(int damage)
    {
        this.hp -= damage;
    }

    public void death()
    {
        if(hp<=0)
        {
            hp = 0;

            /*
             アニメーション、挙動;
             */

            Destroy(this.gameObject);
        }
    }

    public int getHP()
    {
        return this.hp;
    }
    public void setHP(int hp)
    {
        this.hp = hp;
    }

    public abstract void attack();

}

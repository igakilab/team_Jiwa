using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatusData : CharacterStatus
{
    private bool invincible = false; //���G

    public bool isInvicible()
    {
        return invincible;
    }

    public void setInvicible(bool tf)
    {
        invincible = tf;
    }
}

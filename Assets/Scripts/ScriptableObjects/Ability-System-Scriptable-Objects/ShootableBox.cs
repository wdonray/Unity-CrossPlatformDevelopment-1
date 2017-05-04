using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootableBox : EntityBase
{

    public int health;

    public void Damage(int amount)
    {
        var newhealth = health - amount;
        if(newhealth > 0)
            
        health = newhealth - amount;
    }
}

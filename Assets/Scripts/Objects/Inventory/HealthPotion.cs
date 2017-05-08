using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Potions/HealthPotions")]
public class HealthPotion : Potion
{
    public string statToModify = "Health";
    public RPGStats.Modifier healthMod;
    public int Value;
    public override void Initialize(GameObject obj)
    {
        owner = obj;
        healthMod = new RPGStats.Modifier("add", statToModify , Value);
    }

    public override void Execute()
    {
        base.Execute();
        this.Consume(this.owner);
    }
    public override void Consume(GameObject owner)
    {
        owner.GetComponent<PlayerBehaviour>().ModifyStat(statToModify, healthMod);
        
    }
    
}

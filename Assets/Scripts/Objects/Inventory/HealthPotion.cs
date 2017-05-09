using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Potions/HealthPotions")]
public class HealthPotion : Potion
{
    public string statToModify = "Health";
    public GenericModifier healthMod;
    public int Value;
    public override void Initialize(GameObject obj)
    {
        _owner = obj;
        healthMod = Instantiate(healthMod);
    }

    public override void Execute()
    {        
        this.Consume(this._owner);
    }
    public override void Consume(GameObject owner)
    {
        owner.GetComponent<PlayerBehaviour>().ModifyStat(healthMod.ModType.ToString(), healthMod.TheMod);
        
    }
    
}

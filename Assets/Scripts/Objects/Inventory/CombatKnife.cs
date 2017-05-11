using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/CombatKnife")]
public class CombatKnife : Weapon
{
    private BackPack backpack;

    public override void Execute()
    {
        throw new NotImplementedException();
    }

    public override void Initialize(GameObject obj)
    {
        if (Name == "")
            Name = "CombatKnife";
        if(obj == null)
            return;
        backpack = obj.GetComponent<BackPack>();
        backpack.AddToPack(Instantiate(this));
    }
}
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "KevlarVest", menuName = "Item/KevlarVest")]
public class KevlarVest : Armor
{
    private BackPack backpack;

    public override void Execute()
    {
        throw new NotImplementedException();
    }

    public override void Initialize(GameObject obj)
    {        
        ID = GetHashCode();

        if (Name == "")
            Name = "KevlarVest";
        name = Name;
        if (obj == null)
            return;

        backpack = obj.GetComponent<BackPack>();
        backpack.Add(Instantiate(this));
    }
}
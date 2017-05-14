using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Items/KevlarVest")]
public class KevlarVest : Armor
{
    public int yep = 0;
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
         
    }
}
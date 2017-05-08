using UnityEngine;

[CreateAssetMenu(menuName = "Item/CombatKnife")]
public class CombatKnife : Weapon
{
    private BackPack backpack;

    public override void Initialize(GameObject obj)
    {
        if (Name == "")
            Name = "CombatKnife";
        backpack = obj.GetComponent<BackPack>();
        backpack.Add(Instantiate(this));
    }
}
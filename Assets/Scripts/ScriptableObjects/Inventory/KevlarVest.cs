
using UnityEngine;

[CreateAssetMenu(fileName = "KevlarVest", menuName = "Item/KevlarVest")]
public class KevlarVest : Armor
{
    private BackPack backpack;
    public override void Initialize(GameObject obj)
    {
        if (Name == "")
            Name = "KevlarVest";
        backpack = obj.GetComponent<BackPack>();
        backpack.Add(Instantiate(this));
    }
}

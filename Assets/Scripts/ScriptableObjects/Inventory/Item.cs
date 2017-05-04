using UnityEngine;

public abstract class Item : ScriptableObject
{
    public int ID;
    public string Name = "Item";
    public virtual void Initialize(GameObject obj){}
    public virtual void AddTo(BackPack backpack){}
    public virtual void RemoveFrom(BackPack backpack){}
    public Sprite sprite;
}

public abstract class Equipment : Item, IEquippable
{
    public virtual void Equip() {}
    public virtual void UnEquip() {}
}

public abstract class Weapon : Equipment
{
    public int Damage;
}

public abstract class Armor : Equipment
{
    public int ArmorRating;
}

#region Interfaces
public interface IShootable
{
    void Shoot(GameObject Target);
}

public interface IEquippable
{
    void Equip();
    void UnEquip();
}

public interface ISwingable
{
    void Swing();
}
#endregion
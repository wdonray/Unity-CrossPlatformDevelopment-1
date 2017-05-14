using System;
using UnityEngine;

[Serializable]
public abstract class Item : ScriptableObject, IExecutable
{
    public int ID;
    public string Name = "Item";
    public Sprite sprite;
    /// <summary>
    /// the GameObject responsible for this instance object
    /// </summary>
    protected GameObject _owner;

    public abstract void Execute();

    /// <summary>
    /// initialize this object with an owner
    /// </summary>
    /// <param name="obj"></param>
    public virtual void Initialize(GameObject obj)
    {
        Name = this.GetType().ToString();
        obj = _owner;
        ID = GetHashCode();
    }

}
[Serializable]
public abstract class Equipment : Item, IEquippable
{
    public virtual void Equip()
    {
    }

    public virtual void UnEquip()
    {
    }
}
[Serializable]
public abstract class Potion : Equipment, IConsumable
{
    public abstract void Consume(GameObject owner);
}
[Serializable]
public abstract class Weapon : Equipment
{
    public int Damage;
}
[Serializable]
public abstract class Armor : Equipment
{
    public int ArmorRating;
}

#region Interfaces
public interface IExecutable
{
    void Execute();
}
public interface IShootable
{
    void Shoot(GameObject owner);
}
public interface IConsumable
{
    void Consume(GameObject owner);
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
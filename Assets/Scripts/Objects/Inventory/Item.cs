using System;
using UnityEngine;

public abstract class Item : ScriptableObject, IExecutable
{
    public int ID;
    public string Name = "Item";
    public Sprite sprite;
    protected GameObject _owner;

    public abstract void Execute();
    public abstract void Initialize(GameObject obj);

}

public abstract class Equipment : Item, IEquippable
{
    public virtual void Equip()
    {
    }

    public virtual void UnEquip()
    {
    }
}

public abstract class Potion : Equipment, IConsumable
{
    public abstract void Consume(GameObject owner);
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
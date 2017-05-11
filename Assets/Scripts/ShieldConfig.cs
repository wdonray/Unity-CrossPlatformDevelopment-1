using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldConfig : Weapon, IBlockable
{
    public float ShieldGrowth;

    public float BlockDelay;

    public virtual void Block()
    {
        throw new NotImplementedException();
    }

    public virtual void StopBlock()
    {
        throw new NotImplementedException();
    }

    public override void Execute()
    {
        this.Block();
    }

    public override void Initialize(GameObject obj)
    {
        this._owner = obj;
    }
}


public interface IBlockable
{
    void Block();

    void StopBlock();
}
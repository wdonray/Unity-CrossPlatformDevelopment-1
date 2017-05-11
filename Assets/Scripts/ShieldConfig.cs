using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldConfig : Weapon, IBlock
{
    public float ShieldGrowth;    

    public virtual void Block()
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


public interface IBlock
{
    void Block();
}
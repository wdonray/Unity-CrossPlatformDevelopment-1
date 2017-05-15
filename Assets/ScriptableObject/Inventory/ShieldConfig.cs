using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldConfig : Weapon, IBlockable
{
    public float ShieldGrowth;    

    public virtual void Block(GameObject blockedObject = null)
    {
        throw new NotImplementedException();
    }

    public virtual void StopBlock()
    {
        throw new NotImplementedException();
    }

    public override void Execute()
    {
        //this.Block();
    }

    public override void Initialize(GameObject obj)
    {
        this._owner = obj;
        base.Initialize(obj);

    }
}


public interface IBlockable
{
    void Block(GameObject blockedObject);

    void StopBlock();
}
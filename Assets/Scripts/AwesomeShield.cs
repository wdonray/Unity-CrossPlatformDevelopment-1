using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AwesomeShield", menuName = "Items/Shields/Awesome Shield")]
public class AwesomeShield : ShieldConfig
{
    public Vector3 MaxScale;
    public Vector3 InitialScale;

    public override void Block()
    {
        Debug.Log(this._owner.transform.localScale.magnitude + " Local");
        Debug.Log(MaxScale.magnitude + "Max");
        if(this._owner.transform.localScale.magnitude < MaxScale.magnitude)
            this._owner.transform.localScale *= ShieldGrowth;            
    }
    public override void StopBlock()
    {
        this._owner.transform.localScale = InitialScale;
    }

    public override void Initialize(GameObject obj)
    {
        base.Initialize(obj);
        InitialScale = _owner.transform.localScale;
        MaxScale = _owner.transform.localScale * ShieldGrowth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spikey Shield", menuName = "Items/Shields/Spikey Shield")]
public class SpikeyShield : ShieldConfig
{   
    public override void Block(GameObject blockedObject)
    {
                
    }

    public override void StopBlock()
    {

    }

    public override void Initialize(GameObject obj)
    {
        base.Initialize(obj);
        _StatModifier = Instantiate(_StatModifier);
    }

    public GenericModifier _StatModifier;
}

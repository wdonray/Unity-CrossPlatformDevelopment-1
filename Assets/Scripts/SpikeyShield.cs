using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spikey Shield", menuName = "Items/Shields/Spikey Shield")]
public class SpikeyShield : ShieldConfig
{   
    public override void Block(GameObject blockedObject)
    {
        if(blockedObject.GetComponentInParent<CharacterBehavior>())
            blockedObject.GetComponentInParent<CharacterBehavior>().ModifyStat(_StatModifier.EffectedStatType.ToString(), _StatModifier.TheMod);
    }

    public override void StopBlock()
    {

    }

    public override void Initialize(GameObject obj)
    {
        base.Initialize(obj);
        _StatModifier = Instantiate(_StatModifier);
        _StatModifier.Initialize(null);
    }

    public GenericModifier _StatModifier;
}

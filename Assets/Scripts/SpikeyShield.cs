using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spikey Shield", menuName = "Items/Shields/Spikey Shield")]
public class SpikeyShield : ShieldConfig
{
    Anima2D.SpriteMesh spikeyShieldMesh;

    public override void Block(GameObject blockedObject)
    {
        if(blockedObject.GetComponentInParent<CharacterBehaviour>())
            blockedObject.GetComponentInParent<CharacterBehaviour>().ModifyStat(_StatModifier.EffectedStatType.ToString(), _StatModifier.TheMod);
    }

    public override void StopBlock()
    {

    }

    public override void Initialize(GameObject obj)
    {
        base.Initialize(obj);
        _StatModifier = Instantiate(_StatModifier);
        _StatModifier.Initialize(null);
        obj.GetComponent<Anima2D.SpriteMeshInstance>().spriteMesh = spikeyShieldMesh;
    }

    public GenericModifier _StatModifier;
}

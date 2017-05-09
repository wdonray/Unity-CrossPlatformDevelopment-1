using System.Collections;
using System.Collections.Generic;

using Assets.Scripts.Objects.Stats;

using RPGStats;

using UnityEngine;

[CreateAssetMenu(menuName = "Modifier")]
public class GenericModifier : StatModifier {

    public override void Initialize(GameObject go)
    {
        this.TheMod = new Modifier(this.ModType.ToString(), this.EffectedStatType.ToString(), this.ModifiedValue);
    }
}

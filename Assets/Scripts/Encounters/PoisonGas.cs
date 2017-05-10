using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Encounter/PoisonGas")]
public class PoisonGas : Encounter {
    
    public Material encounterMaterial;
    public GenericModifier modifier;

    private GameObject _player;

    public override void Initialize(GameObject obj)
    {
        base.Initialize(obj);

        //Adds a particle system to the Encounter GameObject
        //Edits the rate of emission and the particle lifetimes
        obj.AddComponent<ParticleSystem>();
        var em = obj.GetComponent<ParticleSystem>().emission;
        em.rateOverTime = 200;
        var main = obj.GetComponent<ParticleSystem>().main;
        main.startLifetime = 1;

        obj.GetComponent<ParticleSystemRenderer>().material = encounterMaterial;

        //Finds player for Encounter functions
        _player = FindObjectOfType<PlayerInput>().gameObject;
    }

    public override bool EncounterStart()
    {
        Debug.Log("You got the stank!");

        return true;
    }

    public override bool EncounterUnderway()
    {
        return true;
    }

    public override bool EncounterEnd()
    {
        return true;
    }
}

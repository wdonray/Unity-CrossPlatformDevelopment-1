using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Encounter : ScriptableObject {

    /// <summary>
    /// Boolean variable that helps guide the EncounterBehavior
    /// Is true if it is limited by an area
    /// Is false if it is considered persistant until the End conditions are met
    /// </summary>
    public virtual bool Contained //Variable name up for change
    {
        get
        {
            return true;
        }
    }

    public virtual bool EncounterStart(GameObject obj)
    {
        return EncounterStart();
    }
    public virtual bool EncounterStart()
    {
        Debug.Log("EncounterStart Has Not Been Overridden");

        return true;
    }

    public virtual bool EncounterUnderway()
    {
        Debug.Log("EncounterUnderway Has Not Been Overridden");

        return true;
    }

    public virtual bool EncounterEnd()
    {
        Debug.Log("EncounterEnd Has Not Been Overridden");

        return true;
    }

    public virtual void Initialize(GameObject obj)
    {
    }
}

using System;
using RPGStats;
using UnityEngine;
using UnityEngine.Events;

public abstract class CharacterBehaviour : MonoBehaviour
{
    [Serializable]
    public class OnStatModify : UnityEvent<string> { }


    [Serializable]
    public class OnHealthChange : UnityEvent<int> { }

    protected int modcount;
    [SerializeField]
    protected Stats PlayerStats;
    public OnHealthChange onHealthChange = new OnHealthChange();
    public OnStatModify onStatModify = new OnStatModify();
    
    public virtual void ModifyStat(string statName, Modifier mod) { }
}

using System;
using System.Collections.Generic;
using RPGStats;
using ScriptableAssets;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : CharacterBehaviour
{

    [Serializable]
    public class OnStatModify : UnityEvent<string> { }

    [Serializable]
    public class OnHealthChange : UnityEvent<int> { }

    private int modcount;
    public OnHealthChange onHealthChange = new OnHealthChange();
    public OnStatModify onStatModify = new OnStatModify();
    public Stats PlayerStats;

    //TODO : ADD THE TIMERFOR DEBUFFS AND DAMAGE OVER TIME, MAKE AN OBJECT TO HOLD THE ID OF THE MOD AND THE TIME TILL IT NEEDS TO GO AWAY

    void Awake()
    {
        if (PlayerStats == null)
        {
            Debug.LogWarning("you have not assigned a stats reference object");
            return;
        }

        var newstats = Instantiate(PlayerStats);
        PlayerStats = newstats;
    }

    void Start()
    {
        onStatModify.Invoke("");
    }

    public override int ModifyStatOverTime(string statName, Modifier mod)
    {
        var valids = new List<string>(Enum.GetNames(typeof(StatType)));
        if (!valids.Contains(statName)) return -1;
        PlayerStats.AddModifier(modcount++, mod);

        if (statName == "Health")
            onHealthChange.Invoke(PlayerStats[statName].Value);
        onStatModify.Invoke(statName);
        return modcount;
    }

    public override void ModifyStat(string statName, Modifier mod)
    {
        var valids = new List<string>(Enum.GetNames(typeof(StatType)));
        if (!valids.Contains(statName))
        {
            Debug.LogWarningFormat("stat:: {0}, is not a valid stat to modify", statName);
            return;
        }

        PlayerStats.AddModifier(modcount++, mod);

        if (statName == "Health")
            onHealthChange.Invoke(PlayerStats[statName].Value);
        onStatModify.Invoke(statName);
    }

    public void ClearAll()
    {
        PlayerStats.ClearModifiers();
        onHealthChange.Invoke(PlayerStats["Health"].Value);
    }

}
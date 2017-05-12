using System;
using System.Collections.Generic;
using RPGStats;
using ScriptableAssets;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : CharacterBehavior
{
    int modcount;
    public OnHealthChange onHealthChange = new OnHealthChange();
    public OnStatModify onStatModify;
    public Stats stats;

    //TODO : ADD THE TIMERFOR DEBUFFS AND DAMAGE OVER TIME, MAKE AN OBJECT TO HOLD THE ID OF THE MOD AND THE TIME TILL IT NEEDS TO GO AWAY

    List<int> timedMods;


    void Awake()
    {
        if (stats == null)
        {
            Debug.LogWarning("you have not assigned a stats reference object");
            return;
        }

        var newstats = Instantiate(stats);
        stats = newstats;
    }

    void Start()
    {
        onStatModify.Invoke();
    }

    public void ModifyStatOverTime(string stat, Modifier mod, float duration)
    {
        var valids = new List<string>(Enum.GetNames(typeof(StatType)));
        if (!valids.Contains(stat)) return;
        stats.AddModifier(modcount++, mod);
        timedMods.Add(modcount);

        if (stat == "Health")
            onHealthChange.Invoke(stats.GetStat(stat).Value);
        onStatModify.Invoke();
    }

    public override void ModifyStat(string stat, Modifier mod)
    {
        var valids = new List<string>(Enum.GetNames(typeof(StatType)));
        if (!valids.Contains(stat))
        {
            Debug.LogWarningFormat("stat:: {0}, is not a valid stat to modify", stat);
            return;
        }

        stats.AddModifier(modcount++, mod);

        if (stat == "Health")
            onHealthChange.Invoke(stats.GetStat(stat).Value);
        onStatModify.Invoke();
    }

    public void ModifyRandomStat(string stat)
    {
        var valids = new List<string>(Enum.GetNames(typeof(StatType)));
        if (!valids.Contains(stat)) return;


        var res = stats.AddModifier(modcount++, new Modifier("add", stat, 2));
        var info = string.Format("Stat: {0}, {1} modifier of {2} :: {3}", stat, "add", 2, res);
        Debug.Log(info);
        onStatModify.Invoke();
    }

    [Serializable]
    public class OnStatModify : UnityEvent
    {
    }

    [Serializable]
    public class OnHealthChange : UnityEvent<int>
    {
    }
}
using System;
using System.Collections.Generic;
using RPGStats;
using ScriptableAssets;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : CharacterBehaviour
{

    //TODO : ADD THE TIMERFOR DEBUFFS AND DAMAGE OVER TIME, MAKE AN OBJECT TO HOLD THE ID OF THE MOD AND THE TIME TILL IT NEEDS TO GO AWAY

    void Awake()
    {
        if (PlayerStats == null)
        {
            Debug.LogWarning("you have not assigned a stats reference object");
            return;
        }
        
        GameState.Instance._player = new GameState.PlayerInfo(PlayerStats) { Name = name };
    }

    void Start()
    {
        onStatModify.Invoke("");
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
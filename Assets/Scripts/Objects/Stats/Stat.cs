using System;
using RPGStats;
using UnityEngine;

namespace ScriptableAssets
{
    public enum StatType
    {
        Knowledge,
        Guts,
        Charm,
        Kindness,
        Health,
        Mana,
    }

    [Serializable]
    public class Stat
    {
        [SerializeField] private int _baseValue = 1;

        public StatType Name;
        public int Value;


        public void Apply(Modifier mod)
        {
            if (mod.type == "add")
                Value += _baseValue + mod.value;
            if (mod.type == "mult")
                Value += _baseValue * mod.value / 10;
        }

        public void Remove(Modifier mod)
        {
            if (mod.type == "add")
                Value -= _baseValue + mod.value;
            if (mod.type == "mult")
                Value -= _baseValue * mod.value / 10;
        }
    }
}
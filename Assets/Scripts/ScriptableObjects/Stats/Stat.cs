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
        Kindness
    }

    [Serializable]
    public class Stat
    {
        public StatType Name;
        [SerializeField]
        int _baseValue = 1;
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
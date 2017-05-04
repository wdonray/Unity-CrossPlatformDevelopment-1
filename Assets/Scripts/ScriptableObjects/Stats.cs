using System;
using System.Collections.Generic;
using System.Linq;
using RPGStats;
using UnityEngine;

namespace ScriptableAssets
{
    [CreateAssetMenu(fileName = "Stats", menuName = "Stats/StatsTemplate", order = 1)]
    public class Stats : ScriptableObject
    {
        public Dictionary<string, Stat> Items = new Dictionary<string, Stat>();

        public Dictionary<int, Modifier> Modifiers = new Dictionary<int, Modifier>();

        public Stat[] stats;

        void OnEnable()
        {
            if(stats == null) return;

            foreach (var stat in stats)
                Add(stat);
        }

        public string AddModifier(int id, Modifier m)
        {
            Modifiers.Add(id, m);
            var result = string.Format(
                "Add modifier {0} {1} {2}",
                Modifiers[id].stat,
                Modifiers[id].type,
                Modifiers[id].value);


            Items[m.stat].Apply(m);
            return result;
        }

        public string RemoveModifier(int id)
        {
            var result = string.Format("Remove modifier {0} {1} {2}", Modifiers[id].stat, Modifiers[id].type,
                Modifiers[id].value);
            Items[Modifiers[id].stat].Remove(Modifiers[id]);
            Modifiers.Remove(id);
            return result;
        }

        public void Add(Stat s)
        {
            Items.Add(s.Name.ToString(), s);
        }

        public void ClearModifiers()
        {
            var keys = Modifiers.Keys.ToArray();
            foreach (var key in keys)
                RemoveModifier(key);
            Modifiers.Clear();
        }

        public Stat GetStat(string key)
        {
            return Items[key];
        }
    }
}
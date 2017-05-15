using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RPGStats;
using UnityEngine;
 
    [CreateAssetMenu(menuName = "Stats")]
    public class Stats : ScriptableObject, IEnumerable<Stat>
    {
        public List<IDModifier> INSPECTOR_MODS = new List<IDModifier>();
        public Dictionary<string, Stat> Items = new Dictionary<string, Stat>();

        public Dictionary<int, Modifier> Modifiers = new Dictionary<int, Modifier>();
        public Stat[] stats;

        public Stat this[string element]
        {
            get
            {
                if (Items.ContainsKey(element))
                    return Items[element];
                return null;
            }

            set { Items[element] = value; }
        }

        public IEnumerator<Stat> GetEnumerator()
        {
            return Items.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.Values.GetEnumerator();
        }

        private void OnEnable()
        {
            if (stats == null) return;

            foreach (var stat in stats)
                Add(stat);
        }

        public string AddModifier(int id, Modifier m)
        {
            INSPECTOR_MODS.Add(new IDModifier {identifier = id, mod = m});
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
            {
                RemoveModifier(key);
            }
                
            Modifiers.Clear();
            INSPECTOR_MODS.Clear();

        }

        public Stat GetStat(string key)
        {
            return Items[key];
        }

        [Serializable]
        public class IDModifier
        {
            public int identifier;
            public Modifier mod;
        }
    }
 
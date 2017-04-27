using System.Runtime.Serialization;
using System;

namespace RPGStats
{
    [DataContract]
    [System.Serializable]
    public class Stat
    {
        public Stat()
        {
            Name = "Name:";
            Value = 0;
            _baseValue = Value;
            OnStatAdd += Doit;
        }

        public Stat(string n, int v)
        {
            Name = n;
            Value = v;
            _baseValue = Value;
            OnStatAdd += Doit;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Value { get; set; }

        [DataMember] private readonly int _baseValue;

        [IgnoreDataMember] public Action OnStatAdd;

        void Doit()
        {
        }

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
﻿using RPGStats;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Combat
{
    public class Combat
    {
        //roll for initiative
        //roll 20d and add dex mod
        private Combat()
        {
            _initiativeSeed = new Random();
            _attackSeed = new Random();
        }

        private readonly Random _initiativeSeed;
        private readonly Random _attackSeed;

        public static Combat Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = new Combat();
                return _instance;
            }
        }

        private static Combat _instance;

        [DataMember]
        public int Round { get; set; }

        [DataMember]
        public List<Unit> Participants { get; set; }


        public int RollForInitiative(Unit u1)
        {
            var roll = _initiativeSeed.Next(1, 21);
            var dex = u1.RpgStats.GetStat("Dexterity");
            int value = dex.Value;
            return ((value - 10) / 2) + roll;
        }

        public Tuple<bool, int> RollForAttack(Unit attacker, Unit defender)
        {
            //chance to hit

            int roll = _attackSeed.Next(1, 21);
            RPG_Stat s1 = attacker.RpgStats.GetStat(attacker.Weapon.StatName);
            int s2 = defender.ArmorCount;
            int playerRoll = ((s1.Value - 10) / 2) + roll;
            int damage = playerRoll - roll + attacker.Weapon.Roll();
            return new Tuple<bool, int>((playerRoll > s2), damage);
        }

        public void StartCombat()
        {
            foreach(var unit in Participants)
                unit.Initiative = RollForInitiative(unit);
            Participants.Sort((a, b) => -1 * a.Initiative.CompareTo(b.Initiative));
        }

        public void Resolve()
        {
            Random r = new Random();

            foreach(var unit in Participants)
            {
                var target = Participants[r.Next(0, Participants.Count)];
                if(unit.Health > 0)
                {
                    while(target == unit || target.Health <= 0)
                        target = Participants[r.Next(0, Participants.Count)];

                    var attack = unit.Attack(target);

                    if(attack.Item1)
                    {
                        target.TakeDamage(attack.Item2);
                        Debug.WriteLine("{0} Hit?::{1} {2} with Damage {3}", unit.Name, target.Name, attack.Item1,
                            attack.Item2);
                    }
                    else
                        Debug.WriteLine("{0} MISS!!{1} ", unit.Name, target.Name, attack.Item1);
                }
            }
        }

        public void ShowCombatLog()
        {
            Debug.WriteLine("\n=========COMBAT LOG==============");
            foreach(var u in Participants)
            {
                Debug.WriteLine(string.Format("Name: {0} Health: {1} ", u.Name, u.Health));
            }
            Debug.WriteLine("=========COMBAT LOG==============\n");
        }


        public void AddParticipant(params Unit[] u)
        {
            if(Participants == null)
                Participants = new List<Unit>();
            Participants.AddRange(u);
        }
    }
}
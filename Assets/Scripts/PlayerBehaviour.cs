using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGStats;

public class PlayerBehaviour : MonoBehaviour {
    
    public Stats PlayerStats
    {
        get;
        private set;
    }
    
    [System.Serializable]
    public class PlayerStat 
    {
        public PlayerStat(Stat s)
        {
            name = s.Name;
            value = s.Value;
        }

        [SerializeField]
        private string name;
        [SerializeField]
        private int value;
    }

    [SerializeField]
    private List<PlayerStat> p_stats;
    // Use this for initialization
    void Start ()
	{
        if(PlayerStats != null) return;
	    Create();
	}

    [ContextMenu("Create Player")]
    void Create()
    {
        var knowledge = new Stat("knowledge", 0);
        var guts = new Stat("guts", 0);
        var charm = new Stat("charm", 0);
        var kindness = new Stat("kindness", 0);

        PlayerStats = new Stats(knowledge, guts, charm, kindness);

        p_stats = new List<PlayerStat>()
        {
            new PlayerStat(knowledge),
            new PlayerStat(guts),
            new PlayerStat(charm),
            new PlayerStat(kindness),
        };
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGStats;
using UnityEngine.Events;

public class OnStatModify : UnityEvent<RPGStats.Stat>
{
    public OnStatModify() { }
} 

public class PlayerBehaviour : MonoBehaviour
{
    public OnStatModify onStatModify;
    private void Awake()
    {
        onStatModify = new OnStatModify();
    }

    [SerializeField]
    public Stats PlayerStats;

    [SerializeField]
    private List<Stat> p_stats;
    // Use this for initialization
    void Start ()
	{
         
	    Create();
	}

    [ContextMenu("Create Player")]
    void Create()
    {
        var knowledge = new Stat("knowledge", 5);
        var guts = new Stat("guts", 4);
        var charm = new Stat("charm", 3);
        var kindness = new Stat("kindness", 2);

        PlayerStats = new Stats(knowledge, guts, charm, kindness);
        p_stats = new List<Stat>(PlayerStats._items.Values); 
    }

    private int modcount = 0;
    public void ModifyRandomStat(string stat)
    {
        var res = PlayerStats.AddModifier(modcount++, new Modifier("add", stat, 2));
        Debug.Log(res);
        onStatModify.Invoke(PlayerStats[stat]);
    }


}
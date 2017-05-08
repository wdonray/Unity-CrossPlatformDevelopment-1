using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShootTest : MonoBehaviour
{
    public int Health;
    public List<Item> inspectorWeapons;
    public List<Item> weapons;
    int weaponindex = 0;
    IExecutable currentWeapon;
    // Use this for initialization
    void Start()
    {
        weapons = new List<Item>();
        foreach(var w in inspectorWeapons)
        {
            var runtimeweapon = Instantiate(w);
            weapons.Add(runtimeweapon);
            runtimeweapon.Initialize(gameObject);
        }    
        currentWeapon = weapons[weaponindex];        
    }

    // Update is called once per frame
    void Update()
    {
        Health = GetComponent<PlayerBehaviour>().stats.GetStat("Health").Value;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentWeapon.Execute();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            weaponindex = (weaponindex == 0) ? 1 : 0;
            currentWeapon = weapons[weaponindex];
        }
    }
}

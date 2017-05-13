using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornTrap : MonoBehaviour
{
    public GenericModifier ThornModConfig;
    private GenericModifier RUNTIME_MOD;
    

    private void Start()
    {
        RUNTIME_MOD = Instantiate(ThornModConfig);
        RUNTIME_MOD.Initialize(null);        
    }

    public void DoDamage(GameObject go)
    {
        Debug.Log("collide with player");
        go.GetComponent<PlayerBehaviour>().ModifyStat(RUNTIME_MOD.EffectedStatType.ToString(), RUNTIME_MOD.TheMod);
        Destroy(gameObject);
    }
}

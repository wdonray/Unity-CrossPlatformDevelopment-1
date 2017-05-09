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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerBehaviour>().ModifyStat(RUNTIME_MOD.EffectedStatType.ToString(), RUNTIME_MOD.TheMod);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {            
            Destroy(gameObject);
        }
    }

}

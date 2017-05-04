using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterBehaviour : MonoBehaviour
{
    
    
    //use this for initialization
    private void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }
}

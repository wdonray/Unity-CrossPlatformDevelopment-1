using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

    public bool IsBlocking;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButton("LeftBumper"))
        {
            IsBlocking = true;
            if(GetComponent<Rigidbody2D>() == null)
            {
                gameObject.AddComponent<Rigidbody2D>();
            }
        }	
        else
        {
            IsBlocking = false;
            if(GetComponent<Rigidbody2D>())
            {
                Destroy(GetComponent<Rigidbody2D>());
            }
        }
	}
}

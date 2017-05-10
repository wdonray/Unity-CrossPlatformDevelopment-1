using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShieldRigidbody : MonoBehaviour
{
    public Vector3 InitalPosition;
    public Quaternion InitialRotation;


    private void Awake()
    {
        InitalPosition = this.transform.localPosition;
        InitialRotation = this.transform.localRotation;
    }

    // Use this for initialization
    void Start ()
    {        
    }
	
	// Update is called once per frame
	void Update ()
    {

	    if(Input.GetButtonDown("LeftBumper"))
        {
            if(GetComponent<Rigidbody2D>() == null)
            {
                gameObject.AddComponent<Rigidbody2D>();
            }
        }	
        else if(Input.GetButtonUp("LeftBumper"))
        {
            if(GetComponent<Rigidbody2D>())
            {
                Destroy(GetComponent<Rigidbody2D>());
                this.transform.localPosition = InitalPosition;
                this.transform.localRotation = InitialRotation;
            }
        }
	}
}

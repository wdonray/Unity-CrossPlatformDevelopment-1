using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawn boxes behaviour
public class GameBehaviour : MonoBehaviour
{    
    public List<GameObject> boxes;   
    
    public GameObject boxPrefab;
	// Use this for initialization
    void Start()
    {
        boxes = new List<GameObject>();
    }
    private void Update()
    {
        GameObject box;
        //because i don't want to do it every frame
        if(Input.GetKeyDown(KeyCode.Space))
        {
            box = Instantiate(boxPrefab) as GameObject;
            boxes.Add(box);
        }
            
    }

}

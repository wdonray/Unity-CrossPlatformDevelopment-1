using System.Collections.Generic;
using UnityEngine;

//spawn boxes behaviour
public class GameBehaviour : MonoBehaviour
{
    public List<GameObject> Boxes;

    public GameObject BoxPrefab;

    // Use this for initialization
    void Start()
    {
        Boxes = new List<GameObject>();
    }

    private void Update()
    {
        //because i don't want to do it every frame
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        var box = Instantiate(BoxPrefab);
        Boxes.Add(box);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicFixBehaviour : MonoBehaviour
{
    public GameBehaviour gameBehaviour;

    private void Start()
    {
        gameBehaviour = GetComponent<GameBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameBehaviour.boxes.ForEach(box => box.GetComponent<Rigidbody>().isKinematic = false);
        }
    }
}
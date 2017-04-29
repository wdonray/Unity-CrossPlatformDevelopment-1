using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterBehaviour : MonoBehaviour
{
    public Color originalColor;
    Material parentMaterial;
    public GameObject CanvasGameObject;

    private void Awake()
    {
        CanvasGameObject = FindObjectOfType<Canvas>().gameObject;
    }
    //use this for initialization
    private void Start()
    {
        parentMaterial = GetComponentInParent<MeshRenderer>().materials[0];
        originalColor = parentMaterial.color;
        //CanvasGameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            parentMaterial.color = Random.ColorHSV();
            CanvasGameObject.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            parentMaterial.color = originalColor;
            CanvasGameObject.SetActive(false);
        }
    }
}

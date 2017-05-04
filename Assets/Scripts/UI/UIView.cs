using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    public GameObject Inventory;

    public GameObject HealthBar;

    public GameObject Dimmer;

    public GameObject PlayerChoices;

    public GameObject Info;

    public GameObject NPC;

    public GameObject Root;

    private List<GameObject> items;

    private void Awake()
    {
        if (items == null) return;
        if (items.Count > 0) items.ForEach(go => go.SetActive(false));
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }
}
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

    private List<GameObject> ui_items;

    private void Awake()
    {
        if (ui_items == null) return;
        if (ui_items.Count > 0) ui_items.ForEach(go => go.SetActive(false));
    }

    public GameObject InventoryGrid;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }
}
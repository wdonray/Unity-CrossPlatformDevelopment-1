using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
///     Controller class for UI
///     Interacts with the UIView and Rest of Game
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField] private BackPackBehaviour backPackBehaviour;

    [SerializeField] private Dropdown dropdownList;

    [SerializeField] public BackPack Inventory;

    [SerializeField] private bool InventoryUp;

    private Vector3 oldInventoryPos;

    public OnCancel onCancel;
    public OnStart onStart;

    public OnStartButton onStartButton;
    public OnSubmit onSubmit;

    [SerializeField] private UIView View;


    private void Awake()
    {
        View = FindObjectOfType<UIView>();
    }

    private void Start()
    {
        onStart.Invoke();
        var ui_gridbehaviour = View.InventoryGrid.GetComponent<UIGridBehaviour>();
        foreach (var item in backPackBehaviour.backPack_config.Items)
            ui_gridbehaviour.SetItem(item);
        backPackBehaviour.onBackPackAddItem.AddListener(ui_gridbehaviour.SetItem);
        var allitems = Resources.LoadAll<Item>("Items");
        var names = new List<string>();
        foreach (var t in allitems)
            names.Add(t.Name);


        dropdownList.AddOptions(names);
        dropdownList.onValueChanged.AddListener(delegate(int id)
        {
            Debug.Log(id + ": selected");
            var item_text = dropdownList.captionText.text;
            var v = ItemFactory.CreateItem(item_text);
            backPackBehaviour.AddToPack(v);
        });

        SetButtonCallbacks();
    }

    private void Update()
    {
        if (GetCancel()) onCancel.Invoke();
        if (GetSubmit()) onSubmit.Invoke();
        if (GetStart()) onStartButton.Invoke();
    }

    private void SetButtonCallbacks()
    {
        var save_button = GameObject.Find("Button-Save").GetComponent<Button>();
        var load_button = GameObject.Find("Button-Load").GetComponent<Button>();
        save_button.onClick.AddListener(delegate { DataController.Save(backPackBehaviour.backPack_config); });
        load_button.onClick.AddListener(delegate { DataController.Load<BackPack>("BackPack-0"); });
    }

    public void InventoryToggle()
    {
        if (!InventoryUp)
        {
            oldInventoryPos = View.Inventory.transform.localPosition;
            View.Inventory.transform.localPosition = new Vector3(0, 1000f, 0);
            InventoryUp = true;
        }

        else
        {
            View.Inventory.transform.localPosition = oldInventoryPos;
            InventoryUp = false;
        }
    }

    public void SetHealthSlider(int val)
    {
        View.HealthSlider.value = val;
    }

    public static bool GetCancel()
    {
        return Input.GetButtonDown("Cancel");
    }

    public static bool GetSubmit()
    {
        return Input.GetButtonDown("Submit");
    }

    public static bool GetStart()
    {
        return Input.GetButtonDown("Start");
    }

    [Serializable]
    public class OnStart : UnityEvent { }

    [Serializable]
    public class OnCancel : UnityEvent { }

    [Serializable]
    public class OnSubmit : UnityEvent { }

    [Serializable]
    public class OnStartButton : UnityEvent { }
}
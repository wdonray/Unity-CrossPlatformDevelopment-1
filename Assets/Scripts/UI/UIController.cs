using System;
using System.Linq;
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

    [SerializeField] public BackPack Inventory;

    [SerializeField] private bool InventoryUp;

    [SerializeField] private Dropdown itemDropdownList;

    public int loadid;

    private Vector3 oldInventoryPos;

    [HideInInspector] public OnCancel onCancel;

    [HideInInspector] public OnStart onStart;

    public OnStartButton onStartButton;

    [HideInInspector] public OnSubmit onSubmit;

    [SerializeField] private Dropdown savesDropdownList;

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
        backPackBehaviour.onBackPackChange.AddListener(ui_gridbehaviour.SetItems);
        var allitems = Resources.LoadAll<Item>("Items");
        var names = new List<string>();
        foreach (var t in allitems)
            names.Add(t._itemName);

        itemDropdownList.ClearOptions();

        itemDropdownList.AddOptions(names);
        itemDropdownList.onValueChanged.AddListener(delegate
        {
            var item_text = itemDropdownList.captionText.text;
            var v = ItemFactory.CreateItem(item_text);
            backPackBehaviour.AddToPack(v);
        });

        SetButtonCallbacks();
        UpdateSavesDropdown();


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
        var clear_button = GameObject.Find("Button-Clear").GetComponent<Button>();

        clear_button.onClick.AddListener( delegate { backPackBehaviour.RemoveAll(); });

        save_button.onClick.AddListener(delegate
        {
            DataController.Save(backPackBehaviour.backPack_runtime, "BackPack");
            UpdateSavesDropdown();
        });

        load_button.onClick.AddListener(delegate
        {
            backPackBehaviour.Initialize(DataController.Load<BackPack>(savesDropdownList.captionText.text));
        });
    }

    public void UpdateSavesDropdown()
    {
        var path = Application.dataPath + "/StreamingAssets/";
        var files = System.IO.Directory.GetFiles(path, "*.json").ToList();

        var names = new List<string>();
        foreach (var f in files)
        {
            var fname = f.Substring(path.Length);
            var nfname = fname.Remove(fname.Length - ".json".Length);
            names.Add(nfname);
        }
        
        
        savesDropdownList.ClearOptions();
        savesDropdownList.AddOptions(names);
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
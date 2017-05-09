using System.Linq;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

public class UIGridBehaviour : MonoBehaviour
{
    public Item _item;
    private GameObject firstAvailable;
    public List<Transform> children = new List<Transform>();
    public List<GameObject> ui_items = new List<GameObject>();
    
    public int Capacity = 16;
    private int numItems = 0;

    private void Start()
    {
        
    }

    public void BackPackUpdated(BackPack backPack)
    {
        ClearItems();

        foreach (var i in backPack.items)
        {
            _item = i;
            SetItem();
        }
    }

    public GameObject FirstAvailable
    {
        get
        {
            if(children.Count <= 0)
                GetComponentsInChildren(true, children);
            //children.ForEach(child => Debug.Log("Child: " + child.name));            
            firstAvailable = children.First(c => c.childCount <= 0 && c.parent == transform).gameObject;
            
            return firstAvailable;
        }
    }
    
    public void SetItem()
    {        
        var newtotal = numItems + 1;
        
        if(newtotal > Capacity)
            return;
        var itemgo = new GameObject("Item", typeof(Image));
        ui_items.Add(itemgo);
        itemgo.transform.SetParent(children[numItems]);
        itemgo.GetComponent<RectTransform>().Stretch();
        itemgo.GetComponent<Image>().sprite = _item.sprite;        
        numItems++;        
    }

    public void SetItem(Item item)
    {
        _item = item;
        SetItem();
    }

    public void ClearItems()
    {
        if(ui_items == null) return;
        if(ui_items.Count <= 0) return;
        if(!Application.isPlaying)
            ui_items.ForEach(DestroyImmediate);
        else
        {
            ui_items.ForEach(Destroy);
        }
        ui_items.Clear();
        numItems = 0;
    }   
}

#if UNITY_EDITOR
[CustomEditor(typeof(UIGridBehaviour))]
public class InspectorUIGridBehaviour : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var mytarget = target as UIGridBehaviour;
        if (GUILayout.Button("Back Pack Update"))
            mytarget.BackPackUpdated(FindObjectOfType<UIController>().backPack);
        if (GUILayout.Button("Set Item"))
            mytarget.SetItem();
        if(GUILayout.Button("Clear Items"))
            mytarget.ClearItems();
    }
}
#endif
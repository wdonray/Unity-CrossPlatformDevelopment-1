using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackPack : MonoBehaviour
{
    public BackPackBase backPackBase;

    public int Capacity = 25;

    private List<Item> items;

    public List<Item> Items
    {
        get { return items; }
    }

    private void Start()
    {
        items = new List<Item>();
        foreach (var i in backPackBase.Items)
        {
            var runtimeitem = Instantiate(i);
            runtimeitem.Initialize(null);
            AddToPack(runtimeitem);

        }
        Capacity = backPackBase.Capacity;
        
    }

    public bool AddToPack(Item item)
    {

        items.Add(item);
        onBackPackChange.Invoke(this);
        return true;
    }

    public bool Remove(Item item)
    {
        if(items.Contains(item))
        {
            items.Remove(item);
            onBackPackChange.Invoke(this);
            return true;
        }

        return false;
    }

    public void PrintItems()
    {
        items.ForEach(item => Debug.Log(item.Name));
    }



    public class OnBackPackChange : UnityEvent<BackPack> { }
    public OnBackPackChange onBackPackChange = new OnBackPackChange();

}
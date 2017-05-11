using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackPackBehaviour : MonoBehaviour
{
    public BackPackBase backPackBase;

    public int Capacity = 25;

    public OnBackPackAddItem onBackPackAddItem = new OnBackPackAddItem();

    public OnBackPackChange onBackPackChange = new OnBackPackChange();

    public List<Item> Items { get; set; }

    void Start()
    {
        Items = new List<Item>();
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
        Items.Add(item);
        onBackPackAddItem.Invoke(item);
        return true;
    }

    public bool Remove(Item item)
    {
        if (Items.Contains(item))
        {
            Items.Remove(item);
            onBackPackChange.Invoke(this);
            return true;
        }

        return false;
    }

    public void PrintItems()
    {
        Items.ForEach(item => Debug.Log(item.Name));
    }


    public class OnBackPackChange : UnityEvent<BackPackBehaviour>
    {
    }

    public class OnBackPackAddItem : UnityEvent<Item>
    {
    }
}
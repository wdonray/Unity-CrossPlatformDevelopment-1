using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{
    public int Capacity = 5;
    [HideInInspector]
    public List<Item> Items = new List<Item>();
    [SerializeField]
    private List<Item> inspectorItems;
    private void Start()
    {
        foreach (var item in inspectorItems)
            item.Initialize(gameObject);
    }

    public bool Add(Item item)
    {
        if (Items.Count < Capacity)
        {
            Items.Add(item);
        }

        return false;
    }

    public bool Remove(Item item)
    {
        if(Items.Contains(item))
        {
            Items.Remove(item);
        }
        return false;
    }

    public void PrintItems()
    {
        Items.ForEach(item => Debug.Log(item.Name));
    }
}
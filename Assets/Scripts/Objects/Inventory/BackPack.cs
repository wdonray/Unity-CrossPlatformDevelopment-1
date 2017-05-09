using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackPack : MonoBehaviour
{
    public BackPackBase backPackBase;

    public int Capacity = 25;

    public List<Item> items = new List<Item>();

    private void Awake()
    {
        foreach (var item in backPackBase.Items)
        {
            items.Add(Instantiate(item));
        }
        Capacity = backPackBase.Capacity;
    }

    private void Start()
    {
        onBackPackChange.Invoke(this);
    }

    [System.Serializable]
    public class OnBackPackChange : UnityEvent<BackPack> { }
    public OnBackPackChange onBackPackChange = new OnBackPackChange();

    public bool Add(Item item)
    {
        if (items.Count < items.Capacity)
        {
            items.Add(item);
            onBackPackChange.Invoke(this);
            return true;
        }

        return false;
    }

    public bool Remove(Item item)
    {
        if (items.Contains(item))
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
}
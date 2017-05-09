using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackPack : MonoBehaviour
{
    public BackPackBase backPackBase;
    public UnityAction<BackPack> backPackUpdateEvent;

    private void Awake()
    {
        backPackUpdateEvent = FindObjectOfType<UIGridBehaviour>().BackPackUpdated;
        backPackBase = (BackPackBase)Resources.Load("Items/BackPackPrefs");
        backPackUpdateEvent.Invoke(this);
    }

    public bool Add(Item item)
    {
        if (backPackBase.Items.Count < backPackBase.Capacity)
        {
            backPackBase.Items.Add(item);
            backPackUpdateEvent.Invoke(this);
        }

        return false;
    }

    public bool Remove(Item item)
    {
        if (backPackBase.Items.Contains(item))
        {
            backPackBase.Items.Remove(item);
            backPackUpdateEvent.Invoke(this);
        }

        return false;
    }

    public void PrintItems()
    {
        backPackBase.Items.ForEach(item => Debug.Log(item.Name));
    }
}
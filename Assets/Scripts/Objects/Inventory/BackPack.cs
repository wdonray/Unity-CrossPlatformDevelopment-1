using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "BackPackPrefs", menuName = "Item/BP")]
public class BackPack : ScriptableObject
{
    public int Capacity = 25;

    [SerializeField]
    public List<Item> INSPECTOR_Items = new List<Item>();


    public List<Item> Items
    {
        get { return INSPECTOR_Items; }
    }
}
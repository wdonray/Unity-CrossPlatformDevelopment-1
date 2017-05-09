using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "BackPackPrefs", menuName = "Item/BP")]
public class BackPackBase : ScriptableObject
{
    public int Capacity = 25;

    public List<Item> Items = new List<Item>();

}
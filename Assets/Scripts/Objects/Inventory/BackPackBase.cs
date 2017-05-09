using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "BackPackPrefs", menuName = "Item/BP")]
public class BackPackBase : ScriptableObject
{
    public int Capacity = 25;

    public List<Item> Items = new List<Item>();

}
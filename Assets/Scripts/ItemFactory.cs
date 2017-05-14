using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR

#endif

public class ItemFactory : MonoBehaviour
{
    [ItemFactory] private static Dictionary<string, Item> _itemDataBase;
    private static GameObject _itemPrefab;

    public static int itemsCreated = 0;

    public List<string> values;

    private void Awake()
    {
        var items = Resources.LoadAll<Item>("Items");
        _itemDataBase = new Dictionary<string, Item>();
        foreach (var item in items)
        {
            Item val;
            if (!_itemDataBase.TryGetValue(item.Name, out val))
                _itemDataBase.Add(item.Name, item);
        }

        _itemPrefab = Resources.Load("ItemPrefabResource") as GameObject;
        values = new List<string>();
        values.AddRange(_itemDataBase.Keys);
    }

    public static Item CreateItem(string itemName)
    {
        Item val;
        if (_itemDataBase.TryGetValue(itemName, out val))
        {
            var clone = Instantiate(_itemPrefab);
            var itembehaviour = clone.GetComponent<ItemBehaviour>();
            itembehaviour.item = val;
            itembehaviour.Initialize();
            Debug.LogFormat("created {0}", val.Name);
        }
        else
        {
            Debug.LogFormat("can not create {0}", itemName);
        }
        return val;
    }
}
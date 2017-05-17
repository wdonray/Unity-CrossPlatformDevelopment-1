﻿using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName ="DropTable")]
public class LootTable : ScriptableObject
{
    public List<ItemDrop> ItemDrops = new List<ItemDrop>();

    [Serializable]
    public class ItemDrop
    {
        [Range(0, 1)] public float chance;

        public Item item;
    }

    [SerializeField]
    float randomroll;
    /// <summary>
    /// calculate the items that will be dropped
    /// </summary>
    /// <returns> the list of items based on their chance </returns>
    public List<Item> GetDrops()
    {
        var items = new List<Item>();
        randomroll = UnityEngine.Random.Range(0f, 1f);
        foreach (var itemdrop in ItemDrops)
        {
            if (itemdrop.chance > randomroll)
                items.Add(itemdrop.item);
        }
        return items;
    }

#if UNITY_EDITOR

    [CustomEditor(typeof(LootTable))]
    public class InspectorLootTable : Editor
    {
        string result = "";
        public override void OnInspectorGUI()
        {
            
            var mytarget = target as LootTable;
       
            if(GUILayout.Button("DROP ITEMS", GUILayout.ExpandWidth(false)))
            {
        
                var randomdrops = mytarget.GetDrops();
                if (randomdrops == null)
                {
                    result = "randomdrops is null";
                }
                else
                {
                    result = "";
                    randomdrops.ForEach(d => result += "," + d.name);
                }
            }
            EditorGUILayout.LabelField("result", result);

            base.OnInspectorGUI();
        }
     
    }
#endif
}
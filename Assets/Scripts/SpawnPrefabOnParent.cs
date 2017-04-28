using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabOnParent : MonoBehaviour
{
    public void Start()
    {
        FindObjectOfType<PlayerBehaviour>().onStatModify.AddListener(UpdateItem);
    }
    public GameObject prefab;

    public Transform parent;

    public void SpawnPrefab(RPGStats.Stat s)
    {
        var go = Instantiate(prefab, parent);
        var texts = go.GetComponentsInChildren<UnityEngine.UI.Text>();
        texts[0].text = s.Name;
        go.name = s.Name;
        texts[1].text = s.Value.ToString();
    }

    public void SpawnAllItems()
    {
        var items = FindObjectOfType<PlayerBehaviour>().PlayerStats._items.Values;
        foreach(var item in items) SpawnPrefab(item);
    }

    public void UpdateItem(RPGStats.Stat s)
    {
        Destroy(GameObject.Find(s.Name));
        SpawnPrefab(s);
    }
}

using System.Collections;
using System.Collections.Generic;
using ScriptableAssets;
using UnityEngine;
using Stats = ScriptableAssets.Stats;

public class SpawnPrefabOnParent : MonoBehaviour
{
    public List<GameObject> uiStats;

    public void Start()
    {
        uiStats = new List<GameObject>();
        PlayerBehaviour.Instance.onStatModify.AddListener(SpawnAllItems);
    }

    public GameObject prefab;

    public Transform parent;

    private GameObject SpawnPrefab(Stat s)
    {
        var go = Instantiate(prefab, parent);
        var texts = go.GetComponentsInChildren<UnityEngine.UI.Text>();
        texts[0].text = s.Name.ToString();
        go.name = s.Name.ToString();
        texts[1].text = s.Value.ToString();
        return go;
    }
    
    public void SpawnAllItems()
    {
        var items = PlayerBehaviour.Instance.stats.Items.Values;
        foreach (var i in items)
            Debug.Log(string.Format("name {0}, value {1}",i.Name, i.Value));
        uiStats.ForEach(go => Destroy(go));
        uiStats.Clear();
        foreach(var item in items)
            uiStats.Add(SpawnPrefab(item));
    }
 
}

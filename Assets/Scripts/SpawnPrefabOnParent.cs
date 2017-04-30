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
    
    public void SpawnAllItems<T>(List<T> items)
    {
        uiStats.ForEach(go => Destroy(go));
        uiStats.Clear();
    }
 
}

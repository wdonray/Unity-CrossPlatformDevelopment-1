using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviour : MonoBehaviour
{
    public int dims = 5;
    public GameObject prefab;
    public List<GameObject> gameObjects;
    public float offset = 1;

    [ContextMenu("Create")]
    void Create()
    {
        gameObjects = new List<GameObject>();
        for(int x = 0; x < dims; x++)
        {
            for(int z = 0; z < dims; z++)
            {
                var pos = new Vector3(x * offset, 0, z * offset);
                var go = Instantiate(prefab);
                go.transform.SetParent(transform);
                go.transform.localPosition = pos;
                gameObjects.Add(go);
            }
        }
    }

    [ContextMenu("Destroy")]
    void DestroyGrid()
    {
        gameObjects.ForEach(go => DestroyImmediate(go));
        gameObjects.Clear();
    }
}

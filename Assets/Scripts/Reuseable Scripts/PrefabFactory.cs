using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PrefabFactory : MonoBehaviour {

    [SerializeField]protected GameObject prefab;
    [SerializeField]protected List<GameObject> objectPool;
    protected abstract void SpawnPrefab();
    protected abstract void AddToPool(GameObject go);
    protected abstract void RemoveFromPool(GameObject go);
}

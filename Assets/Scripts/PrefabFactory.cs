using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PrefabFactory : MonoBehaviour {

    [SerializeField]protected GameObject prefab;
    protected List<GameObject> objectPool;
    protected abstract void SpawnPrefab();	
}

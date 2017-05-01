using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFactory : PrefabFactory
{
    public int maxCats = 5;
    public float timer = 2f;

    private void Start()
    {
        objectPool = new List<GameObject>();
    }
    protected override void SpawnPrefab()
    {
        var go = Instantiate(prefab, transform);
        go.transform.localPosition = Vector3.zero;
        objectPool.Add(go);
        go.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 5f), ForceMode2D.Force);
    }

    private void Update()
    {
        if(objectPool.Count > maxCats)
            return;
        if(timer <= 0)
        {
            SpawnPrefab();
            timer = 2f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}

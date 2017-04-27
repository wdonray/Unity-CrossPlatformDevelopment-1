using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    private float timer = 1.0f;

    public void Update()
    {
        if (timer < 0)
            Destroy(gameObject);
        timer -= Time.deltaTime;
    }
}

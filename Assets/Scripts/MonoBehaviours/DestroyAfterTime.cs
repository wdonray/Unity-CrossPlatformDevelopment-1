using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    float time = 1.0f;

    void Update()
    {
        if (time < 0)
            Destroy(gameObject);
        time -= Time.deltaTime;
    }
}
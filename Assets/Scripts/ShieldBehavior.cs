using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public Vector3 InitalPosition;
    public Quaternion InitialRotation;
    public List<GameObject> ObjectsInCollision;
    public List<GameObject> IgnoredColliders;
    public GameObject RootObject;

    public ShieldConfig _ShieldConfig;

    public void Initialize()
    {
        InitalPosition = this.transform.localPosition;
        InitialRotation = this.transform.localRotation;
        ObjectsInCollision = new List<GameObject>();

        IgnoredColliders.Add(RootObject);

        foreach (var collider in RootObject.GetComponentsInChildren<Collider2D>())
        {
            if (collider != this.GetComponent<Collider2D>())
            {
                IgnoredColliders.Add(collider.gameObject);
            }
        }
    }
    
    public void DoBlock(GameObject go)
    {
        if (IgnoredColliders.Contains(go))
            return;
        if (GetComponent<Rigidbody2D>())
            return;
        this.gameObject.AddComponent<Rigidbody2D>();
        _ShieldConfig.Block();
    }

    public void DestroyRigidBody(GameObject go)
    {
        if (IgnoredColliders.Contains(go))
            return;
        if (GetComponent<Rigidbody2D>())
            Destroy(this.GetComponent<Rigidbody2D>());
    }
    
}

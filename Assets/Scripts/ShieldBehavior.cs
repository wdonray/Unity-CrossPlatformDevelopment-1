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

    private void Awake()
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

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = ObjectsInCollision.Count - 1; i >= 0; i--)
        {
            if (ObjectsInCollision[i] == null)
                ObjectsInCollision.RemoveAt(i);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ObjectsInCollision.Contains(collision.gameObject))
            return;

        if (IgnoredColliders.Contains(collision.gameObject))
            return;

        ObjectsInCollision.Add(collision.gameObject);
        if (GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (ObjectsInCollision.Contains(collision.gameObject))
            ObjectsInCollision.Remove(collision.gameObject);
        if (ObjectsInCollision.Count == 0)
        {
            if (GetComponent<Rigidbody2D>())
            {
                Destroy(GetComponent<Rigidbody2D>());
                this.transform.localPosition = InitalPosition;
                this.transform.localRotation = InitialRotation;
            }
        }
    }
}

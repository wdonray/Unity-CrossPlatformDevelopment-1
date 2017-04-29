using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerInputBehaviour : MonoBehaviour
{ 
    Rigidbody rb;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var move = new Vector3(h, 0, v);

        rb.velocity = move * speed;
        if(rb.velocity.magnitude > 15f)
            rb.velocity = rb.velocity.normalized;
    }
}

using UnityEngine;

[System.Serializable]
public class PlayerInputBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    private SpriteRenderer sr;

    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public Vector3 Move
    {
        get; set;
    }

    private void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        Move = new Vector3(h, v, 0);
        transform.position += Move * speed * Time.deltaTime;
               
        
    }
}

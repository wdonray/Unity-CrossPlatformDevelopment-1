using UnityEngine;

[System.Serializable]
public class PlayerInputBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public float speed = 15f;    
    public Vector3 velocity;
 
    void Start()
    {        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public Vector3 Move
    {
        get; set;
    }
    public Vector3 startScale;
    
    private void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        Move = new Vector3(h, v, 0);

        var dir = Move.normalized;

        velocity = dir * speed;

        var dot = Vector3.Dot(dir, transform.right);
        if(_rigidbody2D.velocity.magnitude > 0)
        {
            if(h < 0)
                SetScaleX(transform, -.5f);
            else if(h > 0)
                SetScaleX(transform, .5f);
        }

        _rigidbody2D.velocity = new Vector3(Move.x * speed, _rigidbody2D.velocity.y, 0);
    }

    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Fire1"))
            print("fire1"); //a key
        if(Input.GetButtonDown("Fire2"))
            print("fire2"); //b key
        if(Input.GetButtonDown("Fire3"))
            print("fire3");        //x key            
        if(Input.GetAxis("Slide") > 0)
        {
            print("Slide" + " :: " + Input.GetAxis("Slide")); //r trigger axis 10
            _animator.SetTrigger("slide");
        }
            
        if(Input.GetAxis("Block") > 0)
            print("Block" +" :: "+ Input.GetAxis("Block"));
    }

    private void OnAnimatorMove()
    {        
        if(_animator.deltaPosition.magnitude > 0)
            Debug.Log("Player: " + transform.position);
    }

    public static void SetScaleX(Transform t, float val)
    {
        var scale = t.localScale;
        scale.x = val;
        t.localScale = scale;
    }
}

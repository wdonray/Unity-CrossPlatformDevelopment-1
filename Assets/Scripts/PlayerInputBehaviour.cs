using UnityEngine;

[System.Serializable]
public class PlayerInputBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public float speed = 15f;
    public Vector3 velocity;
    public float scaleF;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        scaleF = transform.localScale.x;
        
    }

    public Vector3 Move
    {
        get; set;
    }
    public Vector3 startScale;

    private void Update()
    {
        if(blockinput)
            return;
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        Move = new Vector3(h, v, 0);

        var dir = Move.normalized;

        velocity = dir * speed;

        var dot = Vector3.Dot(dir, transform.right);
        if(_rigidbody2D.velocity.magnitude > 0)
        {
            if(h < 0)
                SetScaleX(transform, -scaleF);
            else if(h > 0)
                SetScaleX(transform, scaleF);
        }
        if(Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.AddForce(new Vector2(0, jumpPower * 25f));
             _animator.SetTrigger("jump");

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
            _animator.SetTrigger("punch");        //x key            
        if(Input.GetAxis("Slide") > 0)
        {
            //r trigger axis 10
            _animator.SetTrigger("slide");
        }

        if(Input.GetAxis("Block") > 0)
            print("Block" + " :: " + Input.GetAxis("Block"));
       
            
    }
    public float jumpPower = 5f;
    public bool blockinput = false;
    private void OnAnimatorMove()
    {
        blockinput = true;
        transform.position = _animator.rootPosition;
        if(_animator.deltaPosition.magnitude < .01f)
            blockinput = false;
    }

    public static void SetScaleX(Transform t, float val)
    {
        var scale = t.localScale;
        scale.x = val;
        t.localScale = scale;
    }
}

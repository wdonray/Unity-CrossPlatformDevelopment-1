using UnityEngine;

[System.Serializable]
public class PlayerInputBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public float speed = 15f;
    public Vector3 velocity;
    public float scaleF;
    public Vector3 startScale;
    public float jumpPower = 600f;
    public bool blockinput = false;

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
            if(dot < 0)
                SetScaleX(transform, -scaleF);
            else if(dot > 0)
                SetScaleX(transform, scaleF);
        }
        

        _rigidbody2D.velocity = new Vector3(Move.x * speed, _rigidbody2D.velocity.y, 0);

        
    }

    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger("kick");
            blockinput = true;
        }
            
        if(Input.GetButtonDown("Fire2"))
        {

        }
            

        if(Input.GetButtonDown("Fire3"))
        {
            _animator.SetTrigger("punch");        //x key            
            blockinput = true;
        }
            
        if(Input.GetAxis("Slide") > 0)
        {         
            _animator.SetTrigger("slide");   //r trigger axis 10
        }

        if(Input.GetAxis("Block") > 0)
            print("Block" + " :: " + Input.GetAxis("Block"));
        if(Input.GetButtonDown("Jump"))
        {
            _animator.SetTrigger("jump");
            _rigidbody2D.AddForce(new Vector2(0, jumpPower));
        }

    }
    
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

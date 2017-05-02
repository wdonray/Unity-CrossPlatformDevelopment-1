using UnityEngine;

[System.Serializable]
public class PlayerInputBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator m_anim;
    static readonly int CROUCHING = Animator.StringToHash("crouch");
    public float speed = 15f;
    public Vector3 velocity;
    public float scaleF;
    public Vector3 startScale;
    public float jumpPower = 600f;
    public bool blockinput = false;
    public bool crouching = false;
    public bool jumping = false;
    public bool grounded = false;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        scaleF = transform.localScale.x;
        
    }
    float leftfootheight;
    private void Update()
    {
        if(blockinput)
            return;
        
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var move = new Vector3(h, v, 0);

        crouching = v < 0;
        m_anim.SetBool(CROUCHING, crouching);       

        var dir = move.normalized;

        velocity = dir * speed;

        var dot = Vector3.Dot(dir, transform.right);

        if(_rigidbody2D.velocity.magnitude > 0)
        {
            if(dot < 0)
                SetScaleX(transform, -scaleF);
            if(dot > 0)
                SetScaleX(transform, scaleF);
        }

        _rigidbody2D.velocity = new Vector3(move.x * speed, _rigidbody2D.velocity.y, 0);
    }

    public bool Move(Vector3 velocity, bool grounded, bool crouching, bool jumping)
    {        
        return true;
    }

    private void FixedUpdate()
    {       
        if(Input.GetButtonDown("Fire1"))
        {
            m_anim.SetTrigger("kick");
            blockinput = true;
        }
            
        if(Input.GetButtonDown("Fire2")){}
            

        if(Input.GetButtonDown("Fire3"))
        {
            m_anim.SetTrigger("punch");        //x key            
            blockinput = true;
        }
            
        if(Input.GetAxis("Slide") > 0)
        {         
            m_anim.SetTrigger("slide");   //r trigger axis 10
        }

        if(Input.GetAxis("Block") > 0)
            print("Block" + " :: " + Input.GetAxis("Block"));
        if(Input.GetButtonDown("Jump"))
        {
            m_anim.SetBool("jump", true);
            //if(!m_anim.GetBool("crouch"))
            //    _rigidbody2D.AddForce(new Vector2(0, jumpPower));
        }
    }
    
    private void OnAnimatorMove()
    {
        blockinput = true;
        transform.position = m_anim.rootPosition;
        if(m_anim.deltaPosition.magnitude < .01f)
            blockinput = false;
        leftfootheight = m_anim.leftFeetBottomHeight;
    }

    public static void SetScaleX(Transform t, float val)
    {
        var scale = t.localScale;
        scale.x = val;
        t.localScale = scale;
    }
}

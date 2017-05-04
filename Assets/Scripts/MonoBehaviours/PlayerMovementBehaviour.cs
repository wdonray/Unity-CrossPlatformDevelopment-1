using UnityEngine;

[System.Serializable]
public class PlayerMovementBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator m_anim;

    internal static readonly int HORIZONTAL = Animator.StringToHash("horizontal");
    internal static readonly int VERTICAL = Animator.StringToHash("vertical");

    [Range(0, 100)]
    public float speed = 15f;

    public float crouchspeed = 5f;

    private Vector3 velocity;

    private float scaleF;
    
    public float jumpPower = 600f;
    private bool _rootMotion = false;
    private PlayerInput _playerInput;
    private Vector3 lookat;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        scaleF = transform.localScale.x;
        _playerInput = GetComponent<PlayerInput>();

    }
    public GameObject IKSpine;
    private void Update()
    {        
        if(_rootMotion)
            return;

        lookat = new Vector3(PlayerInput.RightStick.x, PlayerInput.RightStick.y, 0);
        Debug.DrawLine(transform.position, transform.position + lookat * 15f, Color.blue);
        var move = new Vector3(PlayerInput.LeftStick.x, PlayerInput.LeftStick.y, 0);       
        var dir = move.normalized;
        velocity = dir * speed;

        m_anim.SetFloat(HORIZONTAL, PlayerInput.RightStick.x);
        m_anim.SetFloat(VERTICAL, PlayerInput.RightStick.y);


        if(PlayerInput.UserControl)
        {
            if(_rigidbody2D.velocity.magnitude > 0)
            {
                var dot = Vector3.Dot(dir, transform.right);

                if(dot < 0 || PlayerInput.RightStick.x < 0)
                    SetScaleX(transform, -scaleF);
                else if(dot > 0 || PlayerInput.RightStick.x > 0)
                    SetScaleX(transform, scaleF);
                



            }


            _rigidbody2D.velocity = new Vector3(move.x * speed, _rigidbody2D.velocity.y, 0);
        }

    }

    private void OnAnimatorMove()
    {
        transform.position = m_anim.rootPosition;
        _rootMotion = (m_anim.deltaPosition.magnitude > 0);
    }


    public static void SetScaleX(Transform t, float val)
    {
        var scale = t.localScale;
        scale.x = val;
        t.localScale = scale;
    }
    public static void SetScaleY(Transform t, float val)
    {
        var scale = t.localScale;
        scale.x = val;
        t.localScale = scale;
    }
}



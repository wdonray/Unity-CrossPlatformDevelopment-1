using UnityEngine;

[System.Serializable]
public class PlayerInputBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator m_anim;
    public float speed = 15f;
    public Vector3 velocity;
    public float scaleF;
    public Vector3 startScale;
    public float jumpPower = 600f;
    public bool _rootMotion = false;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        scaleF = transform.localScale.x;        
    }

    private void Update()
    {
        if(_rootMotion)
            return;

        var h = Input.GetAxis("LeftHorizontal");
        var v = Input.GetAxis("LeftVertical");
        var rh = Input.GetAxis("RightHorizontal");
        var lh = Input.GetAxis("LeftHorizontal");
        var move = new Vector3(h, v, 0);

        


        if(PlayerAnimator.isBlocking)
            speed = 2.5f;
        else
            speed = 15f;

        var dir = move.normalized;
        velocity = dir * speed;

        if(_rigidbody2D.velocity.magnitude > 0)
        {
            var dot = Vector3.Dot(dir, transform.right);

            if(dot < 0)
                SetScaleX(transform, -scaleF);
            if(dot > 0)
                SetScaleX(transform, scaleF);
        }

        _rigidbody2D.velocity = new Vector3(move.x * speed, _rigidbody2D.velocity.y, 0);

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



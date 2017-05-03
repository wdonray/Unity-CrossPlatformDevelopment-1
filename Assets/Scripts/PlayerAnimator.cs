using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimator : MonoBehaviour
{
    static readonly int KICK = Animator.StringToHash("kick");
    static readonly int BLOCK = Animator.StringToHash("block");
    static readonly int SLIDE = Animator.StringToHash("slide");
    static readonly int BSLIDE = Animator.StringToHash("backslide");
    static readonly int SWING = Animator.StringToHash("swing");
    static readonly int PUNCH = Animator.StringToHash("punch");
    static readonly int JUMP = Animator.StringToHash("jump");
    static readonly int CROUCH = Animator.StringToHash("crouch");
    static readonly int SPEED = Animator.StringToHash("Speed");
    static readonly int SWINGEXIT = Animator.StringToHash("swing_exit");
    public Transform elbow_left;
    public Transform elbow_right;
    Animator m_anim;
    public GameObject shield;
    public Vector3 shield_start_pos;
    Attachment shieldAttachment;
    public Transform spine;
    Attachment swordAttachment;

    public GameObject weapon;
    public Vector3 weapon_start_pos;
    public Transform wrist_left;
    public Transform wrist_right;

    public static bool isBlocking
    {
        get { return Input.GetButton("LeftBumper"); }
    }

    static bool isCrouching
    {
        get { return Input.GetAxis("Vertical") < 0; }
    }

    void Start()
    {
        shieldAttachment = new Attachment(shield);
        swordAttachment = new Attachment(weapon);
        m_anim = GetComponent<Animator>();

        swordAttachment.Revert();
        shieldAttachment.Revert();
    }
    
    public static void FlipX(Transform t)
    {
        var scale = t.localScale;
        scale.x = t.localScale.x * -1f;
        t.localScale = scale;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            m_anim.SetTrigger(KICK);

        if (Input.GetButtonDown("Fire2"))
            m_anim.SetTrigger(SWING); //x key          

        if (Input.GetButtonDown("Fire3"))
            m_anim.SetTrigger(PUNCH); //x key            

        if (Input.GetButton("LeftBumper"))
            m_anim.SetTrigger(BLOCK);

        if (Input.GetButtonDown("Jump"))
            m_anim.SetTrigger(JUMP);

        if (m_anim.GetBool("swinging"))
        {
            if(!swordAttachment.attached)
                swordAttachment.Attach(wrist_left);
            if(!shieldAttachment.attached)
                shieldAttachment.Attach(elbow_right);
        }
        else
        {
            swordAttachment.Revert();
            shieldAttachment.Revert();
        }

        m_anim.SetFloat(BSLIDE, Input.GetAxis("bSlide")); //r trigger axis 10                                    
        m_anim.SetFloat(SLIDE, Input.GetAxis("fSlide")); //r trigger axis 10                                    
        m_anim.SetBool(BLOCK, isBlocking);
        m_anim.SetBool(CROUCH, isCrouching);
    }

    public interface IAttachable
    {
        void Attach(Transform target);
        void Detach();
        void Revert();
    }

    public class TransformCopy
    {
        public Vector3 localPosition;
        public Quaternion localRotation;
        public Vector3 localScale;

        public TransformCopy(Transform t)
        {
            localPosition = t.localPosition;
            localRotation = t.localRotation;
            localScale = t.localScale;
        }
    }

    [Serializable]
    public class Attachment : IAttachable
    {
        readonly TransformCopy _copy;
        readonly GameObject _gameObject;
        readonly Transform _origin;
        public bool attached = false;
        public UnityEvent OnWeaponAttached;

        public Attachment(GameObject original)
        {
            OnWeaponAttached = new UnityEvent();
            _gameObject = original;
            _origin = _gameObject.transform.parent;
            _copy = new TransformCopy(_gameObject.transform);
        }

        public void Attach(Transform target)
        {
            _gameObject.transform.SetParent(target);
            _gameObject.transform.localPosition = Vector3.zero;
            _gameObject.transform.localRotation = Quaternion.identity;
            FlipX(_gameObject.transform);
            if(OnWeaponAttached != null)
                OnWeaponAttached.Invoke();
            attached = true;
        }

        public void Detach()
        {
            _gameObject.transform.SetParent(null);
        }

        public void Revert()
        {
            attached = false;
            _gameObject.transform.SetParent(_origin);
            _gameObject.transform.localPosition = _copy.localPosition;
            _gameObject.transform.localRotation = _copy.localRotation;
            _gameObject.transform.localScale = _copy.localScale;

        }
    }
}
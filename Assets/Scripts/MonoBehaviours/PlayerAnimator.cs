using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimator : MonoBehaviour
{
    static readonly int KICKTRIGGER = Animator.StringToHash("kick");
    static readonly int BLOCKING = Animator.StringToHash("block");
    static readonly int FRONTSLIDE = Animator.StringToHash("slide");
    static readonly int BACKSLIDE = Animator.StringToHash("backslide");
    static readonly int SWINGTRIGGER = Animator.StringToHash("swing");
    static readonly int PUNCHTRIGGER = Animator.StringToHash("punch");
    static readonly int JUMPTRIGGER = Animator.StringToHash("jump");
    static readonly int CROUCHING = Animator.StringToHash("crouch");
    static readonly int ANIMSPEED = Animator.StringToHash("Speed");

    public Transform elbow_left;
    public Transform elbow_right;
    public Transform spine;
    public Transform wrist_left;
    public Transform wrist_right;

    private Animator m_anim;
    public GameObject offHand;
    public GameObject mainHand;

    Attachment shieldAttachment;
    Attachment swordAttachment;

    IAttachable currentWeapon;
    IAttachable currentOffhand;

    void Start()
    {
        shieldAttachment = new Attachment(offHand);
        swordAttachment = new Attachment(mainHand);
        currentWeapon = swordAttachment;
        currentOffhand = shieldAttachment;
        m_anim = GetComponent<Animator>();

        currentWeapon.Revert();
        currentOffhand.Revert();
        //shieldAttachment.OnWeaponAttached.AddListener(() => GetComponent<AudioSource>().Play());
    }

    public void SetWeapons(bool on)
    {
        if(on)
        {
            currentWeapon.Attach(wrist_left);
            currentOffhand.Attach(elbow_right);
            offHand.transform.FlipX();
            return;
        }

        currentWeapon.Revert();
        currentOffhand.Revert();
    }

    void Update()
    {
        if(PlayerInput.isInputBlock)
        {
            PlayerInput.UserControl = true;
            SetWeapons(false);
        }
            
        if(!PlayerInput.UserControl)
            return;

        if(Input.GetButtonDown(Strings.RIGHTBUMPER))
            m_anim.SetTrigger(KICKTRIGGER);

        if(Input.GetButtonDown(Strings.XBOX_Y))
            m_anim.SetTrigger(SWINGTRIGGER); //x key          

        if(Input.GetButtonDown(Strings.XBOX_X))
            m_anim.SetTrigger(PUNCHTRIGGER); //x key            

        if(Input.GetButton(Strings.LEFTBUMPER))
            m_anim.SetTrigger(BLOCKING);

        if(Input.GetButtonDown(Strings.JUMP))
            m_anim.SetTrigger(JUMPTRIGGER);


        m_anim.SetFloat(BACKSLIDE, Input.GetAxis(Strings.BSLIDE)); //r trigger axis 10                                    
        m_anim.SetFloat(FRONTSLIDE, Input.GetAxis(Strings.FSLIDE)); //r trigger axis 10                                    
        m_anim.SetBool(BLOCKING, PlayerInput.isInputBlock);
        m_anim.SetBool(CROUCHING, PlayerInput.isInputCrouch);
    }

}
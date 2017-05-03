using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator m_anim;

    static readonly int KICK = Animator.StringToHash("kick");
    static readonly int BLOCK = Animator.StringToHash("block");
    static readonly int SLIDE = Animator.StringToHash("slide");
    static readonly int SWING = Animator.StringToHash("swing");
    static readonly int PUNCH = Animator.StringToHash("punch");
    static readonly int JUMP = Animator.StringToHash("jump");
    static readonly int CROUCH = Animator.StringToHash("crouch");
    static readonly int SPEED = Animator.StringToHash("speed");
    static readonly int SWINGEXIT = Animator.StringToHash("swing_exit");

    public GameObject weapon;
    public GameObject shield;
    public Transform wrist_right;
    public Transform wrist_left;
    public Transform spine;
    public Vector3 weapon_start_pos;
    public Quaternion weapon_start_rot;
    private void Start()
    {
        m_anim = GetComponent<Animator>();
        weapon_start_pos = weapon.transform.localPosition;
        weapon_start_rot = weapon.transform.localRotation;
    }

    public static bool isBlocking
    {
        get { return Input.GetButton("LeftBumper"); }
    }
    static bool isCrouching
    {
        get { return Input.GetAxis("Vertical") < 0; }
    }

    void AttachWeapon(GameObject weapon)
    {
        weapon.transform.SetParent(wrist_left.transform);       
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        PlayerInputBehaviour.SetScaleX(weapon.transform, 7f);
    }

    void ResetWeapon(GameObject weapon)
    {        
        weapon.transform.SetParent(spine.transform);
        weapon.transform.localPosition = weapon_start_pos;
        weapon.transform.localRotation = Quaternion.identity;
        PlayerInputBehaviour.SetScaleX(weapon.transform, -7f);

    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            m_anim.SetTrigger(KICK);
        }

        if(Input.GetButtonDown("Fire2"))
        {
            //parent            

            //reset the rot then scale
            m_anim.SetTrigger(SWING);        //x key          
        }

        if(Input.GetButtonDown("Fire3"))
        {
            m_anim.SetTrigger(PUNCH);        //x key            
        }

        if(Input.GetAxis("Slide") > 0)
        {
            m_anim.SetTrigger(SLIDE);   //r trigger axis 10
        }

        if(Input.GetButton("LeftBumper"))
        {
            m_anim.SetTrigger(BLOCK);
        }

        if(Input.GetButtonDown("Jump"))
        {
            m_anim.SetTrigger(JUMP);
        }

        if(m_anim.GetBool("swinging"))
            AttachWeapon(weapon);
        else
            ResetWeapon(weapon);
        m_anim.SetBool(BLOCK, isBlocking);
        m_anim.SetBool(CROUCH, isCrouching);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;   
    private PlayerInputBehaviour playerInput;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInputBehaviour>();
    }

    private void Update()
    {
        
    }
}

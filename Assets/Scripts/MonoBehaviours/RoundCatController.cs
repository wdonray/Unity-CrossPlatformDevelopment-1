using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCatController : MonoBehaviour {

    public bool walk = false;
    Animator _animator;
    public Transform FollowTarget;
    public bool FollowPlayer = true;
    public float FollowDistance;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        if(FollowPlayer)
            FollowTarget = GameObject.FindGameObjectWithTag("Player").transform;

    }
    [SerializeField]float dist;
    private void Update()
    {
        if(FollowTarget.position.x < transform.position.x)
            transform.localScale = new Vector3(-.5f, .5f, 0);
        else
            transform.localScale = new Vector3(.5f, .5f, 0);
        dist = Vector3.Distance(transform.position, FollowTarget.position);
        if(dist > FollowDistance * 1.5f)
            _animator.SetFloat("speed", 1.5f);
        else
            _animator.SetFloat("speed", 1f);
       _animator.SetBool("walk", dist > FollowDistance);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            _animator.SetBool("walk", false);
    }
}

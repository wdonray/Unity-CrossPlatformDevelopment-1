using UnityEngine;
using System.Collections;
  
public class CharacterMotion2D : MonoBehaviour
{
    void Update()
    {


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        var inputmove = new Vector3(h, v);

        var dir = (forcemove) ? velocity.normalized : inputmove.normalized;

        velocity = dir * speed;

       

        var dot = Vector3.Dot(dir, Vector3.right);

        if(dot > 0) transform.localScale *= -1;


        if(Input.GetButtonDown("Fire1"))
            animator.SetTrigger("punch");
        if(Input.GetButtonDown("Fire2"))
            animator.SetTrigger("slide");

    }


    public bool forcemove = false;
    public Vector3 velocity;
    public Transform target;

    [SerializeField]
    float speed = 5f;


    [SerializeField]
    Animator animator;

}

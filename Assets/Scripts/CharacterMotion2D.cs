using UnityEngine;
using System.Collections;
namespace Player2
{
    public enum PlayerState
    {
        init = 0,
        idle = 1,
        dragging = 2,
        dead = 3,
    }
    public class CharacterMotion2D : MonoBehaviour
    {
        void Awake()
        {            
            currentstate = PlayerState.init;
        }

        void Start()
        {
            currentstate = PlayerState.idle;
            animator = GetComponent<Animator>();
        }

        public static void ChangeState(PlayerState state)
        {
            
        }
        private void SetKinematic(RigidbodyType2D state)
        {
            GetComponent<Rigidbody2D>().bodyType = state;
        }

        void Update()
        {
            switch(currentstate)
            {
                case PlayerState.init:
                    break;
                case PlayerState.idle:
                    SetKinematic(RigidbodyType2D.Dynamic);
                    break;
                case PlayerState.dragging:
                    SetKinematic(RigidbodyType2D.Kinematic);
                    break;

                case PlayerState.dead:
                    break;
            }

            //if(Input.GetMouseButtonDown(0))
            //{
            //    var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //    go.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //    var ttl = go.AddComponent<DestroyOnTimer>();
            //    ttl.Time = 2f;

            //    if(moveCoroutine != null)
            //    {
            //        StopCoroutine(moveCoroutine);
            //        moveCoroutine = StartCoroutine(MoveTo(go.transform));
            //    }
            //    else
            //    {
            //        moveCoroutine = StartCoroutine(MoveTo(go.transform));
            //    }
            //}

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            var move = new Vector3(h, v);

            var dir = (forcemove) ? velocity.normalized : move.normalized;

            velocity = dir * speed;

            transform.position += velocity * Time.deltaTime;

            var dot = Vector3.Dot(dir, Vector3.right);

            if(dot > 0) transform.localRotation = new Quaternion(0, 0, 0, 1);
            else if(dot < 0) transform.localRotation = new Quaternion(0, 180, 0, 1);

            animator.SetFloat("Speed", velocity.magnitude / speed);
        }

        Coroutine moveCoroutine;
        IEnumerator MoveTo(Transform to)
        {
            forcemove = true;
            var startPosition = transform.position;
            var endPosition = new Vector3(to.position.x, to.position.y, 0);
            var journeyLength = Vector3.Distance(startPosition, endPosition);
            var dir = (endPosition - startPosition).normalized;
            velocity = dir * speed;
            while(Vector3.Distance(startPosition, transform.position) < journeyLength - 1)
            {
                yield return null;
            }
            forcemove = false;
            yield return null;
        }

        public bool forcemove = false;
        public Vector3 velocity;
        public Transform target;

        [SerializeField]
        float speed = 5f;
        [SerializeField]
        PlayerState currentstate;

        [SerializeField]
        Animator animator;       

    }
}
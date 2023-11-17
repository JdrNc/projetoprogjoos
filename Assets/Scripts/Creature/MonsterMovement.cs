using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;

    public Animator animator;
    public Transform centerPoint;
    public float moveSpeed;
    public int patrolDestination = 0;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    // Update is called once per frame

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        animator.SetBool("Started", true);
        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            // Debug.Log(Vector2.Distance(transform.position, patrolPoints[0].position));
            // Debug.Log(Vector2.Distance(transform.position, patrolPoints[0].position));
            // if (animation.animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
            // {
            //     patrolPoints[0].position = transform.position;
            //}
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
            {

                float novaPosicaoX = transform.position.x - 4f;
                transform.localPosition = new Vector3(novaPosicaoX, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(5, 5, 1);
                patrolDestination = 1;
            }
        }
        if (patrolDestination == 1)
        {

            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.45f)
            {
                float novaPosicaoX2 = transform.position.x + 4f;
                transform.localPosition = new Vector3(novaPosicaoX2, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(-5, 5, 1);
                patrolDestination = 0;
            }
        }

    }
}

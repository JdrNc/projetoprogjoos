using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Horizontal Movement Settings:")]
    [SerializeField] private float walkSpeed = 1;
    public Animator animator;
    public Transform attackPoint;
    [SerializeField] private float jumpForce = 45;

    [Header("Ground Check Settings:")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask whatIsGround;

    private bool grounded;
    private SpriteRenderer sprite;

    private int counter;

    //References
    Rigidbody2D rb;
    private float xAxis;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackPoint.parent = transform;
        grounded = false;
    }

    void Update()
    {
        sprite = GetComponent<SpriteRenderer>();

        GetInputs();
        Move();
        Jump();
    }

    public float GetInputs()
    {

        xAxis = Input.GetAxisRaw("Horizontal");

        return xAxis;

    }

    void Move()
    {
        rb.velocity = new Vector2(walkSpeed * xAxis, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(xAxis));


        //Debug.Log(xAxis);
        if (xAxis == -1)
        {
            sprite.flipX = true;

            //Inverte o hitbox para o lado que o personagem está virado
            attackPoint.localPosition = new Vector3(-Mathf.Abs(attackPoint.localPosition.x), attackPoint.localPosition.y, attackPoint.localPosition.z);
        }

        if (xAxis == 1)
        {
            sprite.flipX = false;

            //Inverte o hitbox para o lado que o personagem está virado
            attackPoint.localPosition = new Vector3(Mathf.Abs(attackPoint.localPosition.x), attackPoint.localPosition.y, attackPoint.localPosition.z);
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {

        Debug.Log("UNGROUNDED");
        grounded = false;

    }
    void Jump()
    {
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (Input.GetButtonDown("Jump") && counter < 1)
        {
            counter++;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
    }

    public SpriteRenderer getSprite()
    {
        return sprite;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == ("Ground"))
        {
            Debug.Log("GROUNDED");
            grounded = true;
            counter = 0;
        }
        else
        {
            grounded = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = Vector2.zero;  // Define a velocidade do jogador como zero
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Horizontal Movement Settings:")]
    [SerializeField] private float walkSpeed = 1;
    public Animator animator;

    [SerializeField] private float jumpForce = 45;

    [Header("Ground Check Settings:")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckY = 0.2f;
    [SerializeField] private float groundCheckX = 0.5f;
    [SerializeField] private LayerMask whatIsGround;
    private SpriteRenderer sprite;

    //References
    Rigidbody2D rb;
    private float xAxis;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        sprite = GetComponent<SpriteRenderer>();

        GetInputs();
        Move();
        Jump();
    }

    void GetInputs()
    {

        xAxis = Input.GetAxisRaw("Horizontal");

    }

    void Move()
    {
        rb.velocity = new Vector2(walkSpeed * xAxis, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(xAxis));
        Debug.Log(xAxis);
        if (xAxis == -1)
        {
            sprite.flipX = true;
        }

        if (xAxis == 1)
        {
            sprite.flipX = false;
        }
    }

    public bool Grounded()
    {
        if (Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatIsGround)
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround)
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(-groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Jump()
    {
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
    }

    public SpriteRenderer getSprite()
    {
        return sprite;
    }
}
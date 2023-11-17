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
        attackPoint.parent = transform;
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
            Debug.Log(Grounded());
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
    }

    public SpriteRenderer getSprite()
    {
        return sprite;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = Vector2.zero;  // Define a velocidade do jogador como zero
        }
    }
}
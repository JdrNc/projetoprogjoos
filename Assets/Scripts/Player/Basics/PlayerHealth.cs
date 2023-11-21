using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;

    public Animator animator;
    public int maxHealth = 10;

    public Rigidbody2D playerRb;
    void Start()
    {
        health = maxHealth;
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    public void TakeDamage(int amount, bool facingRight, float KBforce)
    {



        //Se ele tomar dado da esquerda ele vai pular pra esquerda se ele tomar dano direita ele vai pular pra direita.
        if (facingRight)
        {
            Debug.Log("Direita");
            



        }
        else
        {
            Debug.Log("Esquerda");
            playerRb.AddForce(Vector2.left * KBforce, ForceMode2D.Impulse);
        }

        

        health -= amount;
        // animator.SetTrigger("Hurt");
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {

        Debug.Log("Player Died");
        // animator.SetBool("Dead", true);
        Invoke("DestroyPlayer", 1.18f);
    }

    void DestroyPlayer()
    {
        Destroy(gameObject);
    }
    void Update()
    {





    }
}
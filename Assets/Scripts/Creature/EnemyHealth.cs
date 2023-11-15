using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;

    public Animator animator;
    public int maxHealth = 10;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame

    public void TakeDamage(int amount)
    {
        health -= amount;
        animator.SetTrigger("Hurt");

        if (health <= 0)
        {
            Die();
        }
    }
    public void Die(){

        Debug.Log("Enemy Died");
        animator.SetBool("Dead", true);
        Invoke("DestroyEnemy", 1.18f);
    }

    void DestroyEnemy(){
        Destroy(gameObject);
    }
    void Update()
    {

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{

    [Header("Damage Settings")]
    private bool isAttacking;
    public Animator animator;
    private Rigidbody2D rb;

    public float attackDelay;
    public Transform attackPoint;

    public float attackRange = 0.5f;
    public int attackDamage;

    public LayerMask enemyLayer;
    public EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        // hitbox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("c") && !isAttacking)
        {
            Attack1();
        }
    }

    void Attack1()
    {
        Debug.Log(isAttacking);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        isAttacking = true;
        Debug.Log(isAttacking);
        animator.SetBool("Attacking", isAttacking);
        

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    Invoke("ResetAttack", 0.5f);
    }

    void ResetAttack()
    {
        isAttacking = false;
        animator.SetBool("Attacking", isAttacking);
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public bool attacking()
    {
        return isAttacking;
    }

    public Rigidbody2D getPlayer()
    {
        return rb;
    }

}

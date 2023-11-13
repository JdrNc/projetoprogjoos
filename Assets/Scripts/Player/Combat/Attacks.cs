using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{

    [Header("Damage Settings")]
    public int dmg;
    private bool isAttacking;
    public Animator animator;
    private Rigidbody2D rb;
    private BoxCollider2D hitbox;


    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        hitbox = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Attacking", isAttacking);
        if (Input.GetKeyDown("c")) {

           
            StartCoroutine("Attack");
                    
        } 
        
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.3f);
        isAttacking = false;
    
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

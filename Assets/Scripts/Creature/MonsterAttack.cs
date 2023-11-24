using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private bool isAttacking;
    public Animator animator;
    public Transform rb;
    public Rigidbody2D player;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage;


    public float attackRate = 2f;

    float nextAttackTime = 0f;
    public LayerMask playerLayer;

    public float KBforce;

    void Start()
    {


        // Adicione 10 segundos
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (DetectarInimigo())
            {
                Debug.Log("Detectado");
                Attack1();
                nextAttackTime = Time.time + 2.8f / attackRate;
            }
        }
    }

    bool DetectarInimigo()
    {
        // Verifica se há inimigos dentro da área de detecção
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        return hitPlayers.Length > 0;
    }
    void Attack1()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        isAttacking = true;

        animator.SetTrigger("PlayerDetected1");

        bool facingRight = (player.position.x > rb.position.x);
        StartCoroutine(Example());
        /*        

                foreach (Collider2D player in hitPlayers)
                {
                    //Colocar sempre um dano que seja multiplicado por 2 pois o inimigo tem dois Collider o que dobra a superfície de colisão dobrando o dano.
                    player.GetComponent<PlayerHealth>().TakeDamage(attackDamage, facingRight, KBforce);


                }*/

    }

    IEnumerator Example()
    {
        isAttacking = true;
        Debug.Log("Test");
        yield return new WaitForSeconds(0.6f);

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        Debug.Log("Test2");
        bool facingRight = (player.position.x > rb.position.x);
        foreach (Collider2D player in hitPlayers)
        {
            //Colocar sempre um dano que seja multiplicado por 2 pois o inimigo tem dois Collider o que dobra a superfície de colisão dobrando o dano.

            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage, facingRight, KBforce);


        }
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyHealth : MonoBehaviour
{
    public int maxHealth;
    public Rigidbody2D skelly;
    public Rigidbody2D playerrb;
    public Transform attackRange;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 2;
        skelly = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(skelly.transform.position, attackRange.transform.position);
        

        if(distance < 1 && playerrb.GetComponent<Attacks>().attacking()) {
            maxHealth -= playerrb.GetComponent<Attacks>().attackDamage;
        }

        if(maxHealth < 0)
        {
            Debug.Log("DEAD");
        }

        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AttackRange" )
        {
            Debug.Log("Hello world!");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {

    }
}

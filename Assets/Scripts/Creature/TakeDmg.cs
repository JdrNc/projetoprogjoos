using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDmg : MonoBehaviour
{
    public Attacks attacker;
    private Rigidbody2D rb;
    private Rigidbody2D player;
    public PlayerController pcontroller;
    private SpriteRenderer psprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = attacker.getPlayer();
        
    }


    void OnCollisionStay2D(Collision2D coller)
    {
        Debug.Log(coller.gameObject.tag);

        if (attacker.attacking() && coller.gameObject.tag == "Untagged")
        {

            Debug.Log("Working!");
            if (pcontroller.getSprite().flipX)
            {
                rb.velocity = new Vector2(-10, 1);
            }
            else
            {
                rb.velocity = new Vector2(10, 10);
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.WakeUp();


  
        
    }


}

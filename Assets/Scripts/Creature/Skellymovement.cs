using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skellymovement : MonoBehaviour
{
    public Rigidbody2D player;
    private Rigidbody2D creature;
    private SpriteRenderer creatureSprite;
    public Animator animator;
    private float speed;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        creature = GetComponent<Rigidbody2D>();
        creatureSprite = GetComponent<SpriteRenderer>();
        speed = 0;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(creature.transform.position, player.transform.position);

        if (player.position.x > creature.position.x)
        {
            speed = 6.5f;
            creature.velocity = new Vector2(speed, creature.position.y);
            creatureSprite.flipX = true;
        }
        else if (player.position.x < creature.position.x)
        {
            speed = -6.5f;
            creature.velocity = new Vector2(speed, creature.position.y);
            creatureSprite.flipX = false;

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przeciwnik : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float range;
    public float distToPlayer;
    public bool mustPatrol;
    public bool mustTurn;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public Transform player;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
   
  
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
        distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer <= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0
                || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
            mustPatrol = false;
            rb.velocity = Vector2.zero;

        }
        else
        {
            mustPatrol = true;
        }

    }
    void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
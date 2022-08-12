using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Spawnable
{
    [SerializeField]
    private float   speed = 3f;
    [SerializeField]
    private int     hp = 10;
    [SerializeField]
    private int     score = 7;

    [SerializeField]
    private Rigidbody2D rb;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Always moves forward
        Vector2 direction = transform.right;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int amount)
    {
        // When unit runs out of the hp he dies 
        hp -= amount;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        ScoreController.sharedInstance.AddScore(score); // Adds score for the Player after the death
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // If unit collides with the Player? he deals him damage 
        Rigidbody2D otherRb = col.rigidbody;
        if (otherRb == null)
            return ;
    
        Player player = otherRb.gameObject.GetComponent<Player>();
        if (player == null)
            return ;

        player.TakeDamage();
    }
}

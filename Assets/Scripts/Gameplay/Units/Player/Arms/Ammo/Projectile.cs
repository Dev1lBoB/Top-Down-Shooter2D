using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int      dmg = 3;
    public float    speed = 7;
    public float    maxFlightDistance = 10000;

    [SerializeField]
    private Rigidbody2D rb;

    private float   totalDistanceTraveled;
    private Vector3 lastPosition;

    private void OnEnable()
    {
        totalDistanceTraveled = 0;
        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 direction = transform.right;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        totalDistanceTraveled += Vector3.Distance(transform.position, lastPosition); // Keeps track of the total traveled distance
        lastPosition = transform.position;
        if (totalDistanceTraveled >= maxFlightDistance) // Projectile destroys if it travels more than it could
        {
            Destroy();
        }
    }

    public virtual void Destroy()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        // If collision is an enemy then deals him damage and destroys
        Rigidbody2D otherRb = col.attachedRigidbody;
        if (otherRb == null)
            return ;
    
        Zombie enemy = otherRb.gameObject.GetComponent<Zombie>();
        if (enemy == null)
            return ;

        enemy.TakeDamage(dmg);
        Destroy();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Projectile
{
    [SerializeField]
    private GameObject explosionPrefab;

    private List<Zombie> victims = new List<Zombie>();

    public override void Destroy()
    {
        // At destroy deals dmg to the every enemy in the explosion area
        for (int i = victims.Count - 1; i >= 0; i--)
        {
            victims[i].TakeDamage(dmg);
        }
        victims.Clear();
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        base.Destroy();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        // Instead of bumping into the enemies keeps track of every one in the explosion area
        Rigidbody2D otherRb = col.attachedRigidbody;
        if (otherRb == null)
            return ;
    
        Zombie enemy = otherRb.gameObject.GetComponent<Zombie>();
        if (enemy == null)
            return ;

        victims.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        Rigidbody2D otherRb = col.attachedRigidbody;
        if (otherRb == null)
            return ;
    
        Zombie enemy = otherRb.gameObject.GetComponent<Zombie>();
        if (enemy == null)
            return ;

        victims.Remove(enemy);
    }
}

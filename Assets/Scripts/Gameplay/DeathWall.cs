using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    // Special wall to destroy out of the map projectiles
    private void OnTriggerEnter2D(Collider2D col)
    {
        Projectile proj = col.gameObject.GetComponent<Projectile>();
        if (proj == null)
            return ;
        proj.Destroy();
    }
}

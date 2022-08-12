using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public override void Shoot(Vector3 mousePos)
    {
        GameObject newProjectile = projectilePool.GetPooledObject();
        newProjectile.transform.position = firePoint.position;
        newProjectile.transform.rotation = transform.rotation;
        newProjectile.SetActive(true);
    }
}

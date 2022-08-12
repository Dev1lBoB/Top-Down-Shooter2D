using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    [SerializeField]
    private Camera mainCam;

    public override void Shoot(Vector3 mousePos)
    {
        GameObject newProjectile = projectilePool.GetPooledObject();
        newProjectile.transform.position = firePoint.position;
        newProjectile.transform.rotation = transform.rotation;

        mousePos.z = newProjectile.transform.position.z;
        Projectile rocket = newProjectile.GetComponent<Projectile>();
        newProjectile.SetActive(true);
        rocket.maxFlightDistance = Vector3.Distance(mousePos, newProjectile.transform.position); // Forces rocket to explode where was mouse cursor
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField]
    private int     bulletsPerShot = 5;
    [SerializeField]
    private float   totalSplashDegrees = 10;

    private float splashStep;

    protected override void Awake()
    {
        base.Awake();
        splashStep = totalSplashDegrees / bulletsPerShot;
    }

    public override void Shoot(Vector3 mousePos)
    {
        // Shoots blast of the projectiles and calculates correct angle for every single one of them
        float bulletAngle = -totalSplashDegrees / 2 + splashStep / 2;
        for (int i = 0; i < bulletsPerShot; i++)
        {
            GameObject newProjectile = projectilePool.GetPooledObject();
            newProjectile.transform.position = firePoint.position;
            newProjectile.transform.rotation = transform.rotation;
            newProjectile.transform.eulerAngles += Quaternion.AngleAxis(bulletAngle, transform.eulerAngles).eulerAngles;
            bulletAngle += splashStep;
            newProjectile.SetActive(true);
        }
    }
}

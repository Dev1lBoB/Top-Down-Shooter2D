using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public abstract class Weapon : MonoBehaviour
{
    public enum WeaponType
    {
        Pistol,
        Rifle,
        Shotgun,
        RocketLauncher
    }

    public WeaponType type;

    [SerializeField]
    protected Transform  firePoint;
    [SerializeField]
    protected float      shotsPerSecond;

    protected float fireRate;

    protected ObjectPool projectilePool;

    protected virtual void Awake()
    {
        projectilePool = GetComponent<ObjectPool>();
        fireRate = 1f / shotsPerSecond;
    }

    public float GetFireRate()
    {
        return fireRate;
    }

    public abstract void Shoot(Vector3 mousePos);
}

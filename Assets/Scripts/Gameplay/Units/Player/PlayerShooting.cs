using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Weapon activeWeapon;

    [SerializeField]
    private Weapon[] allWeapons;

    [SerializeField]
    private Camera  mainCam;
    [SerializeField]
    private float   angularSpeed = 180f;
    
    private float nextShot = 0f;
    
    private Coroutine currentRoutine = null;

    public void Fire()
    {
        // Prevents Player from shooting faster then weapons firerate or before previous shot was done
        if (Time.time <= nextShot || currentRoutine != null) 
            return ;
        
        currentRoutine = StartCoroutine(Shoot());
    }

    public void ChangeWeapon(Weapon.WeaponType type)
    {
        activeWeapon = allWeapons.FirstOrDefault(w => w.type == type); // Equips weapon of the given type
    }

    private IEnumerator Shoot()
    {
        // Remember point, where mouse clicked, rotates towards it and then shoots in that direction
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        yield return Rotate();
        nextShot = Time.time + activeWeapon.GetFireRate();
        activeWeapon.Shoot(mousePos);
        currentRoutine = null;
    }

    private IEnumerator Rotate()
    {
        // Smoothly rotates towards the mouse position
        Vector3 targetPoint = Input.mousePosition - mainCam.WorldToScreenPoint(transform.position);
        Quaternion finalRotation;
        do
        {
            float angle = Mathf.Atan2(targetPoint.y, targetPoint.x) * Mathf.Rad2Deg;
            finalRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, finalRotation, angularSpeed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        } while (transform.rotation != finalRotation);
    }
}

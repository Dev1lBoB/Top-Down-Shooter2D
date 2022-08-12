using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShooting))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private int hp = 1;

    [SerializeField]
    private GameObject sheildSprite;

    private PlayerMovement playerMovement;
    private PlayerShooting playerShooting;

    private bool    shieldOn = false;
    private bool    isShooting = false;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponent<PlayerShooting>();
    }

    private void Update()
    {
        // Makes Player to be able to hold the mouse for the shooting
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isShooting = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isShooting = false;
        }
    }

    private void FixedUpdate()
    {
        if (isShooting == true)
        {
            playerShooting.Fire();
        }
    }

    public void ChangeSpeed(float multiplier, bool state)
    {
        if (state == true)
            playerMovement.speed *= multiplier;
        else
            playerMovement.speed /= multiplier;
    }

    public void ChangeSheildState()
    {
        shieldOn = !shieldOn;
        sheildSprite.SetActive(shieldOn);
    }

    public void ChangeWeapon(Weapon.WeaponType newWeaponType)
    {
        playerShooting.ChangeWeapon(newWeaponType);
    }

    public void Die()
    {
        // After Players death also ends the game
        GameController.sharedInstance.GameFinished();
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        // If Player is under the sheild, he doesn't take any damage
        if (shieldOn == true)
            return ;

        // Player dies when runs out of hp
        --hp;
        if (hp == 0)
        {
            Die();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSpawner : BonusSpawner
{
    private PlayerShooting playerShooting;
    private Weapon.WeaponType activeWeaponType;

    private void Awake()
    {
        playerShooting = player.gameObject.GetComponent<PlayerShooting>();
    }

    protected override GameObject GetRandomObject()
    {
        int tmpWeight = totalWeight - 1;
        activeWeaponType = playerShooting.activeWeapon.type;
        foreach (Collectable bonus in objectPrefabs)
        {
            int rand = Random.Range(0, tmpWeight);
            if (((WeaponBonus)bonus).type != activeWeaponType && rand < bonus.chanceToSpawn) // Ignore the currently active weapon to not spawn a duplicate
                return bonus.gameObject;
            else
                tmpWeight -= bonus.chanceToSpawn;
        }

        return objectPrefabs[0].gameObject;
    }
}

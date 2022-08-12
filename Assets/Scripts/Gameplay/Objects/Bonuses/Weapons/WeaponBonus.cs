using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBonus : Collectable
{
    public Weapon.WeaponType type;

    public override void Collect(Player player)
    {
        // Equips given weapon on the Player
        player.ChangeWeapon(type);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : Zone
{
    public override void OnEnter(Player player)
    {
        // If player steps on this zone, he instantly dies 
        player.Die();
    }

    public override void OnExit(Player player)
    {
        player.Die();
    }
}

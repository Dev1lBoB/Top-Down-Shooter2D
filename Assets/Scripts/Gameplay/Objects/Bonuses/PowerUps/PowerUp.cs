using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Collectable
{
    [SerializeField]
    private PowerUpEffect powerUpEffect;

    public override void Collect(Player player)
    {
        // Applies effect to the Player when he picks up the bonus
        PowerUpEffect effect = player.gameObject.GetComponent(powerUpEffect.GetType()) as PowerUpEffect;
        if (effect != null && powerUpEffect.type == effect.type) // If Player is already under the simillar buff, swaps it with the new one
        {
            effect.Prolong(powerUpEffect);
            return ;
        }

        effect = player.gameObject.AddComponent(powerUpEffect.GetType()) as PowerUpEffect;
        if (effect != null)
        {
            effect.Apply(powerUpEffect);
        }
    }
}

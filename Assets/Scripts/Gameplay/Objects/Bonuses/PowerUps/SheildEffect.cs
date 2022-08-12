using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildEffect : PowerUpEffect
{
    public override void Apply(PowerUpEffect og)
    {
        duration = og.duration;
        currentRoutine = StartCoroutine(Protect());
    }

    private IEnumerator Protect()
    {
        // Covers Player with the shield for the duration time
        player.ChangeSheildState();
        yield return new WaitForSeconds(duration);
        player.ChangeSheildState();
        Destroy(this);
    }

    public override void Prolong(PowerUpEffect og)
    {
        // Udpates protection
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
            player.ChangeSheildState();
            currentRoutine = StartCoroutine(Protect());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpEffect : PowerUpEffect
{
    public float speedUpMultiplier = 1.5f;

    public override void Apply(PowerUpEffect og)
    {
        CopyData((SpeedUpEffect)og);
        currentRoutine = StartCoroutine(SpeedUp());
    }

    private IEnumerator SpeedUp()
    {
        // Increases Players speed for the duration time
        player.ChangeSpeed(speedUpMultiplier, true);
        yield return new WaitForSeconds(duration);
        player.ChangeSpeed(speedUpMultiplier, false);
        Destroy(this);
    }

    public override void Prolong(PowerUpEffect og)
    {
        // Udpates acceleration
        CopyData((SpeedUpEffect)og);
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
            player.ChangeSpeed(speedUpMultiplier, false);
            currentRoutine = StartCoroutine(SpeedUp());
        }
    }

    private void CopyData(SpeedUpEffect other)
    {
        this.duration = other.duration;
        this.speedUpMultiplier = other.speedUpMultiplier;
    }
}

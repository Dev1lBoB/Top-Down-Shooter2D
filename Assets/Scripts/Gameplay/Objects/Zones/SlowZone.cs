using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : Zone
{
    [SerializeField]
    private float slowScale = 0.6f;

    public override void OnEnter(Player player)
    {
        player.ChangeSpeed(slowScale, true);
    }

    public override void OnExit(Player player)
    {
        player.ChangeSpeed(slowScale, false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpEffect : MonoBehaviour
{
    public Type     type;
    public float    duration = 10f;

    protected Player    player;
    protected Coroutine currentRoutine = null;

    private void Awake()
    {
        player = GetComponent<Player>();
        type = this.GetType();
    }

    public abstract void Apply(PowerUpEffect og);
    public abstract void Prolong(PowerUpEffect og);
}

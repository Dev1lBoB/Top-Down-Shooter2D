using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Zone : MonoBehaviour
{
    public float radius = 1;

    protected void OnTriggerEnter2D(Collider2D col)
    {
        // Zone works only on Player
        Player player = col.attachedRigidbody.gameObject.GetComponent<Player>();
        if (player != null)
        {
            OnEnter(player);
        }
    }

    protected void OnTriggerExit2D(Collider2D col)
    {
        // Zone works only on Player
        Player player = col.attachedRigidbody.gameObject.GetComponent<Player>();
        if (player != null)
        {
            OnExit(player);
        }
    }

    public abstract void OnEnter(Player player);
    public abstract void OnExit(Player player);
}

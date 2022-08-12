using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public abstract class Collectable : Spawnable
{
    [SerializeField]
    private float   expireTime = 5f;
    [SerializeField]
    private float   totalFlashingTime = 1f;
    [SerializeField]
    private int     timesToBlink = 4;

    private Renderer rend;

    protected virtual void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
    {
        // Object destroys after not being collected after delay
        yield return new WaitForSeconds(expireTime - totalFlashingTime);

        yield return rend.FlashEffect(totalFlashingTime, totalFlashingTime / timesToBlink);

        Destroy(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        // When Player steps on the object, he collects its effect and than the object destroys
        Player player = col.attachedRigidbody.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Collect(player);
            Destroy(gameObject);
        }
    }
 
    public abstract void Collect(Player player);
}

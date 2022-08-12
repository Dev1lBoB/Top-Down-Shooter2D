using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    private Transform   target;
    [SerializeField]
    private Rigidbody2D rb;

    private void FixedUpdate()
    {
        Move();    
    }

    private void Move()
    {
        // Makes object to always follow the target, but not to /teleport/ under it
        if (target == null)
            return ;

        Vector3 targetPosition = target.position;
        Vector3 currentPosition = transform.position;
        Vector2 direction = targetPosition - currentPosition;
        if (Vector3.Distance(currentPosition, targetPosition) > 0.1f)
        {
            rb.MovePosition(rb.position + direction * 1000 * Time.fixedDeltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform target;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        // Forces object to allways face at the Players position
        if (target)
        {
            Vector3 dir = target.position - transform.position;
            transform.right = dir;
        }
    }
}

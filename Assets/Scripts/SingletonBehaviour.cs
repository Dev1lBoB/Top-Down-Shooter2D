using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T: SingletonBehaviour<T>
{
    public static T sharedInstance { get; protected set; }
 
    protected void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(this);
            throw new System.Exception("An instance of this singleton already exists.");
        }
        else
        {
            sharedInstance = (T)this;
        }
    }
}

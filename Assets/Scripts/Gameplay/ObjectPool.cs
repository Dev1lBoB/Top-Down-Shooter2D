using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject  objectToPool;
    [SerializeField]
    private int         amountToPool;

    private List<GameObject> pooledObjects;

    private void Awake()
    {
        PreparePool();
    }

    private void PreparePool()
    {
        // Instantiate object prefab amountToPool times and store all of them inside of a list
        pooledObjects = new List<GameObject>();

        for(int i = 0; i < amountToPool; i++)
        {
            AddObjectToPool();
        }
    }

    public GameObject GetPooledObject()
    {
        // Search for the first non active object inside of the pool and return it
        for(int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // If there is no objects left in the pool extends it by one
        return ExtendPool();
    }

    private GameObject ExtendPool()
    {
        ++amountToPool;
        return AddObjectToPool();
    }

    private GameObject AddObjectToPool()
    {
        GameObject newObject;
        newObject = Instantiate(objectToPool);
        newObject.SetActive(false);
        pooledObjects.Add(newObject);
        return newObject;
    }
}

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T: Spawnable
{
    [SerializeField]
    protected T[]   objectPrefabs;
    [SerializeField]
    protected float timeToSpawn = 10;
    
    [SerializeField]
    protected Transform player;

    protected int    totalWeight;
    protected Camera cam;

    private bool spawnObject = false;

    protected virtual void Start()
    {
        cam = Camera.main;
        totalWeight = objectPrefabs.Sum(c => c.chanceToSpawn);
    }

    private void Update()
    {
        if (spawnObject == false)
        {
            spawnObject = true;
            StartCoroutine(SpawnRandomObject());
        }
    }

    private IEnumerator SpawnRandomObject()
    {
        // Spawns random object from the list at the random position
        yield return new WaitForSeconds(timeToSpawn);
        if (player == null)
            yield break ;

        GameObject randomObjectPrefab = GetRandomObject();
        Vector2 randomPosition = GetRandomSpawnPoint();

        GameObject newObject = Instantiate(randomObjectPrefab);
        newObject.transform.position = GetRandomSpawnPoint();
        spawnObject = false;
    }

    protected virtual GameObject GetRandomObject()
    {
        // Select random object
        int tmpWeight = totalWeight - 1;
        foreach (T o in objectPrefabs)
        {
            int rand = Random.Range(0, tmpWeight);
            if (rand < o.chanceToSpawn)
                return o.gameObject;
            else
                tmpWeight -= o.chanceToSpawn;
        }

        return objectPrefabs[0].gameObject;
    }

    protected abstract Vector3 GetRandomSpawnPoint(); // Calculate random position to spawn
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : Spawner<Zombie>
{
    [SerializeField]
    private float minTimeToSpawn = 0.5f;
    [SerializeField]
    private float delayStep = 10f;
    [SerializeField]
    private float decreaseTimeStep = 0.1f;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(DecreaseTimeToSpawn());
    }

    private IEnumerator DecreaseTimeToSpawn()
    {
        while (timeToSpawn > minTimeToSpawn)
        {
            yield return new WaitForSeconds(delayStep);
            timeToSpawn -= decreaseTimeStep;
        }
        timeToSpawn = minTimeToSpawn;
    }

    protected override Vector3 GetRandomSpawnPoint()
    {
        // Calculate random position to spawn outside the camera view
        Vector2 lDCamCorner = cam.ViewportToWorldPoint(new Vector3(0, 0f, cam.nearClipPlane));
        Vector2 rUCamCorner = cam.ViewportToWorldPoint(new Vector3(1f, 1f, cam.nearClipPlane));
        Vector3 finalPoint;
        finalPoint.z = player.position.z;

        if (Random.value > 0.5)
        {
            finalPoint.x = Random.value > 0.5 ?
            lDCamCorner.x - 2 :
            rUCamCorner.x + 2;
            finalPoint.y = Random.Range(lDCamCorner.y, rUCamCorner.y + 1);
        }
        else
        {
            finalPoint.y = Random.value > 0.5 ?
            lDCamCorner.y - 2 :
            rUCamCorner.y + 2;
            finalPoint.x = Random.Range(lDCamCorner.x, rUCamCorner.x + 1);
        }

        return finalPoint;
    }
}

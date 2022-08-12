using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : Spawner<Collectable>
{
    protected override Vector3 GetRandomSpawnPoint()
    {
        // Calculate random position to spawn inside the camera view
        Vector2 lDCorner = cam.ViewportToWorldPoint(new Vector3(0, 0f, cam.nearClipPlane));
        Vector2 rUCorner = cam.ViewportToWorldPoint(new Vector3(1f, 1f, cam.nearClipPlane));
        Vector3 finalPoint;
        finalPoint.z = player.position.z;

        for (int i = 0; i < 5; i++) // Prevent situation when objects spawns at the incorrect position for too many attempts
        {
            finalPoint.x = Random.Range(lDCorner.x, rUCorner.x + 1);
            finalPoint.y = Random.Range(lDCorner.y, rUCorner.y + 1);
            if ((finalPoint - player.position).magnitude > 3) // Prevent spawning right at the players postion
                return finalPoint;
        }

        return rUCorner; // Spawns object at the upper-right corner
    }
}

using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZonesGenerator : MonoBehaviour
{
    [Serializable]
    private struct ZonePrefabPair
    {
        public Zone zonePrefab;
        public int  timesToSpawn;
    }
    [SerializeField]
    private ZonePrefabPair[] zonePrefabs;

    [SerializeField]
    private Transform   player;
    [SerializeField]
    private Vector2     mapSize;
    [SerializeField]
    private float       gap;

    private float xHalf;
    private float yHalf;

    private List<Zone> activeZones = new List<Zone>();

    private void Awake()
    {
        xHalf = mapSize.x / 2;
        yHalf = mapSize.y / 2;
    }

    private void Start()
    {
        GenerateZones();
    }

    private void GenerateZones()
    {
        foreach (ZonePrefabPair zpp in zonePrefabs)
        {
            for (int j = 0; j < zpp.timesToSpawn; j++)
            {
                GenerateZone(zpp);
            }
        }
    }

    private void GenerateZone(ZonePrefabPair zpp)
    {
        // Creates new dangerZone inside the playing map
        Vector3 spawnPos = GetSpawnPoint(zpp.zonePrefab);
        GameObject newZone = Instantiate(zpp.zonePrefab.gameObject);
        newZone.transform.position = spawnPos;
        activeZones.Add(newZone.GetComponent<Zone>());
    }

    private Vector3 GetSpawnPoint(Zone zone)
    {
        Vector3 finalPoint = new Vector3();
        finalPoint.z = player.position.z + 1;

        bool pointFounded = false;
        do
        {
            finalPoint.x = UnityEngine.Random.Range(-xHalf + zone.radius + gap, xHalf - zone.radius - gap + 1);
            finalPoint.y = UnityEngine.Random.Range(-yHalf + zone.radius + gap, yHalf - zone.radius - gap + 1);

            if (Vector2.Distance(player.position, finalPoint) < zone.radius + gap + 1) // Prevent spawning ontop of the player
                continue ;

            if (activeZones.Count == 0) // If this is the first zone we don't need to check for others
                break ;

            Zone closestZone = GetClosestActiveZone(finalPoint);
            float distance =  Vector3.Distance(finalPoint, closestZone.transform.position);

            if (distance >= zone.radius + closestZone.radius + gap) // Check if the new zone is to close to the already existing zones
                pointFounded = true;
        } while (pointFounded == false);

        return finalPoint;
    }

    private Zone GetClosestActiveZone(Vector3 pos)
    {
        // Get the closest zone to the new one from the active list
        activeZones = activeZones.OrderBy(z => Vector3.Distance(z.transform.position, pos) + z.radius).ToList();
        return activeZones[0];
    }
}

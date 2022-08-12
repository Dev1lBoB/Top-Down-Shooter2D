using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector2    mapSize;
    [SerializeField]
    private GameObject wallPrefab;

    private void Start()
    {
        CreateWalls();
    }

    private void CreateWalls()
    {
        // Creates collider walls around the giving area
        float xHalf = mapSize.x / 2;
        float yHalf = mapSize.y / 2;

        SpawnWall(new Vector2(xHalf, 0), new Vector2(0.1f, mapSize.y));
        SpawnWall(new Vector2(-xHalf, 0), new Vector2(0.1f, mapSize.y));
        SpawnWall(new Vector2(0, yHalf), new Vector2(mapSize.x, 0.1f));
        SpawnWall(new Vector2(0, -yHalf), new Vector2(mapSize.x, 0.1f));
    }

    private void SpawnWall(Vector2 pos, Vector2 size)
    {
        // Builds single wall
        GameObject newWall = Instantiate(wallPrefab);
        newWall.transform.position = pos;
        newWall.transform.localScale = size;
        newWall.transform.parent = transform;
    }
}

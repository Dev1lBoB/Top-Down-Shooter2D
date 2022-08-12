using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliderGenerator : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        GenerateCollidersAcrossScreen();
    }

    private void GenerateCollidersAcrossScreen()
    {
        // Creates edge colliders for the camera right at the view borders
        Vector2 lDCorner = cam.ViewportToWorldPoint(new Vector3(0, 0f, cam.nearClipPlane));
        Vector2 rUCorner = cam.ViewportToWorldPoint(new Vector3(1f, 1f, cam.nearClipPlane));

        CreateEdge("UpperEdge", lDCorner.x, rUCorner.y, rUCorner.x, rUCorner.y);
        CreateEdge("LowerEdge", lDCorner.x, lDCorner.y, rUCorner.x, lDCorner.y);
        CreateEdge("LeftEdge",  lDCorner.x, lDCorner.y, lDCorner.x, rUCorner.y);
        CreateEdge("RightEdge", rUCorner.x, rUCorner.y, rUCorner.x, lDCorner.y);
    }

    private void CreateEdge(string name, float colPoints_1x, float colPoints_1y, float colPoints_2x, float colPoints_2y)
    {
        // Draws an edge collider from one point to another
        Vector2[] colliderpoints;
        EdgeCollider2D edge = new GameObject(name).AddComponent<EdgeCollider2D>();
        colliderpoints = edge.points;
        colliderpoints[0] = new Vector2(colPoints_1x, colPoints_1y);
        colliderpoints[1] = new Vector2(colPoints_2x, colPoints_2y);
        edge.points = colliderpoints;
        edge.transform.parent = this.transform;
        edge.gameObject.layer = this.gameObject.layer;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadMaker : MonoBehaviour {

    private MeshFilter filter;

    private Mesh mesh;



    private void OnValidate()
    {
        filter = GetComponent<MeshFilter>();
    }

    private void Start()
    {
        mesh = new Mesh();

        Vector3[] vertices = new Vector3[4];
        vertices[0] = Vector3.zero;
        vertices[1] = Vector3.right;
        vertices[2] = Vector3.up;
        vertices[3] = Vector3.right + Vector3.up;

        int[] tris = new int[6];
        tris[0] = 0;
        tris[1] = 2;
        tris[2] = 1;
        tris[3] = 2;
        tris[4] = 3;
        tris[5] = 1;

        Vector2[] uv =
        {
            Vector2.zero,
            Vector2.right,
            Vector2.up,
            Vector2.one
        };

        mesh.vertices = vertices;
        mesh.triangles = tris;
        mesh.uv = uv;

        filter.sharedMesh = mesh;
    }

}

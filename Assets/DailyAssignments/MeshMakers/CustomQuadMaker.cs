using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomQuadMaker : MonoBehaviour {

    public float width;
    public float height;

    private MeshFilter filter;

    private Mesh mesh;



    private void OnValidate()
    {
        filter = GetComponent<MeshFilter>();

        mesh = new Mesh();

        float halfWidth = width / 2.0f;
        float halfHeight = height / 2.0f;

        Vector3[] vertices = new Vector3[4];
        vertices[0] = -Vector3.right * halfWidth + -Vector3.up * halfHeight;
        vertices[1] =  Vector3.right * halfWidth + -Vector3.up * halfHeight;
        vertices[2] = -Vector3.right * halfWidth +  Vector3.up * halfHeight;
        vertices[3] =  Vector3.right * halfWidth +  Vector3.up * halfHeight;

        int[] tris = new int[6];
        tris[0] = 0;
        tris[1] = 2;
        tris[2] = 1;
        tris[3] = 2;
        tris[4] = 3;
        tris[5] = 1;

        mesh.vertices = vertices;
        mesh.triangles = tris;

        filter.sharedMesh = mesh;
    }

}

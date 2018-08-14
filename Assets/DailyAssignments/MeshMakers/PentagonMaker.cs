using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagonMaker : MonoBehaviour {

    public MeshFilter filter;

    private Mesh mesh;


    private void Start()
    {
        mesh = new Mesh();

        Vector3[] vertices = new Vector3[6];
        vertices[0] = Vector3.zero;
        vertices[1] = new Vector3(-0.3f, -0.5f, 0);
        vertices[2] = new Vector3(-0.8f, 0, 0);
        vertices[3] = new Vector3(0, 0.5f, 0);
        vertices[4] = new Vector3(0.8f, 0, 0);
        vertices[5] = new Vector3(0.3f, -0.5f, 0);



        int[] tris = new int[15];

        tris[0] = 0;
        tris[1] = 1;
        tris[2] = 2;

        tris[3] = 0;
        tris[4] = 2;
        tris[5] = 3;

        tris[6] = 0;
        tris[7] = 3;
        tris[8] = 4;

        tris[9] = 0;
        tris[10] = 4;
        tris[11] = 5;

        tris[12] = 0;
        tris[13] = 5;
        tris[14] = 1;



        mesh.vertices = vertices;
        mesh.triangles = tris;

        filter.sharedMesh = mesh;
    }

}

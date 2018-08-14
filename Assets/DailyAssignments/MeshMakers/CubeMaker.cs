using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMaker : MonoBehaviour {

    private MeshFilter filter;

    private Mesh mesh;



    private void OnValidate()
    {
        filter = GetComponent<MeshFilter>();
    }

    private void Start()
    {
        mesh = new Mesh();

        Vector3[] vertices = new Vector3[8];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(1, 0, 0);
        vertices[2] = new Vector3(0, 1, 0);
        vertices[3] = new Vector3(1, 1, 0);
        vertices[4] = new Vector3(0, 0, 1);
        vertices[5] = new Vector3(1, 0, 1);
        vertices[6] = new Vector3(0, 1, 1);
        vertices[7] = new Vector3(1, 1, 1);



        int[] tris = new int[36];

        tris[0] = 0;
        tris[1] = 2;
        tris[2] = 1;
        tris[3] = 2;
        tris[4] = 3;
        tris[5] = 1;

        tris[6] = 4;
        tris[7] = 5;
        tris[8] = 6;
        tris[9] = 5;
        tris[10] = 7;
        tris[11] = 6;

        tris[12] = 0;
        tris[13] = 4;
        tris[14] = 6;
        tris[15] = 0;
        tris[16] = 6;
        tris[17] = 2;

        tris[18] = 5;
        tris[19] = 1;
        tris[20] = 3;
        tris[21] = 5;
        tris[22] = 3;
        tris[23] = 7;

        tris[24] = 5;
        tris[25] = 4;
        tris[26] = 0;
        tris[27] = 5;
        tris[28] = 0;
        tris[29] = 1;

        tris[30] = 3;
        tris[31] = 2;
        tris[32] = 6;
        tris[33] = 3;
        tris[34] = 6;
        tris[35] = 7;



        mesh.vertices = vertices;
        mesh.triangles = tris;

        mesh.RecalculateNormals();

        filter.sharedMesh = mesh;
    }

}

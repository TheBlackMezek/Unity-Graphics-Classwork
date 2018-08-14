using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexHighlighter : MonoBehaviour {

    private MeshFilter filter;



    private void OnValidate()
    {
        filter = GetComponent<MeshFilter>();
    }

    private void OnDrawGizmos()
    {
        if(filter.sharedMesh != null)
        {
            Vector3[] vertices = filter.sharedMesh.vertices;

            foreach (Vector3 v in vertices)
            {
                Gizmos.DrawWireSphere(transform.TransformPoint(v), 0.1f);
            }
        }
    }

}

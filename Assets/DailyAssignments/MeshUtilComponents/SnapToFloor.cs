using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToFloor : MonoBehaviour {

    private MeshFilter filter;



    private void OnValidate()
    {
        filter = GetComponent<MeshFilter>();
    }

    private void Start()
    {
        Vector3 meshCenter = MeshUtils.Center(filter.sharedMesh);
        RaycastHit hit;
        if(Physics.Raycast(transform.position + meshCenter, -Vector3.up, out hit))
        {
            transform.position = hit.point - Vector3.up * MeshUtils.MinHeight(filter.sharedMesh);
            transform.RotateAround(transform.position + Vector3.up * MeshUtils.MinHeight(filter.sharedMesh),
                                   Vector3.forward,
                                   hit.transform.eulerAngles.z - transform.eulerAngles.z);
            transform.RotateAround(transform.position + Vector3.up * MeshUtils.MinHeight(filter.sharedMesh),
                                   Vector3.right,
                                   hit.transform.eulerAngles.x - transform.eulerAngles.x);
        }
    }

}

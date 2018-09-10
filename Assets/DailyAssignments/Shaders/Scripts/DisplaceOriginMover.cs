using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaceOriginMover : MonoBehaviour {
    
    [SerializeField]
    private Vector4 moveMult;
    [SerializeField]
    private Vector4 originalOrigin;
    private MeshRenderer mr;
    [SerializeField]
    private Vector4 mod = Vector4.zero;



    private void OnValidate()
    {
        mr = GetComponent<MeshRenderer>();
        mod = Vector4.zero;
        //originalOrigin = mr.sharedMaterial.GetVector("_DisplaceOrigin");
    }

    private void OnDrawGizmos()
    {
        //Vector4 origin = mr.sharedMaterial.GetVector("_DisplaceOrigin");
        //Vector4 origin = originalOrigin + moveMult * (2f - Mathf.Sin(Time.realtimeSinceStartup - lastTime));
        mod += moveMult * (Mathf.Sin(Time.realtimeSinceStartup));
        Vector4 origin = originalOrigin + mod;
        mr.sharedMaterial.SetVector("_DisplaceOrigin", origin);
    }

}

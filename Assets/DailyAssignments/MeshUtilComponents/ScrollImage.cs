using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollImage : MonoBehaviour {

    public float scrollRate;
    public Vector2 scrollDir;

    private MeshRenderer mr;



    private void OnValidate()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        mr.material.mainTextureOffset += scrollDir * scrollRate * Time.deltaTime;
    }

}

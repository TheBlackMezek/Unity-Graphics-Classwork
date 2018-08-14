using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorEditor : MonoBehaviour {

    public Color color;

    private MeshRenderer mr;



    private void OnValidate()
    {
        mr = GetComponent<MeshRenderer>();

        mr.sharedMaterial.color = color;
    }

}

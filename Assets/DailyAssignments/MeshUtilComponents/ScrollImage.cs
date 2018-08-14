using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollImage : MonoBehaviour {

    public float scrollRate;

    private MeshRenderer mr;



    private void OnValidate()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        mr.material.mainTextureOffset += Vector2.right * scrollRate * Time.deltaTime;
    }

}

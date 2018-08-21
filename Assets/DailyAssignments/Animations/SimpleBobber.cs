using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBobber : MonoBehaviour {

    public float bobMultiplier;

    private void Update()
    {
        transform.position += Vector3.up * Mathf.Cos(Time.time) * bobMultiplier;
    }

}

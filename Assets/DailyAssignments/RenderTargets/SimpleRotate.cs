using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour {

    public Vector3 rotSpeed;

    private void Update()
    {
        transform.eulerAngles += rotSpeed * Time.deltaTime;
    }

}

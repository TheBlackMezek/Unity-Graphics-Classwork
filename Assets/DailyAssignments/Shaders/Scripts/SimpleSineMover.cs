using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSineMover : MonoBehaviour {

    [SerializeField]
    private Vector3 moveAxis;
    [SerializeField]
    private float frequency;
    [SerializeField]
    private float magnitude;

    private float time = Mathf.PI / 2f;
    private Vector3 originalPos;



    private void Awake()
    {
        originalPos = transform.position;
    }

    private void Update()
    {
        time += Time.deltaTime;
        transform.position = originalPos + moveAxis * Mathf.Sin(time * frequency) * magnitude;
        //transform.position += moveAxis * Mathf.Sin(time * frequency) * magnitude;
    }

}

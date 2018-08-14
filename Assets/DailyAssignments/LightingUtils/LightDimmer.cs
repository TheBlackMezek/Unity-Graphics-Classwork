using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDimmer : MonoBehaviour {

    public bool dimOnStart;
    public float duration;
    public float finalIntensity;

    private Light light;

    private bool dimming = false;
    private float dimRate = 0;



    private void OnValidate()
    {
        light = GetComponent<Light>();
    }

    private void Start()
    {
        if(dimOnStart)
        {
            Dim();
        }
    }

    public void Dim()
    {
        dimRate = (light.intensity - finalIntensity) / duration;
        dimming = true;
    }

    private void Update()
    {
        if(dimming)
        {
            light.intensity -= dimRate * Time.deltaTime;
            if(light.intensity <= finalIntensity)
            {
                light.intensity = finalIntensity;
                dimming = false;
            }
        }
    }

}

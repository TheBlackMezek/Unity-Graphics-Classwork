using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightFocuser : MonoBehaviour {

    public float pinpointIntensity;
    [Tooltip("The intensity will be constant after this point")]
    public float maxDimmingAngle;
    public float minIntensity;

    private Light light;



    private void OnValidate()
    {
        light = GetComponent<Light>();
        if(light.type != LightType.Spot)
        {
            light = null;
        }
        else
        {
            CalculateIntensity();
        }
    }

    private void Update()
    {
        if(light != null)
        {
            CalculateIntensity();
        }
    }

    private void CalculateIntensity()
    {
        light.intensity = light.spotAngle >= maxDimmingAngle ? minIntensity
            : Mathf.Lerp(minIntensity, pinpointIntensity, Mathf.InverseLerp(maxDimmingAngle, 0, light.spotAngle));
    }

}

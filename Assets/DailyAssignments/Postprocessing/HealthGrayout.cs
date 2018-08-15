using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HealthGrayout : MonoBehaviour {

    public float health;
    private int healthDir = 1;

    private PostProcessVolume volume;
    private ColorGrading cg;

    private void Start()
    {
        cg = ScriptableObject.CreateInstance<ColorGrading>();
        cg.enabled.Override(true);
        //cg.saturation.Override(-100f);

        volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, cg);
    }

    private void Update()
    {
        if(health <= 0)
        {
            healthDir = 1;
        }
        else if(health >= 100)
        {
            healthDir = -1;
        }

        health += Time.deltaTime * healthDir * 100.0f;

        cg.saturation.Override((100f - health) * -1);
    }

    private void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(volume, true, true);
    }

}

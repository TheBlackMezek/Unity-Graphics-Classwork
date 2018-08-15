using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPFadeToBlack : MonoBehaviour {

    public float duration;
    public bool fadeOnStart;

    private PostProcessVolume volume;
    private ColorGrading cg;
    private bool fading = false;

    private void Start()
    {
        cg = ScriptableObject.CreateInstance<ColorGrading>();
        cg.enabled.Override(true);
        
        if(fadeOnStart)
        {
            fading = true;
        }
        
        volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, cg);
    }

    private void Update()
    {
        if(fading)
        {
            cg.mixerBlueOutBlueIn.Override(cg.mixerBlueOutBlueIn.value - Time.deltaTime * (100f / duration));
            cg.mixerRedOutRedIn.Override(cg.mixerRedOutRedIn.value - Time.deltaTime * (100f / duration));
            cg.mixerGreenOutGreenIn.Override(cg.mixerGreenOutGreenIn.value - Time.deltaTime * (100f / duration));
            if(cg.mixerBlueOutBlueIn <= 0)
            {
                fading = false;
            }
        }
    }

    private void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(volume, true, true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshFader : MonoBehaviour {

    public bool testFadingOnStart;
    public float duration;

    private MeshRenderer mr;

    private bool fadingIn = false;
    private bool fadingOut = false;
    private float fadeRate = 0;
    private float originalRenderMode;



    private void OnValidate()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        if (testFadingOnStart)
        {
            FadeOut();
        }
    }

    public void FadeOut()
    {
        fadeRate = 1.0f / duration;
        fadingOut = true;
        originalRenderMode = mr.material.GetFloat("_Mode");
        mr.material.SetFloat("_Mode", 3);

        mr.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        mr.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mr.material.SetInt("_ZWrite", 0);
        mr.material.DisableKeyword("_ALPHATEST_ON");
        mr.material.DisableKeyword("_ALPHABLEND_ON");
        mr.material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        mr.material.renderQueue = 3000;
    }

    private void Update()
    {
        if (fadingOut)
        {
            mr.material.color -= Color.black * fadeRate * Time.deltaTime;
            if (mr.material.color.a <= 0)
            {
                fadingOut = false;
                mr.material.SetFloat("_Mode",originalRenderMode);
            }
        }
    }

}

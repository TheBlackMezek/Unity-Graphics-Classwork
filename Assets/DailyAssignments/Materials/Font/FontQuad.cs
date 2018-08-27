using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontQuad : MonoBehaviour {

    [SerializeField]
    private int cidx;
    public int chrIdx
    {
        get
        {
            return cidx;
        }
        set
        {
            cidx = value;
            CheckChrIdx();
            SetMatStuff();
        }
    }

    public int fontmapWidth;
    public int fontmapHeight;

    private MeshRenderer mr;

    private float charWidth;
    private float charHeight;



    private void OnValidate()
    {
        mr = GetComponent<MeshRenderer>();
        CheckChrIdx();
        SetMatStuff();
    }

    private void CheckChrIdx()
    {
        if (cidx < 0)
        {
            cidx = 0;
        }
        else if (cidx > fontmapHeight * fontmapWidth)
        {
            cidx = fontmapHeight * fontmapWidth - 1;
        }
    }

    private void SetMatStuff()
    {
        charWidth = 1f / fontmapWidth;
        charHeight = 1f / fontmapHeight;

        mr.sharedMaterial.mainTextureScale = new Vector2(charWidth, charHeight);
        mr.sharedMaterial.mainTextureOffset = new Vector2((cidx % fontmapWidth) * charWidth,
                                       (fontmapHeight - 1 - (cidx / fontmapWidth)) * charHeight);
    }

}

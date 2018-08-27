using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCharSelector : MonoBehaviour {

    public float maxWaitTime;
    public float minWaitTime;

    private FontQuad fontq;

    private float waitTime;
    private float timer = 0;



    private void OnValidate()
    {
        fontq = GetComponent<FontQuad>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            timer = 0;
            waitTime = Random.Range(minWaitTime, maxWaitTime);
            fontq.chrIdx = Random.Range(0, fontq.fontmapWidth * fontq.fontmapHeight);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwitcher : MonoBehaviour {

    public string startLayer;
    public string otherLayer;
    public float cycleTime;

    private float timer = 0;
    private int startLayerId;
    private int otherLayerId;



    private void Awake()
    {
        startLayerId = LayerMask.NameToLayer(startLayer);
        otherLayerId = LayerMask.NameToLayer(otherLayer);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= cycleTime)
        {
            timer = 0;

            if(gameObject.layer == startLayerId)
            {
                gameObject.layer = otherLayerId;
            }
            else
            {
                gameObject.layer = startLayerId;
            }
        }
    }

}

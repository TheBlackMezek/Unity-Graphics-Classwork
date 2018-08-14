using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRingComponent : MonoBehaviour {

    public GameObject ringPrefab;
    public float radius;
    public int itemCount;
    public float rotationMod;

    private GameObject[] items = null;



    public void BuildRing()
    {
        if(items != null)
        {
            foreach(GameObject g in items)
            {
                DestroyImmediate(g);
            }
        }

        items = new GameObject[itemCount];

        for (int i = 0; i < itemCount; ++i)
        {
            items[i] = Instantiate(ringPrefab);
            items[i].transform.rotation = transform.rotation;
            items[i].transform.position = transform.position;
            items[i].transform.eulerAngles += Vector3.up * ((360.0f / itemCount) * i) + Vector3.up * rotationMod;
            items[i].transform.position += items[i].transform.forward * radius;
        }
    }

}

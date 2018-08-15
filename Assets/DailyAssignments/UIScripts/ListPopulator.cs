using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListPopulator : MonoBehaviour {

    public GameObject elementPrefab;
    public string[] names;



    private void Awake()
    {
        for(int i = 0; i < names.Length; ++i)
        {
            GameObject element = Instantiate(elementPrefab);
            element.GetComponentInChildren<Text>().text = names[i];
            element.transform.parent = transform;
        }
    }

}

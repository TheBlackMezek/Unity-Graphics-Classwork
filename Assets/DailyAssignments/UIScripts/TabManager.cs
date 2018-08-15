using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour {

    public GameObject[] tabs;

    private GameObject activeTab;



    private void Start()
    {
        foreach(GameObject g in tabs)
        {
            g.SetActive(false);
        }
        tabs[0].SetActive(true);
        activeTab = tabs[0];
    }

    public void SetTab(int id)
    {
        activeTab.SetActive(false);
        tabs[id].SetActive(true);
        activeTab = tabs[id];
    }

}

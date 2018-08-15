using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFuncAssignment : MonoBehaviour {

    private Image img;
    private Button but;



    private void OnValidate()
    {
        img = GetComponent<Image>();
        but = GetComponent<Button>();
    }

    private void Awake()
    {
        int roll = Random.Range(0, 3);
        if(roll == 0)
        {
            but.onClick.AddListener(Red);
        }
        else if (roll == 1)
        {
            but.onClick.AddListener(Green);
        }
        else
        {
            but.onClick.AddListener(Blue);
        }
    }

    private void Red()
    {
        img.color = Color.red;
    }

    private void Green()
    {
        img.color = Color.green;
    }

    private void Blue()
    {
        img.color = Color.blue;
    }

}

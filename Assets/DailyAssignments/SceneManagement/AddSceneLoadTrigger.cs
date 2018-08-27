using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSceneLoadTrigger : MonoBehaviour {

    public string sceneName;



    private void OnTriggerEnter(Collider other)
    {
        AdditiveSceneLoader.Instance.LoadScene(sceneName);
    }

}

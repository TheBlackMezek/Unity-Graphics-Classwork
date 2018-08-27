using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveSceneLoader : MonoBehaviour {

	public static AdditiveSceneLoader Instance { get; private set; }

    public string[] scenesToLoadOnAwake;

    private List<string> loadedScenes = new List<string>();



    private void Awake()
    {
        Instance = this;
        loadedScenes.Add(SceneManager.GetActiveScene().name);

        for(int i = 0; i < scenesToLoadOnAwake.Length; ++i)
        {
            LoadScene(scenesToLoadOnAwake[i]);
        }
    }

    public void LoadScene(string name)
    {
        if(!loadedScenes.Contains(name))
        {
            loadedScenes.Add(name);
            SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        }
    }

    public void UnloadScene(string name)
    {
        if (loadedScenes.Contains(name))
        {
            loadedScenes.Remove(name);
            SceneManager.UnloadSceneAsync(name);
        }
    }

}

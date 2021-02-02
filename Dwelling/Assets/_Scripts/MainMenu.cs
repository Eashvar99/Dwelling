using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    public void Load()
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Gameplay"));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Scene_01", LoadSceneMode.Additive));
        StartCoroutine(LoadingScreen());  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadingScreen()
    {
        float totalProgress = 0;
        for (int i =0; i < scenesToLoad.Count;  ++i)
        {
            while(!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                Debug.Log(totalProgress/scenesToLoad.Count);
                yield return null;
            }
        }
    }
}

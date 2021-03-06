﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
   
    public float loadRange;

    //Scene State
    private bool isLoaded;
    private bool shouldLoad;
    static public Scene scene;

    void Start()
    {
        if(SceneManager.sceneCount > 0)
        {
            for(int i = 0; i < SceneManager.sceneCount; ++i)
            {
                scene = SceneManager.GetSceneAt(i);
                if(scene.name == gameObject.name)
                {
                    isLoaded = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        TriggerCheck();
    }

    void TriggerCheck()
    {
        if(shouldLoad)
        {
            LoadScene();
        }
        else
        {
            UnLoadScene();
        }
    }

    void LoadScene()
    {
        if(!isLoaded)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            isLoaded = true;
        }
    }

    void UnLoadScene()
    {
        if(isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            isLoaded = false;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            shouldLoad = true;
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            shouldLoad = false;
        }
    }
}

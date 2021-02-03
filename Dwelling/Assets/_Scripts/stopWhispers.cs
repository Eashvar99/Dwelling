using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class stopWhispers : MonoBehaviour
{
    public AudioSource audio1;
    public AudioSource audio2;
    
    static float t = 0.0f;

    bool doLerp = false;

    private void Update() 
    {
        if(t<=1 && doLerp == true)
        {
            audio1.volume = Mathf.Lerp(audio1.volume, 0, t);
            audio2.volume = Mathf.Lerp(audio2.volume, 0, t);
            t += 0.05f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            //audio1.Stop();
            //audio2.Stop();
            doLerp = true;
        }
    }
}

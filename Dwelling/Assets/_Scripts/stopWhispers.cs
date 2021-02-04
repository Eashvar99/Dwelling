using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class stopWhispers : MonoBehaviour
{
    public AudioSource audio1;
    public AudioSource audio2;

    public GameObject Key;

    public Transform keyPos;
    
    static float t = 0.0f;

    [HideInInspector]
    public bool doLerp = false;

    bool keyMade = false;

    public bool gotKey = false;

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
        if(other.CompareTag("Player") && keyMade == false)
        {
            Instantiate(Key,keyPos.position, keyPos.rotation);
            keyMade = true;
        }

        if(other.CompareTag("Player") && gotKey == true)
        {
            //do jumpscare
        }
    }
}

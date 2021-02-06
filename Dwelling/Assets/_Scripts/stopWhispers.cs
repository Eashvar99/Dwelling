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

    public GameObject fallingMan;
    public Transform fallingPos;
    bool hitFloor = false;

    GameObject thisMan;
    GameObject player;

    bool bodyThud = false;
    bool playOnce = false;
    public AudioClip thudNoise;
    private void Start() 
    {
        player = GameObject.Find("FirstPerson-AIO");    
    }
    private void Update() 
    {
        if(t<=1 && doLerp == true)
        {
            audio1.volume = Mathf.Lerp(audio1.volume, 0, t);
            audio2.volume = Mathf.Lerp(audio2.volume, 0, t);
            t += 0.05f * Time.deltaTime;
        }

        if(hitFloor == true && thisMan.transform.position.y >= 1.19)
        {
            thisMan.transform.position = new Vector3(thisMan.transform.position.x, thisMan.transform.position.y - 1f, thisMan.transform.position.z);
        }
        else if(hitFloor == true && thisMan.transform.position.y < 1.19)
        {
            bodyThud = true;
        }

        if(bodyThud == true && playOnce == false)
        {
            player.GetComponent<AudioSource>().PlayOneShot(thudNoise);
            playOnce = true;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && keyMade == false)
        {
            Instantiate(Key,keyPos.position, keyPos.rotation);
            keyMade = true;
        }

        if(other.CompareTag("Player") && gotKey == true && hitFloor == false)
        {
            //do jumpscare
            thisMan = Instantiate(fallingMan, fallingPos.position, fallingPos.rotation);
            hitFloor = true;
        }
    }
}

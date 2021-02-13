using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projector : MonoBehaviour
{
    public GameObject player;
    public GameObject projCam;

    int frame = 0;

    public GameObject room3Key;
    public Transform room3KeyPos;

    GameObject scriptKey;

    public AudioSource music;
    public AudioClip violin;
    public AudioClip violinReverse;

    [HideInInspector]
    public bool alreadyDid = false;
    bool startReverse = false;

    [HideInInspector]
    public bool onProjector = false;
    void Start()
    {
        projCam = Instantiate(projCam, this.transform.position, this.transform.rotation);
        projCam.GetComponent<Camera>().enabled = false;

        scriptKey = Instantiate(room3Key, room3KeyPos.position, room3KeyPos.rotation);
        scriptKey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(startReverse == true)
        {
            if(Input.GetButtonDown("LeaveCam") && onProjector == true)
            {
                player.GetComponentInChildren<Camera>().enabled = true;
                projCam.GetComponent<Camera>().enabled = false;
                onProjector = false;
            }
            else if(onProjector == true)
            {
                player.GetComponentInChildren<Camera>().enabled = false;
                projCam.GetComponent<Camera>().enabled = true;

                if(Input.GetKeyDown(KeyCode.A) && frame > 0)
                {
                    //Debug.Log(frame);
                    //play move animation in reverse
                    frame--;
                }
                else if(Input.GetKeyDown(KeyCode.D) && frame < 30)
                {
                    //Debug.Log(frame);
                    //play movie animation forward
                    frame++;
                }
                if(frame <= 15 && frame >= 10)
                {
                    scriptKey.SetActive(true);
                }
                else
                {
                    scriptKey.SetActive(false);
                }
            }
        }
        else if(alreadyDid == true && frame < 30)
        {
            frame ++;
            if(frame == 30)
            {
                startReverse = true;
            }
        }
        

    }
}

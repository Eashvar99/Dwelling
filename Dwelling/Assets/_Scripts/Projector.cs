using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projector : MonoBehaviour
{
    public GameObject player;
    public GameObject projCam;

    [HideInInspector]
    public bool onProjector = false;
    void Start()
    {
        projCam = Instantiate(projCam, this.transform.position, this.transform.rotation);
        projCam.GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void Update()
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

            if(Input.GetKeyDown(KeyCode.A))
            {
                //play move animation in reverse
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                //play movie animation forward
            }
        }
        

    }
}

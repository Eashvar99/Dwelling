using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    RaycastHit hitInfo;
    public Transform lampPos;
    bool lampPickup = false;
    [HideInInspector]
    public GameObject lamp;
    private int layerMask = ~(1 << 9);

    bool room2Key = false;
    bool room4Key = false;
    stopWhispers stopWhisp;
    Projector projector;

    // Start is called before the first frame update
    void Start()
    {
        stopWhisp = GameObject.FindObjectOfType<stopWhispers>();
        projector = GameObject.FindObjectOfType<Projector>();
    }

    // Update is called once per frame
    void Update()
    {
          if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, 7.0f, layerMask))
        {
            if(hitInfo.collider != null)
            { 
                //Debug.Log(hitInfo.collider.name);
                //Room 1
                if(Input.GetButtonDown("Interact") && hitInfo.collider.name == "Lamp" && lampPickup == false)
                {
                    lamp = hitInfo.collider.gameObject;
                    lampPickup = true;
                }

                //Room 2
                if(Input.GetButtonDown("Interact") && hitInfo.collider.name == "Room2Key(Clone)" && room2Key == false)
                {
                    Destroy(hitInfo.collider.gameObject);
                    stopWhisp.doLerp = true;
                    stopWhisp.gotKey = true;
                    room2Key = true;
                }

                //Room 3
                if(Input.GetButtonDown("Interact") && hitInfo.collider.name == "Projector")
                {
                    projector.onProjector = true;
                }

                //Room 4
                if(Input.GetButtonDown("Interact") && hitInfo.collider.name == "Room4Key" && room4Key == false)
                {
                    Destroy(hitInfo.collider.gameObject);
                    room4Key = true;
                }

                //Opening Doors
                if(Input.GetButtonDown("Interact") && hitInfo.collider.name == "Door1" && lampPickup == true)
                {
                    Destroy(hitInfo.collider.gameObject);
                }
                else if(Input.GetButtonDown("Interact") && hitInfo.collider.name == "Door2" && room2Key == true)
                {
                    Destroy(hitInfo.collider.gameObject);
                }
                else if(Input.GetButtonDown("Interact") && hitInfo.collider.name == "Door4" && room4Key == true)
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
            
        }

        if(lampPickup == true)
        {
            lamp.transform.position = lampPos.position;
            lamp.transform.rotation = lampPos.rotation;
        }

    }
}

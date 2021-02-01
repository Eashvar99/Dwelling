using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    RaycastHit hitInfo;
    public Transform lampPos;
    bool lampPickup = false;
    GameObject lamp;
    private int layerMask = ~(1 << 9);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, 20.0f, layerMask))
        {
            if(hitInfo.collider != null)
            {
                if(Input.GetButtonDown("Interact") && hitInfo.collider.name == "Lamp" && lampPickup == false)
                {
                    lamp = hitInfo.collider.gameObject;
                    lampPickup = true;
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

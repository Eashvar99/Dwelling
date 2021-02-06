using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHeads : MonoBehaviour
{
    GameObject[] heads;
    bool entered = false;

    static public bool startRotate = false;
    
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPerson-AIO");
        heads = GameObject.FindGameObjectsWithTag("Head");
    }

    // Update is called once per frame
    void Update()
    {
        if(startRotate == true)
        {
            for(int i = 0; i < heads.Length; i++)
            {
                heads[i].transform.LookAt(player.transform.position);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHallway : MonoBehaviour
{
    public GameObject WallLeft;
    public GameObject WallRight;
    public GameObject WallTop;

    public GameObject aroundWalls;

    //instatiate another prefab of left,right and top wall.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(this.name == "Move1" && Player.hallwayCounter == 0)
        {   
            WallLeft.transform.position = new Vector3(WallLeft.transform.position.x, WallLeft.transform.position.y, WallLeft.transform.position.z + 30f);
            WallRight.transform.position = new Vector3(WallRight.transform.position.x, WallRight.transform.position.y, WallRight.transform.position.z + 30f);
            WallTop.transform.position = new Vector3(WallTop.transform.position.x, WallTop.transform.position.y, WallTop.transform.position.z + 30f);
            Player.hallwayCounter += 1;
        }
        else if(this.name == "Move2" && Player.hallwayCounter == 1)
        {   
            WallLeft.transform.position = new Vector3(WallLeft.transform.position.x, WallLeft.transform.position.y, WallLeft.transform.position.z + 30f);
            WallRight.transform.position = new Vector3(WallRight.transform.position.x, WallRight.transform.position.y, WallRight.transform.position.z + 30f);
            WallTop.transform.position = new Vector3(WallTop.transform.position.x, WallTop.transform.position.y, WallTop.transform.position.z + 30f);
            Player.hallwayCounter += 1;
        }
        else if(this.name == "Move3" && Player.hallwayCounter == 2)
        {   
            WallLeft.transform.position = new Vector3(WallLeft.transform.position.x, WallLeft.transform.position.y, WallLeft.transform.position.z + 18f);
            WallRight.transform.position = new Vector3(WallRight.transform.position.x, WallRight.transform.position.y, WallRight.transform.position.z + 18f);
            WallTop.transform.position = new Vector3(WallTop.transform.position.x, WallTop.transform.position.y, WallTop.transform.position.z + 18f);
            Player.hallwayCounter += 1;
        }
    }
}

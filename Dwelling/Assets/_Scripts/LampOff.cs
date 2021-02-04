using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampOff : MonoBehaviour
{
    public GameObject spotlight;
    public GameObject demonSpotlight;
    public GameObject gunArm;

    public GameObject kidTrigger;

    public GameObject RoomKey4;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && this.name == "LampOff")
        {
            player.lamp.transform.GetChild(0).GetComponent<Light>().enabled = false;
            player.lamp.transform.GetChild(1).GetComponent<Light>().enabled = false;
            
            spotlight.SetActive(true);
            kidTrigger.SetActive(true);
        }

        if(other.CompareTag("Player") && this.name == "kidTrigger")
        {
            player.lamp.transform.GetChild(0).GetComponent<Light>().enabled = false;
            player.lamp.transform.GetChild(1).GetComponent<Light>().enabled = false;
            
            StartCoroutine(gunShot());
        }
    }

    IEnumerator gunShot()
    {
        yield return new WaitForSeconds(1f);
        gunArm.SetActive(true);
        RoomKey4.SetActive(true);
        demonSpotlight.SetActive(true);
        yield return new WaitForSeconds(2f);
        gunArm.SetActive(false);
        spotlight.SetActive(false);
    }
}

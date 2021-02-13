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

    public AudioSource audio1;
    public AudioSource audio2;

    Player player;
    bool entered1 = false;
    bool entered2 = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && this.name == "LampOff" && entered1 == false)
        {
            player.lamp.transform.GetChild(0).GetComponent<Light>().enabled = false;
            player.lamp.transform.GetChild(1).GetComponent<Light>().enabled = false;
            
            audio1.Play();
            spotlight.SetActive(true);
            kidTrigger.SetActive(true);

            entered1 = true;
        }

        if(other.CompareTag("Player") && this.name == "kidTrigger" && entered2 == false)
        {
            player.lamp.transform.GetChild(0).GetComponent<Light>().enabled = false;
            player.lamp.transform.GetChild(1).GetComponent<Light>().enabled = false;
            
            entered2 = true;
            StartCoroutine(gunShot());
        }
    }

    IEnumerator gunShot()
    {
        yield return new WaitForSeconds(1f);
        gunArm.SetActive(true);
        RoomKey4.SetActive(true);
        audio2.Play();
        demonSpotlight.SetActive(true);
        yield return new WaitForSeconds(2f);
        gunArm.SetActive(false);
        spotlight.SetActive(false);
    }
}

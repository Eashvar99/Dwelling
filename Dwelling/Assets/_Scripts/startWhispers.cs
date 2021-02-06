using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startWhispers : MonoBehaviour
{
    bool entered = false;
    public AudioSource audio1;
    public AudioSource audio2;

    public AudioSource neckSnap1;
    public AudioSource neckSnap2;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && entered == false)
        {
            entered = true;
            StartCoroutine(StartRotating());
        }
    }

    IEnumerator StartRotating()
    {
        RotateHeads.startRotate = true;
        neckSnap1.Play();
        neckSnap2.Play();
        yield return new WaitForSeconds(1f);
        neckSnap1.enabled = false;
        neckSnap2.enabled = false;
        yield return new WaitForSeconds(1f);
        audio1.Play();
        audio2.Play();
    }
}

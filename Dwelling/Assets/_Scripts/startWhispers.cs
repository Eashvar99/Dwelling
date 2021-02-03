using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startWhispers : MonoBehaviour
{
    public AudioSource audio1;
    public AudioSource audio2;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            
            audio1.Play();
            audio2.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLevitationHeavy : MonoBehaviour
{
    public GameObject HeavyFly;

    //public AudioClip ;
    //public AudioSource audioSrc;

    private void Start()
    {
        //audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HeavyFly.SetActive(false);
            //audioSrc.PlayOneShot(, 0.7f);
            //Destroy(audioSrc, 1.7f);
        }
        else
        {
            HeavyFly.SetActive(true);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionForGun : MonoBehaviour
{

    public GameObject Pistol;
    public GameObject Heavy;
    public GameObject CounterAmmo;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PistolGunSpawn"))
        {
            Pistol.SetActive(true);
            CounterAmmo.SetActive(true);
    
        }


        if (other.gameObject.CompareTag("HeavyGunSpawn"))
        {
            Heavy.SetActive(true);
            Pistol.SetActive(false);
        }
    }
}

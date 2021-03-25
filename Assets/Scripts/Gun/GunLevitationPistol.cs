using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLevitationPistol : MonoBehaviour
{
    public GameObject PistolFly;
    public GameObject ArrowOne;
    public GameObject ArrowTwo;

    private void Start()
    {
        ArrowOne.SetActive(true);
        ArrowTwo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PistolFly.SetActive(false);
            ArrowOne.SetActive(false);
            ArrowTwo.SetActive(true);
        }
        else
        {
            PistolFly.SetActive(true);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator anim;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            anim.Play("OpenDoor");
            //Son Ouverture Porte
        }
    }
}

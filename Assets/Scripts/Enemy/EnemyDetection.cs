using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{

    public List<GameObject> Enemies = new List<GameObject>();
    public GameObject EnemyObj;
    public int EnemiesAlive;
    public GameObject hb;
    public Animator animator;


    private void Start()
    {
        foreach(Transform child in EnemyObj.transform)
        {
            if(child.gameObject.CompareTag("Enemy"))
            {
                Enemies.Add(child.gameObject);
            }
        }

        EnemiesAlive = Enemies.Count;
        hb.SetActive(false);
    }

    public void RemoveEnemy()
    {
        EnemiesAlive --;
        if(EnemiesAlive <= 0)
        {
            OpenDoor();
            hb.SetActive(true);
            //Son de fin de salle
        }
    }

    public void OpenDoor()
    {
       animator.Play("DoorOpen");
    }

}
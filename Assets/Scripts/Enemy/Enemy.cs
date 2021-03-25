using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public float lookRadius = 10f;
    public Animator animator;

    [SerializeField] private float _health = 50f;

    GameObject target;
    NavMeshAgent agent;
    public bool dead = false;
    public EnemyDetection Detector;

    public GameObject EHand;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerDetect");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            animator.SetBool("Idle", true);

            if (distance <= lookRadius && !dead)
            {
                //se dirige vers la position du player
                agent.SetDestination(target.transform.position);
                animator.SetBool("Walk", true);
                animator.SetBool("Idle", false);
            }
            
             if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                EHand.SetActive(true);
            }
            else
            {
                EHand.SetActive(false);
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerDetect") && !dead)
        {
            animator.SetBool("Attack", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerDetect") && !dead)
        {
            animator.SetBool("Attack", false);
        }
    }

    public void TakeDamage(float amount)
    {
        if (!dead)
        {
            _health -= amount;

            if (_health <= 0f)
            {
                Dead();
            }
        }
    }

    void Dead()
    {
        agent.isStopped = true;
        animator.Play("Die");
        dead =true;
        Detector.RemoveEnemy();
        Destroy(transform.gameObject, 3);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

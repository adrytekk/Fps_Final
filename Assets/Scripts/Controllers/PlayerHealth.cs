using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyHand"))
        {
            TakeDamage(20);
        }

        if (other.gameObject.CompareTag("Spike"))
        {
            TakeDamage(10);
        }

        if(other.gameObject.CompareTag("HealthBonus"))
        {
            currentHealth = maxHealth;
            healthBar.setHealth(currentHealth);
            other.gameObject.SetActive(false); 
        }

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.setHealth(currentHealth);
    }
}

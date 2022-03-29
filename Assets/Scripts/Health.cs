using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 1f;
    float currentHealth;
    HealthBar healthBar;

    void Awake()
    {
        currentHealth = maxHealth;
        healthBar = GetComponent<HealthBar>();
    }

    void Update()
    {
        healthBar.SetHealth(currentHealth, maxHealth);
        Die();

    }

    void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
    }
}

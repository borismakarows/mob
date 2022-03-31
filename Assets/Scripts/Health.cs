using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 1f;
    float currentHealth;

    Canon canon;

    void Awake()
    {
        canon = FindObjectOfType<Canon>();
        currentHealth = maxHealth;
    }


    void Update()
    {
        Die();
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    void Die()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.CompareTag("Bullet"))
            {
                canon.Target = null;
            }
            Destroy(gameObject);
        }
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
    }
}

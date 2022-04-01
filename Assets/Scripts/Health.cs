using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float maxHealth = 1f;
    float currentHealth;

    GamePlayUI gamePlayUI;
    Canon canon;

    void Awake()
    {
        gamePlayUI = FindObjectOfType<GamePlayUI>();
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

    public int GetDamage()
    {
        return damage;
    }

    void Die()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.CompareTag("Bullet") && canon.Target.gameObject == gameObject)
            {
                canon.Target = null;
            }

            if (gameObject.CompareTag("Target"))
            {
                gamePlayUI.Won();
            }

            Destroy(gameObject);
        }
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
    }
}

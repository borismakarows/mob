using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float health = 1f;

    void Update()
    {
        Die();    
    }

    void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
            Destroy(other.gameObject);
        }
    }
}

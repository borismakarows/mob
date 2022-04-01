using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;

    Animator myAnimator;

    Health myHealth;

    [SerializeField] Vector3 playerOffset;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float deadDelay = 1f;

    GamePlayUI gamePlayUI;

    void Awake()
    {
        gamePlayUI = FindObjectOfType<GamePlayUI>();
        myAnimator = GetComponent<Animator>();
        myHealth = GetComponent<Health>();
        player = FindObjectOfType<PlayerMovement>().gameObject.transform;
        transform.rotation =  Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
    }
    void Update()
    {
        Move();    
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position + playerOffset, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            gamePlayUI.Lose();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Animator targetAnim = other.gameObject.GetComponent<Animator>();

            targetAnim.SetBool("Attack", true);

            StartCoroutine(Damage(deadDelay,other.gameObject, myHealth.GetDamage()));
        }
    }

    IEnumerator Damage(float delay, GameObject otherGameObject, int damage)
    {
        myAnimator.SetBool("Attack", true);
        
        Health targetHealth = otherGameObject.GetComponent<Health>();
        
        yield return new WaitForSecondsRealtime(delay);
        
        targetHealth.ModifyHealth(-damage);

        myHealth.ModifyHealth(- targetHealth.GetDamage());
    }

}

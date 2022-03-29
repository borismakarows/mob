using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    Touch touch;
    [SerializeField] float speedModifier = 0.01f;
    [SerializeField] Vector2 boundsX;
    
    [Header("Bullet")]
    [SerializeField] GameObject bullet;
    [SerializeField] Vector3 bulletDistanceToPlayer;
    [SerializeField] float bulletDelay;
    float bulletDelayAtStart;
    GameObject bulletsParent;


    void Awake()
    {
        bulletsParent = GameObject.FindGameObjectWithTag("Parent");
        bulletDelayAtStart = bulletDelay;
    }

    void Start()
    {
        bulletDelay = 0f;
    }

    

    void Update()
    {
        InitBoundsX();
        Move();
    }

   void InitBoundsX()
    {
        if (transform.position.x > boundsX.x)
        {
            transform.position = new Vector3(boundsX.x, transform.position.y, transform.position.z);
        }

        if (transform.position.x < boundsX.y)
        {
            transform.position = new Vector3(boundsX.y, transform.position.y, transform.position.z);
        }
    }

   void Move()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            bulletDelay -= Time.deltaTime;
            if (bulletDelay < 0)
            {
                Vector3 instancePos = new Vector3(transform.position.x + bulletDistanceToPlayer.x,
                                                   transform.position.y + bulletDistanceToPlayer.y,
                                                   transform.position.z + bulletDistanceToPlayer.z);
                Instantiate(bullet, instancePos, Quaternion.identity, bulletsParent.transform);
                bulletDelay = bulletDelayAtStart;
            }

            if (touch.phase == UnityEngine.TouchPhase.Moved)
            {

                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier * Time.deltaTime,
                    transform.position.y,
                    transform.position.z);
            }
        }
        else if (Input.touchCount == 0)
        {
            bulletDelay -= Time.deltaTime;
        }
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    Touch touch;
    PlayerUI playerUI;
    [SerializeField] float speedModifier = 0.01f;
    public float minBoundsX;
    public float maxBoundsX;
    
    [Header("Bullet")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bigBullet;
    [SerializeField] Vector3 bulletDistanceToPlayer;
    [SerializeField] float bulletDelay;
    float bulletDelayAtStart;
    
    GameObject bulletsParent;


    void Awake()
    {
        bulletsParent = GameObject.FindGameObjectWithTag("Parent");
        bulletDelayAtStart = bulletDelay;
        playerUI = GetComponent<PlayerUI>();
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
        if (transform.position.x < minBoundsX)
        {
            transform.position = new Vector3(minBoundsX, transform.position.y, transform.position.z);
        }

        if (transform.position.x > maxBoundsX)
        {
            transform.position = new Vector3(maxBoundsX, transform.position.y, transform.position.z);
        }
    }

   void Move()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            bulletDelay -= Time.deltaTime;

            if (touch.phase == UnityEngine.TouchPhase.Moved)
            {

                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier * Time.deltaTime,
                    transform.position.y,
                    transform.position.z);
            }


            if (playerUI.ultiSlider.value == playerUI.ultiSlider.maxValue &&
                    touch.phase == UnityEngine.TouchPhase.Began)
            {
                Vector3 instancePos = new Vector3(transform.position.x + bulletDistanceToPlayer.x,
                                                   transform.position.y + bulletDistanceToPlayer.y,
                                                   transform.position.z + bulletDistanceToPlayer.z);

                playerUI.ResetSliderPoint();
                Instantiate(bigBullet, instancePos, Quaternion.Euler(new Vector3(0,2.4f,0)), bulletsParent.transform);
            }


            else if (bulletDelay < 0)
            {

                Vector3 instancePos = new Vector3(transform.position.x + bulletDistanceToPlayer.x,
                                                   transform.position.y + bulletDistanceToPlayer.y,
                                                   transform.position.z + bulletDistanceToPlayer.z);

                playerUI.AddUltiPoint(10);
                Instantiate(bullet, instancePos, Quaternion.identity, bulletsParent.transform);

                bulletDelay = bulletDelayAtStart;
            }

            
        }
        else if (Input.touchCount == 0)
        {
            bulletDelay -= Time.deltaTime;
        }
    }


}

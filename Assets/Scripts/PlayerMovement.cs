using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    Touch touch;
    [SerializeField] float speedModifier = 0.01f;
    
    [Header("Bullet")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletsParent;
    [SerializeField] float bulletDelay;
    float bulletDelayAtStart;

    void Awake()
    {
        bulletDelayAtStart = bulletDelay;
    }

    void Start()
    {
        bulletDelay = 0f;
    }

   
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            bulletDelay -= Time.deltaTime;
            if (bulletDelay < 0)
            {
                Vector3 instancePos = new Vector3(transform.position.x, 3.16f, transform.position.z + 0.7f);
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


    }
}

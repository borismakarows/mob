using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    GameObject player;
    [SerializeField] Vector3 followOffset;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, 
                                         player.transform.position.y + followOffset.y,
                                         player.transform.position.z + followOffset.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Consts")]
    [HideInInspector] public GameObject target;
    Transform bulletParent;
    [SerializeField] Vector3 bulletSpawnPosDistance;
    
    [Header("Game Feel")]
    [SerializeField] float bulletSpeed = 1f;
    
    [HideInInspector] public bool firstTime = true;

    [HideInInspector] public bool inZone;

    
    
    
    void Start()
    {
        bulletParent = GameObject.FindGameObjectWithTag("Parent").transform;
        target = GameObject.FindGameObjectWithTag("Target");
    }

    void Update()
    {
        if (target == null) { return; } 
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boost")) 
        {
            Boosts currentBoost = other.gameObject.GetComponent<Boosts>();
            if (currentBoost.GetSign() == Boosts.multiplyKey && firstTime)
            {
                firstTime = false;

                Multiplication(currentBoost.GetNumber());
            }
            else if (currentBoost.GetSign() == Boosts.plusKey && firstTime)
            {
                firstTime = false;
                Plus(currentBoost.GetNumber());
            }    
        }   
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boost"))
        {
            firstTime = true;
        }
    }

    void Multiplication(int number)
    {
        List<GameObject> currentClones = new List<GameObject>();
  
        for (int i = number; i > 1; i--)
        {
            float[] oppositeSpawn = new float[] { 1, -1 }; 
            if (i == number)
            {
                bulletSpawnPosDistance = new Vector3(
                    bulletSpawnPosDistance.x * oppositeSpawn[0]
                    , bulletSpawnPosDistance.y, 
                    bulletSpawnPosDistance.z);
                GameObject clone = Instantiate(gameObject, transform.position + bulletSpawnPosDistance, Quaternion.identity, bulletParent);
                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }
            else if (i == number - 1)
            {
                bulletSpawnPosDistance = new Vector3(
                    bulletSpawnPosDistance.x * oppositeSpawn[1]
                    , bulletSpawnPosDistance.y,
                    bulletSpawnPosDistance.z);
                GameObject clone = Instantiate(gameObject, transform.position + bulletSpawnPosDistance, Quaternion.identity, bulletParent);
                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }
            
            else
            {
                bulletSpawnPosDistance = new Vector3(
                    bulletSpawnPosDistance.x * oppositeSpawn[Random.Range(0,oppositeSpawn.Length)]
                    , bulletSpawnPosDistance.y,
                    bulletSpawnPosDistance.z);
                GameObject clone = Instantiate(gameObject,
                                               currentClones[currentClones.Count - 1].gameObject.transform.position + bulletSpawnPosDistance,
                                               Quaternion.identity, bulletParent);
                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }
        }
    }

    void Plus(int number)
    {
        List<GameObject> currentClones = new List<GameObject>();

        for (int i = number; i > 0; i--)
        {
            float[] oppositeSpawn = new float[] { 1, -1 };
            if (i == number)
            {
                bulletSpawnPosDistance = new Vector3(
                    bulletSpawnPosDistance.x * oppositeSpawn[0]
                    , bulletSpawnPosDistance.y,
                    bulletSpawnPosDistance.z);
                GameObject clone = Instantiate(gameObject, transform.position + bulletSpawnPosDistance, Quaternion.identity, bulletParent);
                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }
            else if (i == number - 1)
            {
                bulletSpawnPosDistance = new Vector3(
                    bulletSpawnPosDistance.x * oppositeSpawn[1]
                    , bulletSpawnPosDistance.y,
                    bulletSpawnPosDistance.z);
                GameObject clone = Instantiate(gameObject, transform.position + bulletSpawnPosDistance, Quaternion.identity, bulletParent);
                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }

            else
            {
                bulletSpawnPosDistance = new Vector3(
                    bulletSpawnPosDistance.x * oppositeSpawn[Random.Range(0, oppositeSpawn.Length)]
                    , bulletSpawnPosDistance.y,
                    bulletSpawnPosDistance.z);
                GameObject clone = Instantiate(gameObject,
                                               currentClones[currentClones.Count - 1].gameObject.transform.position + bulletSpawnPosDistance,
                                               Quaternion.identity, bulletParent);
                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }
        }
    }

    
}

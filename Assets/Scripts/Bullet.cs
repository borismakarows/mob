using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Consts")]
    [SerializeField] Transform bulletParent;
    [SerializeField] GameObject target;
    [SerializeField] Vector3 bulletSpawnPosDistance;
    [Header("Game Feel")]
    [SerializeField] float bulletSpeed = 1f;

    Bullet[] bullets;
    [HideInInspector] public bool firstTime = true;

    void Start()
    {
        bulletParent = GameObject.FindGameObjectWithTag("Parent").transform;
        
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
        int bulletsCount = bulletParent.GetComponentsInChildren<Bullet>().Length;
        Debug.Log(bulletsCount);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boost")) 
        {
            Boosts currentBoost = other.gameObject.GetComponent<Boosts>();
            if (currentBoost.GetSign() == "Multiply" && firstTime)
            {
                firstTime = false;

                Multiplication(currentBoost.GetNumber());
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
                    bulletSpawnPosDistance.x * oppositeSpawn[Random.Range(0,oppositeSpawn.Length)]
                    , bulletSpawnPosDistance.y, 
                    bulletSpawnPosDistance.z * oppositeSpawn[Random.Range(0, oppositeSpawn.Length)]);
                GameObject clone = Instantiate(gameObject, transform.position + bulletSpawnPosDistance, Quaternion.identity, bulletParent);
                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }
            else
            {
                GameObject clone = Instantiate(gameObject,
                                               currentClones[currentClones.Count - 1].gameObject.transform.position + bulletSpawnPosDistance,
                                               Quaternion.identity, bulletParent);
                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }
        }
    }
}

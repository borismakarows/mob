using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Consts")]
    [HideInInspector] public GameObject target;
    [SerializeField] Vector3 bulletSpawnPosDistance;
    Transform bulletParent;
    Animator myAnimator;
    

    Canon canon;
    

    [Header("Game Feel")]
    [SerializeField] float bulletSpeed = 1f;
    [SerializeField] float spawnDelay = 0.2f;
    [SerializeField] float destroyDelay = 0.2f;

    [Header("Conditions")]
    [HideInInspector] public bool isAttacking;
    [HideInInspector] public bool firstTime = true;
    [HideInInspector] public bool inZone;


    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        canon = FindObjectOfType<Canon>();
    }

    void Start()
    {
        bulletParent = GameObject.FindGameObjectWithTag("Parent").transform;
        target = GameObject.FindGameObjectWithTag("Target");
    }

    void Update()
    {
        if (target == null) { return; } 
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
        myAnimator.SetBool("Attack01", isAttacking);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boost")) 
        {
            
            Boosts currentBoost = other.gameObject.GetComponent<Boosts>();
            if (currentBoost.GetNumber() > 0)
            {
                if (currentBoost.GetSign() == Boosts.multiplyKey && firstTime)
                {
                    firstTime = false;

                    StartCoroutine(Multiplication(currentBoost.GetNumber()));
                }
                else if (currentBoost.GetSign() == Boosts.plusKey && firstTime)
                {
                    firstTime = false;
                    StartCoroutine(Plus(currentBoost.GetNumber()));
                }
            }
            
        }   
        else if (other.CompareTag("Target"))
        {
            StartCoroutine(DestroyBullet(destroyDelay, other.gameObject));
        }

        else if (other.CompareTag("CanonBall"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            canon.Target = null;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boost"))
        {
            firstTime = true;
        }
    }

    IEnumerator DestroyBullet(float delay, GameObject otherGameObject)
    {
        isAttacking = true;
        Health targetHealth = otherGameObject.GetComponent<Health>();
        targetHealth.ModifyHealth(-1);
        yield return new WaitForSecondsRealtime(delay);
        Destroy(gameObject);
    }

    // instantiate in a pattern by using mod. // Berkay Sert
    IEnumerator Multiplication(int number)
    {
        List<GameObject> currentClones = new List<GameObject>();
  
        for (int i = 0; i < number - 1; i++)
        {
            float[] oppositeSpawn = new float[] { 1, -1 };

            if (i == 0)
            {
                Vector3 bulletSpawnPosDistance2 = new Vector3(
                                     bulletSpawnPosDistance.x * oppositeSpawn[0], 0, bulletSpawnPosDistance.z);


                GameObject clone = Instantiate(gameObject, transform.position + bulletSpawnPosDistance2, Quaternion.identity, bulletParent);

                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }

            if (i % 3 == 0 && i != 0)
            {
                Vector3 bulletSpawnPosDistance2 = new Vector3(
                                         bulletSpawnPosDistance.x * oppositeSpawn[0], 0, bulletSpawnPosDistance.z);


                GameObject clone = Instantiate(gameObject, currentClones[currentClones.Count - 1].transform.position + bulletSpawnPosDistance2, Quaternion.identity, bulletParent);

                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }

            if (i % 3 == 1)
            {
                Vector3 bulletSpawnPosDistance2 = new Vector3(
                                       oppositeSpawn[1] * 2 * bulletSpawnPosDistance.x, 0, 0);

                GameObject clone = Instantiate(gameObject, currentClones[currentClones.Count - 1].transform.position + bulletSpawnPosDistance2, Quaternion.identity, bulletParent);

                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }

            if (i % 3 == 2)
            {
                Vector3 bulletSpawnPosDistance2 = new Vector3(
                                          bulletSpawnPosDistance.x * oppositeSpawn[0], 0, bulletSpawnPosDistance.z);

                GameObject clone = Instantiate(gameObject, currentClones[currentClones.Count - 1].transform.position + bulletSpawnPosDistance2, Quaternion.identity, bulletParent);

                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }

            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }

    IEnumerator Plus(int number)
    {
        List<GameObject> currentClones = new List<GameObject>();
        

        for (int i = 0; i < number; i++)
        {
            float[] oppositeSpawn = new float[] { 1, -1 };
            
            if (i == 0)
            {
                    Vector3 bulletSpawnPosDistance2 = new Vector3(
                                         bulletSpawnPosDistance.x * oppositeSpawn[0], 0, bulletSpawnPosDistance.z);


                    GameObject clone = Instantiate(gameObject, transform.position + bulletSpawnPosDistance2, Quaternion.identity, bulletParent);

                    clone.GetComponent<Bullet>().firstTime = false;
                    currentClones.Add(clone);
            }

            if (i % 3 == 0 && i != 0)
            {
                Vector3 bulletSpawnPosDistance2 = new Vector3(
                                         bulletSpawnPosDistance.x * oppositeSpawn[0], 0, bulletSpawnPosDistance.z);


                GameObject clone = Instantiate(gameObject, currentClones[currentClones.Count - 1].transform.position + bulletSpawnPosDistance2, Quaternion.identity, bulletParent);
                  
                clone.GetComponent<Bullet>().firstTime = false;
                currentClones.Add(clone);
            }

            if (i % 3 == 1)                
            {
                   Vector3 bulletSpawnPosDistance2 = new Vector3(
                                          oppositeSpawn[1] * 2 * bulletSpawnPosDistance.x , 0, 0);

                    GameObject clone = Instantiate(gameObject, currentClones[currentClones.Count - 1].transform.position + bulletSpawnPosDistance2, Quaternion.identity, bulletParent);

                    clone.GetComponent<Bullet>().firstTime = false;
                    currentClones.Add(clone);
            }

            if (i % 3 == 2)
            {
                    Vector3 bulletSpawnPosDistance2 = new Vector3(
                                              bulletSpawnPosDistance.x * oppositeSpawn[0], 0, bulletSpawnPosDistance.z);

                    GameObject clone = Instantiate(gameObject, currentClones[currentClones.Count - 1].transform.position + bulletSpawnPosDistance2, Quaternion.identity, bulletParent);

                    clone.GetComponent<Bullet>().firstTime = false;
                    currentClones.Add(clone);
            }

            
            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }

    
}

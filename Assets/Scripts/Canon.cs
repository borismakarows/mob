using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    protected CanonState currentState;

    public Transform Target { get; set; }
    
    public Quaternion DefaultRotation { get; set; }

    public Bullet[] targets;

    [Header("Bounds")]
    public float minBoundz = -5.55f;
    public float maxBoundZ = 23.87f;

    [Header("Aim")]
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 aimOffset;
    [SerializeField] LayerMask layerMask;

    [Header("GameObjects")]
    [SerializeField] Transform rotator;
    [SerializeField] Transform ghostRotator;
    [SerializeField] Transform canonBarrel;
    
    


    public Vector3 AimOffset { get => aimOffset; set => aimOffset = value; }
    public Transform Rotator { get => rotator; set => rotator = value; }
    public Transform GhostRotator { get => ghostRotator; set => ghostRotator = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
    public Transform CanonBarrel { get => canonBarrel; set => canonBarrel = value; }

    protected void Start()
    {
        DefaultRotation = rotator.rotation;
        ChangeState(new IdleState());
    }


    void Update()
    {
        targets = FindObjectsOfType<Bullet>();
        currentState.Update();
    }

    public bool CanSeeTarget(Vector3 direction, Vector3 origin, string tag)
    {
        RaycastHit hit;
        if (Physics.Raycast (origin, direction ,
            out hit,Mathf.Infinity,layerMask))
        {
            if (hit.collider.tag == "Bullet")
            {
                return true;
            }
        }
        return false;
    }

    public void ChangeState(CanonState newState)
    {
       if (newState != null)
        {
            newState.Exit();
        }
        this.currentState = newState;
        newState.Enter(this);
    }

    

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }
}
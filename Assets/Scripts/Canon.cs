using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    
    protected CanonState currentState;

    public Transform Target { get; set; }

    public Quaternion DefaultRotation { get; set; }


    [Header("Aim")]
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 aimOffset;
    [SerializeField] LayerMask layerMask;

    [Header("GameObjects")]
    [SerializeField] Transform rotator;
    [SerializeField] Transform ghostRotator;
    [SerializeField] Transform canonBarrel;
    [SerializeField] GameObject projectile;
    [SerializeField] Animator animator;



    public Vector3 AimOffset { get => aimOffset; set => aimOffset = value; }
    public Transform Rotator { get => rotator; set => rotator = value; }
    public Transform GhostRotator { get => ghostRotator; set => ghostRotator = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
    public Transform CanonBarrel { get => canonBarrel; set => canonBarrel = value; }
    public Animator Animator { get => animator; set => animator = value; }

    protected void Start()
    {
        DefaultRotation = rotator.rotation;
        ChangeState(new IdleState());
    }


    void Update()
    {
        currentState.Update();
    }

    public void Shoot()
    {
        Quaternion headingDirection = Quaternion.FromToRotation(projectile.transform.forward, CanonBarrel.forward);
        Instantiate(projectile, CanonBarrel.position, headingDirection).GetComponent<Projectile>().Direction = CanonBarrel.forward;
    }

    // if you activate this, you can hide from canon.
    public bool CanSeeTarget(Vector3 direction, Vector3 origin, string tag)
    {
        RaycastHit hit;
        if (Physics.Raycast(origin, direction,
            out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.CompareTag("Bullet"))
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

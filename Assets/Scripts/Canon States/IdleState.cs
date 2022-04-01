using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CanonState
{
    public override void Enter(Canon parent)
    {
        base.Enter(parent);
        parent.Animator.SetBool("Shoot", false);
    }

    public override void Update()
    {
        base.Update();
        
        if (parent.Rotator.rotation != parent.DefaultRotation)
        {
            parent.Rotator.rotation = Quaternion.RotateTowards(parent.Rotator.rotation, parent.DefaultRotation, Time.deltaTime * parent.RotationSpeed);
        }


        if (parent.Target != null) { parent.ChangeState(new FindTargetState()); }

    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            parent.Target = other.transform;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetState : CanonState
{
    public override void Update()
    {

        if (parent.Target == null)
        {
            parent.ChangeState(new IdleState());
        }

        parent.GhostRotator.LookAt(parent.Target.position + parent.AimOffset);

        parent.Rotator.rotation = Quaternion.RotateTowards
                                    (parent.Rotator.rotation, parent.GhostRotator.rotation, Time.deltaTime * parent.RotationSpeed);



        if (parent.GhostRotator.rotation.x == parent.Rotator.rotation.x)
        {
            parent.ChangeState(new ShootState());
        }

    }

    public override void OnTriggerExit(Collider other)
    {
        if (other.gameObject == parent.Target.gameObject)
        {
            parent.Target = null;
        }
    }

}

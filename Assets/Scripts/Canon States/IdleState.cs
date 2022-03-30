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
       
        if (parent.targets.Length > 0)
        {
            for (int i = 0; parent.Target == null && i < parent.targets.Length; i++)
            {

                bool inBounds = parent.targets[i].transform.position.z > parent.minBoundz &&
                                parent.targets[i].transform.position.z < parent.maxBoundZ;

                if (inBounds)
                {
                    parent.Target = parent.targets[i].transform;
                }
            }
        }
        
        
        if (parent.Target != null) { parent.ChangeState(new FindTargetState()); }
    }
}

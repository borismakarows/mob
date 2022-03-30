using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : CanonState
{
    bool inBounds;

    public override void Update()
    {
        if (parent.targets.Length == 0)
        {
            parent.Target = null;
        }

        if (parent.Target != null)
        {
            inBounds = parent.Target.position.z > parent.minBoundz &&
            parent.Target.position.z < parent.maxBoundZ;

            parent.Rotator.LookAt(parent.Target.position + parent.AimOffset);
            if (!inBounds)
            {
                parent.Target = null;
            }
        }

        if (parent.Target == null)
        {
            parent.ChangeState(new IdleState());
        }        
    }

    public override void Enter(Canon parent)
    {
        base.Enter(parent);
        parent.Animator.SetBool("Shoot", true);
    }

}

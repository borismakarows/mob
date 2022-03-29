using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : CanonState
{
    public override void Update()
    {
        
        bool inBounds = parent.Target.position.z > parent.minBoundz &&
                        parent.Target.position.z < parent.maxBoundZ;

        
        if (parent.Target != null && inBounds)
        {
            parent.Rotator.LookAt(parent.Target.position + parent.AimOffset);
        }

        else
        {
            parent.ChangeState(new IdleState());
        }

    }

}

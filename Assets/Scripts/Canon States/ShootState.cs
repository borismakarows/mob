using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : CanonState
{

    public override void Update()
    { 
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

    public override void OnTriggerExit(Collider other)
    {
        if (other.gameObject == parent.Target.gameObject)
        {
            parent.Target = null;
        }
    }

}

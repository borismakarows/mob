using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CanonState
{
    protected Canon parent;
    
    
    public virtual void Enter(Canon parent)
    {
        this.parent = parent;
    }

    public virtual void Update()
    {
        
    }

    public virtual void Exit()
    {

    }

    public virtual void OnTriggerEnter(Collider other)
    {

    }

    public virtual void OnTriggerExit(Collider other)
    {
        
    }
}

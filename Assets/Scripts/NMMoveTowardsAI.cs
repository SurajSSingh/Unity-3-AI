using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMMoveTowardsAI : BaseNavMeshAI
{
    public GameObject target;

    public override void UpdateAI()
    {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        } 
    }

    public override void SetNewTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}

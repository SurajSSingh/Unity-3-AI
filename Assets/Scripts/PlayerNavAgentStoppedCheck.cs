using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore.Framework;
using Pada1.BBCore;

[Condition("MyConditions/Player/CheckNavMeshAgentStopped")]
public class PlayerNavAgentStoppedCheck : ConditionBase
{
    [InParam("PlayerNavAgent")]
    public UnityEngine.AI.NavMeshAgent navAgent;

    public override bool Check()
    {
        // Did we reach destination?
        if (navAgent == null)
        {
            return false;
        }
        return navAgent.remainingDistance < navAgent.stoppingDistance;
    }
}

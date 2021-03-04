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

    private bool alreadyChecked;

    public override bool Check()
    {
        if (navAgent == null)
        {
            return false;
        }
        if (alreadyChecked)
        {

        }
        else
        {

        }
        return navAgent.isStopped;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingAIState : SimpleAIState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(mainAI is null)
        {
            mainAI = animator.GetComponentInChildren<TargetingAgent>();
        }
        hasTargetValue = false;
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        // if(typeof(mainAI) == TargetingAgent)
        //{
        //    var targetingAgent = mainAI as TargetingAgent;
        //}

        if(mainAI is TargetingAgent targetingAgent)
        {
            if(!targetingAgent.HasTarget)
            {
                animator.SetBool(hasTargetParam, hasTargetValue);
            }
        }
    }
}

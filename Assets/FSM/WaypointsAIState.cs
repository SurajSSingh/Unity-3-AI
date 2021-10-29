using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsAIState : SimpleAIState
{
    private TargetingAgent targetingAgent = null;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) 
    {
        // If main AI is not assigned, find waypoints agent and assign it to main AI
        if(mainAI is null)
        {
            mainAI = animator.GetComponentInChildren<WaypointsAgent>();
        }
        if(targetingAgent is null)
        {
            targetingAgent = animator.GetComponentInChildren<TargetingAgent>();
        }
        hasTargetValue = true;

        // Afterward, do the normal setup from the SimpleAIState
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if(targetingAgent?.HasTarget ?? false)
        {
            animator.SetBool(hasTargetParam, hasTargetValue); // Switch to targeting state now that we have a target
        }
    }
}

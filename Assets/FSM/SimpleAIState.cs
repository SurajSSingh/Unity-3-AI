using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAIState : StateMachineBehaviour
{
    [SerializeField] BaseAI mainAI;
    [SerializeField] private string hasTargetParam = "hasTarget";
    [SerializeField] private bool hasTargetValue = true; // Has target set value

    public System.Type AIType;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mainAI.AgentStart();
        mainAI.IsUpdating = true;    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //mainAI.AgentUpdate();
        if(animator.GetComponent<TargetingAgent>()?.HasTarget ?? false)
        // If targeting agent is not null and has target, then run the code
        // False by defualt if we get a null value
        {
            animator.SetBool(hasTargetParam, hasTargetValue);
        }    
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mainAI.IsUpdating = false;    
    }
}

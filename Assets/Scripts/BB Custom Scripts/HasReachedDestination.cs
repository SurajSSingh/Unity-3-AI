using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;
using UnityEngine.AI;

[Condition("HasReachedDestination")]
public class HasReachedDestination : GOCondition
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField, InParam("Reaching Distance")] 
    public float reachingDistance = 1.0f;

    public void GetAgent()
    {
        if(agent == null)
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
        }
    }

    private void Start() 
    {
        GetAgent();    
    }

    public override bool Check()
    {
        GetAgent();
        return agent?.remainingDistance < reachingDistance;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TargetingAgent : BaseAI
{
    [SerializeField] private GameObject currentTarget;
    [SerializeField] private List<GameObject> targetList = new List<GameObject>();
    [SerializeField] private string targetTag = "Player";
    [SerializeField] bool autoUpdate = false;

    public bool HasTarget => currentTarget != null;

    void Awake() // Orignially Start
    {
        AgentStart();
    }

    public override void AgentStart()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(IsUpdating || autoUpdate) // Using the "getter" for isUpdating
        {
            AgentUpdate();
        }
    }

    public override void AgentUpdate()
    {
        // We have no target right now
        if(!HasTarget)
        {
            // We have some others we can go to
            if(targetList.Count > 0)
            {
                // Just get the last item in the target list
                int lastIndex = targetList.Count-1;
                currentTarget = targetList[lastIndex];
                targetList.RemoveAt(lastIndex);
                agent.SetDestination(currentTarget.transform.position);
            }
            else
            {
                // We have no more targets, just do nothing
                IsUpdating = false; // Using the "setter" for isUpdating
            }
        }
        // Otherwise, set the destination to the current target's position
        else
        {
            agent.SetDestination(currentTarget.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag(targetTag))
        {
            targetList.Add(other.gameObject);
            AgentUpdate();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
         if(other.CompareTag(targetTag))
        {
            if(targetList.Contains(other.gameObject))
            {
                targetList.Remove(other.gameObject);
            }
            if(currentTarget == other.gameObject)
            {
                currentTarget = null;
            }
            AgentUpdate();
        }
    }
    
}
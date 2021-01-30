using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMWaypointsAI : BaseNavMeshAI
{
    [SerializeField]
    private List<Transform> waypoints = new List<Transform>();

    [SerializeField]
    private int currentWaypoint = 0;

    [SerializeField]
    private float transitionDistance = 0.01f;

    [SerializeField]
    private bool isPathCyclic = true;

    private void Start()
    {
        agent.SetDestination(waypoints[0].position);
    }

    public override void UpdateAI()
    {
        //throw new System.NotImplementedException();
        if(waypoints.Count == 0)
        {
            return;
        }

        //Debug.Log(agent.remainingDistance);

        if (agent.remainingDistance < transitionDistance)
        {
            if (currentWaypoint >= waypoints.Count - 1)
            {
                if (isPathCyclic)
                {
                    currentWaypoint = 0;
                }
                else
                {
                    waypoints.Reverse();
                    currentWaypoint = 0;
                }
            }
            else
            {
                currentWaypoint++;
            }

            agent.SetDestination(waypoints[currentWaypoint].position);
            Debug.Log(agent.remainingDistance);
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(waypoints[i].position,
                waypoints[(i + 1) % waypoints.Count].position);
        }
    }
}

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

    //private float threshold = 0;

    [SerializeField]
    private bool isPathCyclic = true;

    private void Start()
    {
        agent.SetDestination(waypoints[0].position);
        //threshold = transitionDistance * transitionDistance;
    }

    public override void UpdateAI()
    {
        //throw new System.NotImplementedException();
        if(waypoints.Count == 0)
        {
            return;
        }

        //Debug.Log(agent.remainingDistance);
        //Debug.Log($"Dis: {SquareDistance()}");
        if (agent.remainingDistance < transitionDistance )//&& SquareDistance() < threshold)
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

    //private float SquareDistance()
    //{
    //    Vector2 current = new Vector2(transform.position.x, transform.position.z);
    //    Vector2 destination = new Vector2(waypoints[currentWaypoint].position.x,
    //                                      waypoints[currentWaypoint].position.z);

    //    return Vector2.SqrMagnitude(current-destination);
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPathLine : MonoBehaviour
{
    /*
    *   Line --> On every update, change the line to match the current position and agent destination
    *   Agent --> The Nav Mesh Agent, has the destination
    */

    [SerializeField] NavMeshAgent agent;
    [SerializeField] LineRenderer line;

    void Start()
    {
        if(agent == null)
        {
            agent = GetComponentInParent<NavMeshAgent>();
        }
        if(line == null)
        {
            line = GetComponentInChildren<LineRenderer>();
        }
    }

    void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        // Type 1: Direct straight line 
        // Vector3 currentPosition = agent.transform.position;
        // Vector3 targetPosition = agent.destination;
        // Vector3[] updatedPositions = new Vector3[]{currentPosition, targetPosition};


        // Type 2: Create a line that follows calculated path
        if(agent.path == null) return; // If there is no path, just exit the function
        Vector3[] updatedPositions = agent.path.corners; // Has additional in-between points

        line.positionCount = updatedPositions.Length;
        line.SetPositions(updatedPositions);
    }
}

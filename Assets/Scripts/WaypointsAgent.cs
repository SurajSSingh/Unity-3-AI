using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointsAgent : BaseAI
{
    /*
        Nav Mesh Agent for the AI
        List of Vector3 for waypoints (list of positions to go to)
        int for current waypoint

        Start => get reference to agent
        Update => When shift+click happens, try to add the new position to the list; 
                    when just click, override current destination;
                    when the agent reaches the destination, try to go to the next waypoint

    */

    // [SerializeField] NavMeshAgent agent;
    [SerializeField] List<Vector3> waypoints = new List<Vector3>();
    [SerializeField] int current = 0;

    public List<Vector3> GetWaypoints => waypoints;
    public UnityEvent OnClearedWaypoints = new UnityEvent();
    [System.Serializable] public class UnityEvent_Vector3: UnityEvent<Vector3>{}
    public UnityEvent_Vector3 OnWaypointsAdded = new UnityEvent_Vector3();

    private Camera cam;

    void Start()
    {
        // agent = GetComponent<NavMeshAgent>();
        // cam = Camera.main;
        AgentStart();
    }

    public override void AgentStart()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    void Update()
    {
        if(this.IsUpdating)
        {
            AgentUpdate();
        }
    }

    public bool isPlayerAgent = true;
    public override void AgentUpdate()
    {
        if(isPlayerAgent)
        {
            HandleInput();
        }
        CheckAgent();
    }

    private void HandleInput()
    {
        // When you click Left-Mouse-Button (LMB)
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Find out where we clicked
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                // You are also holding Shift (either left or right)
                if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    // Add a new waypoint to the list of waypoints
                    waypoints.Add(hit.point);
                    OnWaypointsAdded?.Invoke(hit.point);
                    // x?.DoSomthing();
                    // same as if(x != null) x.DoSomething();
                }
                // You just click (no shift+click)
                else
                {
                    // Set agent to new destination and clear out old waypoints
                    agent.SetDestination(hit.point);
                    waypoints.Clear();
                    OnClearedWaypoints?.Invoke();
                }
            }
        }
    }

    private void CheckAgent()
    {
        // Make sure agent's remaining distance is within the stopping condition
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            // Case 1: Waypoint is empty => return out of function (can't do anything)
            if(waypoints.Count == 0)
            {
                return; // Exits the function with nothing
            }

            // Case 2a: At the end of the waypoints list
            if(current >= waypoints.Count - 1)
            {
                // Choice 1: Just let agent be stopped => exit the function
                // return;

                // Choice 2: Go back to begin => set current to 0
                current = 0;
            }   
            // Case 2b: Not at the end
            else
            {
                // Move current to next waypoint
                current++;
            }
            // Set new target destination
            agent.SetDestination(waypoints[current]);
        }
    }
}

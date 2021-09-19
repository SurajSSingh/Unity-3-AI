using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshAgent : MonoBehaviour
{
    public Camera mainCamera;
    public NavMeshAgent agent;

    public List<Vector3> destinations;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    destinations.Add(hit.point);
                }
                else
                {
                    agent.SetDestination(hit.point);
                }
            }
        }

        if(agent.remainingDistance < 0.01f && destinations.Count > 0)
        {
            agent.SetDestination(destinations[0]);
            destinations.RemoveAt(0);
        }
    }
}

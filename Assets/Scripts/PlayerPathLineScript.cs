using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPathLineScript : MonoBehaviour
{
    [SerializeField]
    private LineRenderer path;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private List<Vector3> points;

    private Vector3 destination;

    void Start()
    {
        path = GetComponent<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();
        points = new List<Vector3>();
    }

    void Update()
    {
        DisplayPath();
    }

    private void DisplayPath()
    {
        if (agent.path.corners.Length < 2)
        {
            return;
        }

        points.Clear();

        int i = 0;
        while (i < agent.path.corners.Length)
        {
            path.positionCount = agent.path.corners.Length;
            foreach (Vector3 p in agent.path.corners)
            {
                points.Add(p);
            }

            for(int j = 0; j < points.Count; j++)
            {
                path.SetPosition(j, points[j]);
            }
            i++;
        }
    }

}

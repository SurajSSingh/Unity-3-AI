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


    public override void UpdateAI()
    {
        throw new System.NotImplementedException();
    }
}

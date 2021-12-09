using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointObject : MonoBehaviour 
{
    [SerializeField] List<Vector3> waypoints = new List<Vector3>();

    public List<Vector3> GetWaypointList()
    {
        return waypoints;
    }
}

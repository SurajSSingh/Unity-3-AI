using System.Collections.Generic;
using UnityEngine;

public class WaypointsVisualizer : MonoBehaviour
{
    public GameObject waypointPrefab;
    private List<GameObject> currentWaypoints = new List<GameObject>();
    void Start()
    {
        
    }
    public void WaypointAdded(Vector3 position)
    {
        GameObject newPoint = Instantiate(waypointPrefab, position, Quaternion.identity);
        newPoint.transform.parent = this.transform;
        currentWaypoints.Add(newPoint);
    }
    public void WaypointsCleared()
    {
        foreach(GameObject point in currentWaypoints)
        {
            Destroy(point);
        }
        currentWaypoints.Clear();
    }

}

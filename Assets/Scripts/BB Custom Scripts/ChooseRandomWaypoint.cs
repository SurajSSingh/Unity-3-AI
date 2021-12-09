using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using BBUnity.Actions;

[Action("ChooseRandomWaypoint")]
public class ChooseRandomWaypoint : GOAction
{
    public List<Vector3> waypointPositionList;

    [SerializeField, InParam("Waypoints Holder", typeof(GameObject))]
    GameObject waypointHolder = null;

    [SerializeField, OutParam("Current Waypoint Position")]
    Vector3 currentPosition;

    public override void OnStart()
    {
        if(waypointHolder.GetComponent<WaypointObject>() is WaypointObject waypointObject)
        {
            waypointPositionList = waypointObject.GetWaypointList();
        }
        if(waypointPositionList == null || waypointPositionList.Count <= 0) return;
        currentPosition = waypointPositionList[Random.Range(0,waypointPositionList.Count)];
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        if(waypointPositionList == null || waypointPositionList.Count == 0) return TaskStatus.FAILED;

        Vector3 previousPosition = currentPosition;
        currentPosition = waypointPositionList[Random.Range(0,waypointPositionList.Count)];
        if(currentPosition == previousPosition)
        {
            return TaskStatus.FAILED;
        }
        return TaskStatus.COMPLETED;
    }
}

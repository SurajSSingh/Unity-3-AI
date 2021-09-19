using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;

[Action("MyActions/Player/Wander")]
public class PlayerWanderBehavior : BasePrimitiveAction
{
    [InParam("selectedPosition")]
    public Vector3 selectedPosition;

    [InParam("randomeRangeAmount")]
    public Vector3 randomRangeAmount;

    [OutParam("newPosition")]
    public Vector3 newPosition;

    Vector3 FindRandomPosition(Vector3 current, Vector3 range)
    {
        return new Vector3(
                            current.x + Random.Range(-range.x, range.x),
                            current.y + Random.Range(-range.y, range.y),
                            current.z + Random.Range(-range.z, range.z)
                          );
    }

    public override TaskStatus OnUpdate()
    {
        newPosition = FindRandomPosition(selectedPosition, randomRangeAmount);
        return TaskStatus.COMPLETED;
    }
}

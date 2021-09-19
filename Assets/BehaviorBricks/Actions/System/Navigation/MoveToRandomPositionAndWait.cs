using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBUnity.Actions;
using Pada1.BBCore.Tasks;
using Pada1.BBCore;

public class MoveToRandomPositionAndWait : MoveToRandomPosition
{
    [InParam("timer")]
    public float waitTimer = 4f;

    private float elapsedTime = 0;

    public override TaskStatus OnUpdate()
    {
        TaskStatus task = base.OnUpdate();

        if (task == TaskStatus.RUNNING)
        {
            return task;
        }
        else
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= waitTimer)
                return TaskStatus.COMPLETED;
            return TaskStatus.RUNNING;
        }
    }
}

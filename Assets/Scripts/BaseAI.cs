using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseAI : MonoBehaviour
{
    /* Base = Common parts between AI scripts
        * Agent -> The nav mesh agent reference
        * AgentStart() -> what the agent does when starting out
        * AgentUpdate() -> what the agent does every turn
    */

    [SerializeField] protected NavMeshAgent agent;
    private bool isUpdating = true;
    public bool IsUpdating{ 
        get{return isUpdating;} 
        set{isUpdating = value;}
    }    


    public abstract void AgentStart();
    public abstract void AgentUpdate();
}

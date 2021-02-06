using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

abstract public class BaseNavMeshAI : MonoBehaviour
{
    protected Camera mainCamera;
    protected NavMeshAgent agent;

    void Awake()
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

    // Update is called once per frame
    void Update()
    {
        UpdateAI();
    }


    abstract public void UpdateAI();

    virtual public bool CanUpdate()
    {
        return true;
    }

    virtual public void SetNewTarget(GameObject newTarget)
    {
        return;
    }
}

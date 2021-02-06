using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerFound;

    public BaseNavMeshAI patrolState;
    public BaseNavMeshAI chaseState;


    void Start()
    {
        chaseState.enabled = false;
        patrolState.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
            
            playerFound = other.gameObject;
            chaseState.SetNewTarget(playerFound);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerFound = null;
        }
    }

    void FixedUpdate()
    {
        if (playerFound == null && !patrolState.enabled)
        {
            chaseState.enabled = false;
            patrolState.enabled = true;
        }
        else if (playerFound != null && !chaseState.enabled)
        {
            patrolState.enabled = false;
            chaseState.enabled = true;
        }
    }
}

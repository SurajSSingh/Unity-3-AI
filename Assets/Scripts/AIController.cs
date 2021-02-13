using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerFound;

    public BaseNavMeshAI patrolState;
    public BaseNavMeshAI chaseState;

    public GameObject bcPrefab;

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
        else if (playerFound == null && other.GetComponent<BreadcrumbScript>() != null)
        {
            playerFound = other.gameObject;
            chaseState.SetNewTarget(playerFound);
        }
        else if (playerFound != null &&
                 playerFound.GetComponent<BreadcrumbScript>() != null &&
                 other.GetComponent<BreadcrumbScript>() != null)
        {
            playerFound = other.gameObject;
            chaseState.SetNewTarget(playerFound);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerFound = Instantiate(bcPrefab, other.gameObject.transform.position,
                                                other.gameObject.transform.rotation);
            chaseState.SetNewTarget(playerFound);
            playerFound.GetComponent<BreadcrumbScript>().DelayedDestroy(2);
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

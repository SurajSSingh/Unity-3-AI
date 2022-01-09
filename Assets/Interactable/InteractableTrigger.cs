using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerInteract;
    public bool willOnlyTriggerOnPlayer = false;

    private void OnTriggerEnter(Collider other) 
    {
        if(willOnlyTriggerOnPlayer && other.CompareTag("Player"))
        {
            OnTriggerInteract?.Invoke();
        }   
        else
        {
            OnTriggerInteract?.Invoke();
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class OxygenHandler : MonoBehaviour
{
    [SerializeField] float oxygenMaxAmount = 10;
    [SerializeField] float oxygenAmount = 10;

    public float oxygenLostPerTick = 1;
    public float oxygenTickTimer = 1;
    public float damageAmount = 1;

    public class HealthEvent: UnityEvent<float>{};

    public HealthEvent OnNoOxygen;
    private Coroutine LosingOxygen;

    public TextMeshProUGUI oxygenText;

    private void Start() {
        oxygenAmount = oxygenMaxAmount;
        UpdateOxygenText();
    }

    private void OnTriggerEnter(Collider other) 
    {
        // When Player is entering underwater 
        if(true)
        {
            LosingOxygen = StartCoroutine(LosingOxygenCoroutine());
        }   
        Cursor.lockState = CursorLockMode.Locked;   // Locked to the camera view
        Cursor.lockState = CursorLockMode.None;     // Mouse is free from camera view (unlocked)
    }



    private void OnTriggerExit(Collider other) 
    {
        // When Player is exiting underwater
        if(LosingOxygen != null && true)
        {
            StopCoroutine(LosingOxygen);
            LosingOxygen = null;
            // TODO: Wait some time to get full oxygen
            oxygenAmount = oxygenMaxAmount;
            UpdateOxygenText();

        }
    }

    IEnumerator LosingOxygenCoroutine()
    {
        // Losing Oxygen
        while(oxygenAmount > 0)
        {
            oxygenAmount -= oxygenLostPerTick;
            UpdateOxygenText();
            yield return new WaitForSeconds(oxygenTickTimer);
        }

        while (true)
        {
             OnNoOxygen?.Invoke(damageAmount);
             yield return new WaitForSeconds(oxygenTickTimer);
        }
    }

    public void UpdateOxygenText()
    {
        oxygenText.text = $"Oxygen: {oxygenAmount}";
    }
}

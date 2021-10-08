using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleAI : MonoBehaviour
{
    public GameObject target = null;
    public float speed = 5;
    public float stepPercent = 0.01f;
    public float smoothTime = 0.1f;
    public Vector3 currentVel = Vector3.zero;

    public bool runMoveTowards = true;
    public bool runLerp = false;
    public bool runSmoothDamp = false;

    public UnityEvent unityEvent; // Both code and inspector
    public MyCustomEventWithString OnShowMessageWithTime;

    public bool showMessage = false;

    void Update()
    {
        if(target != null)
        {
            Vector3 localTargetPos = target.transform.position-transform.position;
            // DrawRay(startPoint, localTargetPoint, colorOfRay, howLongRayExistsFor)
            Debug.DrawRay(this.transform.position, localTargetPos, Color.red, 0.1f);

            Vector3 currentPos = this.transform.position;
            Vector3 targetPos = target.transform.position;

            if(runMoveTowards)
            {
                transform.position = Vector3.MoveTowards(currentPos, targetPos, speed*Time.deltaTime);
            }
            else if(runLerp)
            {
                transform.position = Vector3.Lerp(currentPos, targetPos, stepPercent);
            }
            else if(runSmoothDamp)
            {
                transform.position = Vector3.SmoothDamp(currentPos, targetPos, ref currentVel, smoothTime, speed);
            }                        

        }

        if(showMessage)
        {
            unityEvent?.Invoke();
            OnShowMessageWithTime?.Invoke($"{Time.time}");
            /*
            if(unityEvent != null)
            {
                unityEvent.Invoke();
            }
            */
            showMessage = false;
        }
    }
}

[System.Serializable] public class MyCustomEventWithString: UnityEvent<string>{}
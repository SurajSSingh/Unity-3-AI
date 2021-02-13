using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadcrumbScript : MonoBehaviour
{
    public void DelayedDestroy(float timer)
    {
        Destroy(this.gameObject, timer);
    }
}

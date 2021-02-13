using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumbGenerator : MonoBehaviour
{
    public GameObject bcPrefab;
    public float spawnTimer = 2f;
    public float destroyTimer = 3f;

    void Start()
    {
        InvokeRepeating("CreateBreadCrumb", 1f, spawnTimer);
    }

    void CreateBreadCrumb()
    {
        GameObject bc = Instantiate(bcPrefab, transform.position, transform.rotation);
        bc.GetComponent<BreadcrumbScript>().DelayedDestroy(destroyTimer);
    }
}

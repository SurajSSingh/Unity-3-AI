using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    public float maxHeight = 1;
    public float risingSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < maxHeight)
        {
            this.transform.position += Vector3.up * risingSpeed * Time.deltaTime;
        }
    }
}

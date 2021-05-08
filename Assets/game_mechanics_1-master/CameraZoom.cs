using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera vc;
    public Camera Cam;
    public KeyCode ZoomToggle = KeyCode.Z;
    public KeyCode ZoomInKey = KeyCode.Equals;
    public KeyCode ZoomOutKey = KeyCode.Minus;
    public float ZoomSpeed = 1;
    public float MinZoom = 0;
    public float MaxZoom = 20;
    // Start is called before the first frame update
    void Start()
    {
        vc = GetComponent<CinemachineVirtualCamera>();
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(ZoomToggle))
        {
            if (Input.GetKey(ZoomInKey))
            {
                //vc.m_Lens.OrthographicSize -= ZoomSpeed;
                Cam.orthographicSize -= ZoomSpeed;
            }
            if (Input.GetKey(ZoomOutKey))
            {
                //vc.m_Lens.OrthographicSize += ZoomSpeed;
                Cam.orthographicSize += ZoomSpeed;
            }
            Cam.orthographicSize = Mathf.Clamp(Cam.orthographicSize, MinZoom, MaxZoom);
        }
    }
}

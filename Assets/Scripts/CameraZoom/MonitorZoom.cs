using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;


public class MonitorZoom : MonoBehaviour
{
    public CinemachineCamera mainCam;
    public CinemachineCamera zoomCam;
    public GameObject pcScreen;

    private bool isZoomed = false;

    void OnMouseDown()
    {
        if (!isZoomed)
            ZoomIn();
    }

    void ZoomIn()
    {
        mainCam.Priority = 1;
        zoomCam.Priority = 5;
        isZoomed = true;
        pcScreen.SetActive(true);
    }
}

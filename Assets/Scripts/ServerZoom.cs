using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ServerZoom : MonoBehaviour
{
    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera zoomCam;
    public GameObject serverUI;
    public GameObject button;

    private bool isZoomed = false;

    void OnMouseDown()
    {
        if (!isZoomed)
        {
            mainCam.Priority = 1;
            zoomCam.Priority = 5;
            isZoomed = true;
            serverUI.SetActive(true);
            button.SetActive(false);
        }
    }

    void Update()
    {
        if (isZoomed && Input.GetKeyDown(KeyCode.Escape))
        {
            zoomCam.Priority = 1;
            mainCam.Priority = 5;
            isZoomed = false;
            serverUI.SetActive(false);
            Invoke(nameof(ShowButton), 2f);
        }
    }
    void ShowButton()
    {
        button.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MonitorZoom : MonoBehaviour
{
    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera zoomCam;
    public GameObject pcScreen;
    public GameObject Button;
    public GameObject Glitch;

    private bool isZoomed = false;

    void OnMouseDown()
    {
        if (!isZoomed)
            ZoomIn();
    }

    void Update()
    {
        if (isZoomed && Input.GetKeyDown(KeyCode.Escape))
            ZoomOut();
    }

    void ZoomIn()
    {
        mainCam.Priority = 1;
        zoomCam.Priority = 5;
        isZoomed = true;
        Button.SetActive(false);
        pcScreen.SetActive(true);
        if (Glitch.activeSelf)
        {
            return;
        }
        StartMinigame();
    }

    void ZoomOut()
    {
        zoomCam.Priority = 1;
        mainCam.Priority = 5;
        isZoomed = false;
        pcScreen.SetActive(false);
        Invoke(nameof(ShowButton), 2f);
    }
    void StartMinigame()
    {
        MinigameSelector selector = pcScreen.GetComponent<MinigameSelector>();
        selector.StartRandomMinigame();
    }

    void ShowButton()
    {
        Button.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;


public class CameraManager : MonoBehaviour
{
    public CinemachineCamera Cam1;
    public CinemachineCamera Cam2;

    private bool isOnCam1 = true;

    public void SwitchCamera()
    {
        if (isOnCam1)
        {
            Cam1.Priority = 1;
            Cam2.Priority = 5;
        }
        else
        {
            Cam1.Priority = 5;
            Cam2.Priority = 1;
        }

        isOnCam1 = !isOnCam1;
    }
}

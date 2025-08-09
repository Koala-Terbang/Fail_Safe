using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public PC connectedPC;
    public AudioClip cutWire;

    private void OnMouseDown()
    {
        HackerManager.Instance.StartDragTrace(connectedPC);
        AudioManager.I.PlaySFX(cutWire);
    }
}

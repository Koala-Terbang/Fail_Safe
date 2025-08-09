using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public string cableColor;
    public GameObject stretchCable;
    public AudioClip connectedSFX;

    void OnMouseDown()
    {
        SelectedCable.selectedCableColor = cableColor;
        SelectedCable.selectedCableObject = this;
    }

    public void Connect()
    {
        gameObject.SetActive(false);
        AudioManager.I.PlaySFX(connectedSFX);
        stretchCable.SetActive(true);
    }
}

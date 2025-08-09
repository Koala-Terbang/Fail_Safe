using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public string boxColor;
    public Button button;
    public GameObject panel;
    void OnMouseDown()
    {
        if (SelectedCable.selectedCableColor == boxColor)
        {
            SelectedCable.connected++;
            SelectedCable.selectedCableObject.Connect();
            Debug.Log(SelectedCable.connected);
        }
        else
        {
            FindObjectOfType<TryAgain>().tryAgain();
        }

        SelectedCable.selectedCableColor = null;
        SelectedCable.selectedCableObject = null;
    }
    void Update()
    {
        if (SelectedCable.connected == 4)
        {
            FindObjectOfType<ObjectiveManager>()?.CompleteObjective(3);
            button.interactable = false;
            panel.SetActive(false);
            FindObjectOfType<Notifications>().PopNotif();
        }
    }
}

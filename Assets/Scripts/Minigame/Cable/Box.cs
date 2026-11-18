using System.Collections;
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
        }
        else
        {
            TryAgain.OnFailedMinigame?.Invoke();
        }

        SelectedCable.selectedCableColor = null;
        SelectedCable.selectedCableObject = null;
    }
    void Update()
    {
        if (SelectedCable.connected == 4)
        {
            ObjectiveManager.OnCompleteObjective?.Invoke(3);
            button.interactable = false;
            panel.SetActive(false);
        }
    }
}

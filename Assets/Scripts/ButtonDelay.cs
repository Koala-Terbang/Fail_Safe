using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    public Button Sbutton;
    public Button Pbutton;

    public void PbuttonDelay()
    {
        Pbutton.gameObject.SetActive(true);
    }
    public void SbuttonDelay()
    {
        Sbutton.gameObject.SetActive(true);
    }
}

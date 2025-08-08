using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCutscene : MonoBehaviour
{
    public GameObject nextDialog;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            nextDialog.SetActive(true);
        }
    }
}

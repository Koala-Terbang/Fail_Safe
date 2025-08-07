using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PCType { Worker, Hacker }

public class PC : MonoBehaviour
{
    public PCType type;

    public string pcName = "PC";

    private void Start()
    {
        if (string.IsNullOrEmpty(pcName))
            pcName = gameObject.name;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    private void OnMouseOver()
    {
        FindObjectOfType<FanCleaning>().DirtCleaned();
        Destroy(gameObject);
    }
}

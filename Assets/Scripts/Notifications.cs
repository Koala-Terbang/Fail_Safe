using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifications : MonoBehaviour
{
    public GameObject Notif;
    public float durations = 1f;
    public void PopNotif()
    {
        StartCoroutine(PopupNotif());
    }
    IEnumerator PopupNotif()
    {
        Notif.SetActive(true);
        yield return new WaitForSeconds(durations);
        Notif.SetActive(false);
    }
}

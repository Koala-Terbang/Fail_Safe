using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifications : MonoBehaviour
{
    public GameObject Notif;
    public void PopNotif()
    {
        StartCoroutine(PopupNotif());
    }
    IEnumerator PopupNotif()
    {
        Notif.SetActive(true);
        yield return new WaitForSeconds(1f);
        Notif.SetActive(false);
    }
}

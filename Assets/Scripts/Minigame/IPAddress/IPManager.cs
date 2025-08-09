using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class IPAddressData
    {
        public string ip;
        public string domain;
        public string sslCert;
        public string ipType;
        public string location;
        public string lastActivity;
        public bool isSafe;
    }
public class IPManager : MonoBehaviour
{
    public static IPManager Instance;

    private IPAddress selectedIP;

    public TMP_Text ipDetailsText;
    public TMP_Text statusText;
    public Button acceptButton;
    public Button rejectButton;
    public TMP_Text clearedText;
    public Button button;
    
    private int cleared = 0;
    public int totalIPs = 5;
    public GameObject endDialog;

    private void Awake() => Instance = this;

    private void Start()
    {
        acceptButton.onClick.AddListener(AcceptIP);
        rejectButton.onClick.AddListener(RejectIP);
        UpdateClearedText();
        SetButtonsInteractable(false);
    }

    public void SelectIP(IPAddress ipButton)
    {
        selectedIP?.Unhighlight();

        selectedIP = ipButton;
        selectedIP.Highlight();

        ShowDetails(selectedIP.ipData);
        SetButtonsInteractable(true);
    }

    void ShowDetails(IPAddressData ip)
    {
        ipDetailsText.text =
            $"IP: {ip.ip}\n" +
            $"Domain: {ip.domain}\n" +
            $"SSL Cert: {ip.sslCert}\n" +
            $"IP Type: {ip.ipType}\n" +
            $"Location: {ip.location}\n" +
            $"Last Activity: {ip.lastActivity}";

        statusText.text = ip.isSafe ? "Status: SAFE" : "Status: THREAT";
    }

    void AcceptIP()
    {
        if (selectedIP == null) return;

        if (selectedIP.ipData.isSafe)
        {
            FinishIP();
            FindObjectOfType<Notifications>().PopNotif();
        }
        else
        {
            FindObjectOfType<TryAgain>().tryAgain();
        }
    }

    void RejectIP()
    {
        if (selectedIP == null) return;

        if (!selectedIP.ipData.isSafe)
        {
            FinishIP();
            FindObjectOfType<Notifications>().PopNotif();
        }
        else
        {
            FindObjectOfType<TryAgain>().tryAgain();
        }

        
    }

    void FinishIP()
    {
        selectedIP.DisableButton();
        selectedIP = null;
        SetButtonsInteractable(false);
        cleared++;
        UpdateClearedText();
        Debug.Log(cleared);

        if (cleared >= totalIPs)
        {
            endDialog.SetActive(true);
            button.interactable = false;
            gameObject.SetActive(false);
        }
    }

    void SetButtonsInteractable(bool state)
    {
        acceptButton.interactable = state;
        rejectButton.interactable = state;
    }

    void UpdateClearedText()
    {
        clearedText.text = $"Cleared: {cleared}/{totalIPs}";
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IPAddress : MonoBehaviour
{
    public IPAddressData ipData;
    public TextMeshProUGUI ipText;
    public Image indicator;

    private Button btn;
    public Sprite selectedButton;
    public Sprite doneButton;


    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectIP);
    }

    void Start()
    {
        ipText.text = ipData.ip;
    }

    public void SelectIP()
    {
        IPManager.Instance.SelectIP(this);
    }

    public void DisableButton()
    {
        btn.interactable = false;
        indicator.sprite = doneButton;
    }

    public void Highlight()
    {
        indicator.sprite = selectedButton;
    }

    public void Unhighlight()
    {
        indicator.sprite = doneButton;
    }
}

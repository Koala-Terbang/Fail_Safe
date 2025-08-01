using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComicIntro : MonoBehaviour
{
    public GameObject[] slides;
    public GameObject Dialog;
    private int index = 0;

    void Start()
    {
        slides[0].SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            if (index < slides.Length)
            {
                slides[index].SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
                Dialog.SetActive(true);
            }
        }
    }
}

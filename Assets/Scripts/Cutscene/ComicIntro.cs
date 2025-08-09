using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ComicIntro : MonoBehaviour
{
    public GameObject[] slides;
    public GameObject Dialog;
    public string nextScene;
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
                if (nextScene == "null")
                {
                    Dialog.SetActive(true);
                }
                else
                {
                    SceneManager.LoadScene(nextScene);
                }
            }
        }
    }
}

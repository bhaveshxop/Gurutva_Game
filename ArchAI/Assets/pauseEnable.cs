using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseEnable : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject minimap;
    public GameObject abilities;
    public GameObject info;
    public bool wasActive;
    public GameObject info2;
    public bool wasActive2;
    public static pauseController instance;
    public GameObject pauseBut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void GoBack()
    {
        pauseButton.SetActive(true);
        pauseController.instance.PlayGame();
    }*/
    public void PlayGame()
    {
        pauseBut.SetActive(true);
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
        minimap.SetActive(true);
        abilities.SetActive(true);
        if (wasActive)
        {
            info.SetActive(true);
        }
        if (wasActive2)
        {
            info2.SetActive(true);
        }


    }
}

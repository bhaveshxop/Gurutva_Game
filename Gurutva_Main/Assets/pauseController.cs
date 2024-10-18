using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject minimap;
    public GameObject abilities;
    public GameObject info;
    public bool wasActive;
    public GameObject info2;
    public bool wasActive2;
    public static pauseController instance;
    private void Awake()
    {
        if(instance != null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        
        Time.timeScale = 0.0f;
        this.gameObject.SetActive(false);
        pausePanel.SetActive(true);
        minimap.SetActive(false);
        abilities.SetActive(false);
        if (info.gameObject.active == true)
        {
            info.SetActive(false);
            wasActive = true;
        }
        if (info2.gameObject.active == true)
        {
            info2.SetActive(false);
            wasActive2 = true;
        }
    }
    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(true);
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

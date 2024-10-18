using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [SerializeField ]GameObject panel;
    [SerializeField] GameObject start;
    [SerializeField] GameObject info;
    [SerializeField] GameObject quit;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        start.SetActive(true);
        info.SetActive(true);
        quit.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PressedStart()
    {
        SceneManager.LoadScene("Living");
    }
    public void PressedInfo()
    {
        panel.SetActive(true);
        start.SetActive(false);
        info.SetActive(false);
        quit.SetActive(false);  
    }
    public void PressedExit()
    {
        Application.Quit();
    }
    public void PressedBack()
    {
        panel.SetActive(false);
        start.SetActive(true);
        info.SetActive(true);
        quit.SetActive(true);
    }
}

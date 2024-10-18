using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class stopScene : MonoBehaviour
{
    [SerializeField] VideoPlayer player;
    public GameObject videoplayers;
    [SerializeField] Canvas canvas;
    [SerializeField] Canvas canvas2;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject panel2;
    [SerializeField] GameObject panel3;
    [SerializeField] GameObject panel4;
    [SerializeField] Animator anim;
    [SerializeField] GameObject object1;
    [SerializeField] GameObject object2;
    [SerializeField] GameObject videooo;
    public Text Text1;
    
    // Start is called before the first frame update
    void Awake()
    {
        panel.SetActive(true);
        panel2.SetActive(false);
        /*canvas2.enabled = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (object2.transform.position.x > 1.6)
        {
            Debug.Log("Next To Eachother");
            anim.SetBool("isShu", true);
            PlayerPrefs.SetInt("close", 1);
            Text1.text = "Press E to Time Travel";
        }
        if(Input.GetKey(KeyCode.Q))
        {
            Text1.text = "Press E to Time Travel";

        }
        /*if (player.isPaused)
        {
            //panel.enabled = false;
            panel.SetActive(false);
            //canvas2.enabled = true;
            panel2.SetActive(true);
            *//*canvas2.enabled = true;*//*
            anim.SetBool("isStart", true);
        }*/
    }
   /* public void skipIntro()
    {
        *//*Debug.Log("skipped");
        *//*canvas.enabled = false;
        canvas2.enabled = true;*//*
        player.Pause();*//*
        videooo.SetActive(false);
        player.Pause();
        videoplayers.SetActive(false);
    }*/

}

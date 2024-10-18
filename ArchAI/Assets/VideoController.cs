using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class VideoController : MonoBehaviour
{
    public VideoPlayer player1;
    public VideoPlayer player2;
    public VideoPlayer player3;
    public VideoPlayer player4;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject info;
    public int times_played;
    public bool hasSkipped = false;
    public GameObject lunas;
    public GameObject wanda;
    public bool hasSkippedFinal = false;
    public GameObject tv;
    public GameObject turntv;
    // Start is called before the first frame update
    void Start()
    {
        times_played = 0;
        player1.Play();
        panel1.SetActive(true);
        lunas.SetActive(false);
        wanda.SetActive(false);
        tv.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            tv.SetActive(false);
            turntv.SetActive(false);
        }
        if (hasSkipped==true)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                panel4.SetActive(true);
                panel3.SetActive(false);
                player4.Play();
                times_played++;
            }
        }
        if(hasSkippedFinal==true)
        {
            lunas.SetActive(true);
            wanda.SetActive(true);  
        }
        if(player1.isPaused &&  times_played==0)
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
            player2.Play();
            times_played++;
        }
        if(player2.isLooping  && times_played==1 )
        {
            if(Input.GetKeyDown(KeyCode.Y))
            {
                panel2.SetActive(false);
                panel3.SetActive(true);
                player2.Pause();
                player3.Play();
                times_played++;
            }
        }
        if( player3.isPaused && times_played==2)
        {
            panel3.SetActive(false);

            if(Input.GetKeyDown(KeyCode.L))
            {
                panel4.SetActive(true);
                turntv.SetActive(false);
                panel3.SetActive(false);
                player4.Play();
                tv.SetActive(false);
                times_played++;
            }
        }
        if(player4.isPaused && times_played==3)
        {
            info.SetActive(true);
            panel4.SetActive(false);
            lunas.SetActive(true);
            wanda.SetActive(true);
            tv.SetActive(false);
            
        }
        
    }
    public void skipFinal()
    {
        panel4.SetActive(false);
        info.SetActive(true);
        player4.Pause();
        hasSkippedFinal = true;
        tv.SetActive(false);
    }
    public void skipIntro()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel4.SetActive(false);
        panel3.SetActive(false);
        player1.Pause();
        player2.Pause();
        player3.Pause();
       // player4.Play();
        times_played=2;
        hasSkipped = true;
    }
}

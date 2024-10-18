using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class pauseIntro : MonoBehaviour
{
   public GameObject intro;
   public VideoPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (player.isPaused)
        {
            intro.SetActive(false);
        }*/
    }
    public void PressedSkipIntro()
    {
        intro.SetActive(false);
        player.Pause();
    }
     
}

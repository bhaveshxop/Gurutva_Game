using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
///  Example how to rewind time with key press
/// </summary>
public class RewindByKeyPress : MonoBehaviour
{
    bool isRewinding = false;
    [SerializeField] float rewindIntensity = 0.02f;          //Variable to change rewind speed
    [SerializeField] RewindManager rewindManager;
    [SerializeField] AudioSource rewindSound;
    [SerializeField] Image image;
    public Text rew;
    float rewindValue = 0;
    public bool isWaitOn=false;
    public int usedTime = 0;
    private void Start()
    {
        rew.text = "3";
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.E) && usedTime < 4 )                     //Change keycode for your own custom key if you want
        {
            MoveErika.Instance.hideInstructions();
            PlayerPrefs.SetInt("reverse", 1);
            rewindValue += rewindIntensity;                 //While holding the button, we will gradually rewind more and more time into the past

            if (!isRewinding)
            {
                rewindManager.StartRewindTimeBySeconds(rewindValue);
                rewindSound.Play();
                // isWaitOn = true;
                usedTime++;
                rew.text = (3 - usedTime).ToString();
                Debug.Log(usedTime);
                
                //StartCoroutine(waitTime());
            }
            else
            {
                if(rewindManager.HowManySecondsAvailableForRewind>rewindValue)      //Safety check so it is not grabbing values out of the bounds
                    rewindManager.SetTimeSecondsInRewind(rewindValue);
            }
            isRewinding = true;
        }
        else
        {
            PlayerPrefs.SetInt("reverse", 0);
            if (isRewinding)
            {
                rewindManager.StopRewindTimeBySeconds();
                rewindSound.Stop();
                rewindValue = 0;
                isRewinding = false;
                
            }
        }
        if(usedTime>=3)
        {
            var tempColor = image.color;
            tempColor.a = 0.3f;
            image.color = tempColor;
            PlayerPrefs.SetInt("rewindOver", 1);
        }

    }
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(5);
        isWaitOn=false;
    }
    
   
}
